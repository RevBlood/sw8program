using System;
using System.Collections.Generic;
using System.Linq;
using System.Device.Location;

namespace whatsfordinner {
    class SearchMethods {

        public Dictionary<Retailer, ExtraData> getExtraData(int recipeId, int radius, double latitude, double longitude) {

            decimal NormalPrice = 0;
            decimal storeNormalPrice = 0;
            decimal price = 0;
            decimal savingStorePrice;
            decimal savingStorePercent;
            decimal savingGeneralPrice;
            decimal savingGeneralPercent;

            DBController dbc = new DBController();

            Dictionary<Retailer, ExtraData> retailerDictionary = new Dictionary<Retailer, ExtraData>();

            RecipeWithIngredients recipeWithIngredients = dbc.GetRecipeByIdWithIngredients(recipeId);

            List<Retailer> retailers = GetStoresWithinRadius(dbc.GetAllRetailers(), radius, latitude, longitude);

            //finds all retailers within the radius which has an offer on anything on the recipe.
            for (int i = retailers.Count() - 1; i > -1; i--) {

                bool found = false;

                foreach (Offers offer in recipeWithIngredients.GetOrSetOffers) {

                    if (retailers[i].GetOrSetId == offer.GetOrSetRetailerId) {
                        found = true;
                    }
                }

                if (!found) {
                    retailers.RemoveAt(i);
                }
            }

            //foreach retailer, get the offered price, the normal price from the store, and the normal price from average.
            foreach (Retailer retailer in retailers) {

                foreach (Ingredient ingredient in recipeWithIngredients.GetOrSetIngredients) {
                    foreach (Offers offer in recipeWithIngredients.GetOrSetOffers) {
                        if (offer.GetOrSetIngredientId == ingredient.GetOrSetId) {

                            price += offer.GetOrSetOnSalePrice;

                            if (storeNormalPrice != -1) {
                                if (offer.GetOrSetNormalPrice.HasValue) {
                                    storeNormalPrice += (decimal)offer.GetOrSetNormalPrice;
                                } else {
                                    storeNormalPrice = -1;
                                }
                            }

                        } else {
                            price += ingredient.GetOrSetPrice;
                            storeNormalPrice += ingredient.GetOrSetPrice;
                        }

                        NormalPrice += ingredient.GetOrSetPrice;
                    }
                }

                //The saving prices and percentages are calculated
                savingGeneralPrice = NormalPrice - price;
                savingStorePrice = storeNormalPrice - price;

                savingGeneralPercent = savingGeneralPrice / price * 100;
                savingStorePercent = savingStorePrice / price * 100;

                //Important, this is the order in which the dictionary is ordered

                retailerDictionary.Add(retailer, new ExtraData(price, savingStorePrice, savingGeneralPrice, savingStorePercent, savingGeneralPercent, retailer.GetOrSetId));
                price = 0;
            }

            retailerDictionary = retailerDictionary.OrderBy(x => x.Value.Price).ToDictionary(x => x.Key, x => x.Value);

            dbc.Close();
            return retailerDictionary;
        }

        public Dictionary<Recipe, ExtraData> sortBasedOnPreferences(int pricepreference, int savingspreference, int numberOfRecipes, int radius, double latitude, double longitude) {

            DBController dbc = new DBController();

            // Get all recipes
            List<Recipe> recipes = dbc.GetAllRecipes();

            dbc.Close();

            Dictionary<Recipe, ExtraData> recipesAndPrices = new Dictionary<Recipe, ExtraData>();
            Dictionary<Recipe, ExtraData> finalRecipesAndPrices = new Dictionary<Recipe, ExtraData>();

            // Get recipes that can be made from nearby stores
            foreach (Recipe recipe in recipes) {

                //evaluate each recipe and find the best store for the user with a given set of preferences
                Dictionary<Retailer, ExtraData> recipeData = getExtraData(recipe.GetOrSetId, radius, latitude, longitude);
                recipeData = RangeEvaluator(recipeData, recipeData.Count, pricepreference);
                recipeData = recipeData.OrderBy(x => x.Value.SavingGeneralPrice).ToDictionary(x => x.Key, x => x.Value);
                recipeData = RangeEvaluator(recipeData, recipeData.Count, savingspreference);

                //add the apporiate data to the recipe list, making sure we get the best of each recipe
                recipesAndPrices.Add(recipe, recipeData.OrderBy(x => x.Value.Rating).First().Value);
                recipesAndPrices.Last().Value.Rating = 0;

            }

            //evaluate and sort the data after which recipe scored the highest amount of points
            recipesAndPrices = recipesAndPrices.OrderBy(x => x.Value.Price).ToDictionary(x => x.Key, x => x.Value);
            recipesAndPrices = RangeEvaluator(recipesAndPrices, 100, pricepreference);

            recipesAndPrices = recipesAndPrices.OrderBy(x => x.Value.SavingGeneralPercent).ToDictionary(x => x.Key, x => x.Value);
            recipesAndPrices = RangeEvaluator(recipesAndPrices, 100, savingspreference);

            finalRecipesAndPrices = recipesAndPrices.OrderBy(x => x.Value.Rating).Take(numberOfRecipes).ToDictionary(x => x.Key, x => x.Value);

            return finalRecipesAndPrices;
        }

        // Given a list of retailers, selects and returns those that are within a given radius of a position
        public List<Retailer> GetStoresWithinRadius(List<Retailer> retailers, int radius, double latitude, double longitude) {

            GeoCoordinate center = new GeoCoordinate(latitude, longitude);

            return retailers.Select(x => new KeyValuePair<Retailer, GeoCoordinate>(x, new GeoCoordinate(Convert.ToDouble(x.GetOrSetLatitude), Convert.ToDouble(x.GetOrSetLongitude))))
                                  .Where(x => x.Value.GetDistanceTo(center) < radius).ToDictionary(x => x.Key, x => x.Value).Keys.ToList();
        }

        // For a dictionary of recipies and extra data, provide a linear rating
        // from 0 for the worst value to totalPartitions for the best. The rating is scaled with preference
        private Dictionary<T, ExtraData> RangeEvaluator<T>(Dictionary<T, ExtraData> list, int totalPartitions, int preference) {
            int recipeCount = list.Count;
            int tempInt = 0;
            for (int i = totalPartitions; i >= 0; i--) {

                // Calculate range of entries that should have a certain rating and remember how much was subtracted (for next iteration)
                int partitionSize = Convert.ToInt32(Math.Round((double)recipeCount / i));
                recipeCount -= partitionSize;

                // Fill in the relevant rating inside the calculated range of the list
                for (int k = tempInt; k < tempInt + partitionSize; k++) {
                    tempInt += partitionSize;
                    list.ElementAt(k).Value.Rating += i * preference;
                }

            }
            return list;
        }
    }
}
