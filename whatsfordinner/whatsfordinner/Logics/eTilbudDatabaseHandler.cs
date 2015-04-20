using System;
using System.Collections.Generic;
using System.Xml;

namespace whatsfordinner {
    class eTilbudDatabaseHandler {
        Dictionary<string, int> RetailerIdMap = new Dictionary<string, int>();
        Decimal defaultValue = (decimal) -1.0;

        public void save(List<Dealer> dealers, List<Store> stores, List<Offer> offers) {

            //Go through all eTilbudsAvisen stores and create equivalent Retailers from the data, recognized by the Database
            foreach (Store store in stores) {
                Retailer retailer = new Retailer();
                retailer.GetOrSetLatitude = store.latitude.ToString();
                retailer.GetOrSetLongitude = store.longitude.ToString();

                //Fetch relevant data from the eTilbudsAvisen dealer, to fill in more blanks of Retailer
                foreach (Dealer dealer in dealers) {

                    //Match the dealer id of store with the actual dealer
                    if (store.dealer_id == dealer.Id) {
                        retailer.GetOrSetCompanyName = dealer.Name;
                    }
                }

                // Got no proper data for opening hours or description yet.
                retailer.GetOrSetOpeningHours = null;

                String categories;
                if(store.category_ids.Count != 0) {
                    categories = store.category_ids[0];
                    for (int i = 1; i < store.category_ids.Count - 1; i++) {
                        categories += ',' + store.category_ids[i];
                    }
                } else {
                    categories = "No Categories";
                }

                retailer.GetOrSetDescription = categories;

                //Put the retailer into the Database
                DBController dbc = new DBController();
                int databaseId = dbc.AddRetailer(retailer);
                RetailerIdMap.Add(store.id, databaseId);
                dbc.Close();  
            }
            // Move on to convert and save all offers
            //saveOffers(offers);
        }

        private void saveOffers(List<Offer> offers) {

            // Variables that needs to be calculated
            decimal kroner_savings;
            decimal percent_saving_retailer;
            decimal percent_saving_general;

            // Go through all eTilbudsAvisen offers and create equivalent dbOffers from the data, recognized by the Database
            for (int i = 0; i < offers.Count -1; i++) {
                Offers dbOffers = new Offers();

                // If an offer can not be mapped to a retailer, skip the offer
                if (RetailerIdMap.ContainsKey(offers[i].store_id)) {

                    //Convert values of offers to dbOffers 
                    dbOffers.GetOrSetRetailerId = RetailerIdMap[offers[i].store_id];
                    dbOffers.GetOrSetOfferFrom = XmlConvert.ToDateTime(offers[i].run_from, XmlDateTimeSerializationMode.Utc);
                    dbOffers.GetOrSetOfferTo = XmlConvert.ToDateTime(offers[i].run_till, XmlDateTimeSerializationMode.Utc);
                    dbOffers.GetOrSetOnSalePrice = (decimal)offers[i].pricing.price;

                    //Some items does not have values; directly, or because they can't be calculated: give default value of -1.0
                    if (String.IsNullOrEmpty(offers[i].pricing.pre_price.ToString())) {
                        dbOffers.GetOrSetNormalPrice = defaultValue;
                        dbOffers.GetOrSetKrSaving = defaultValue;
                        dbOffers.GetOrSetPercentageSavingGeneral = defaultValue;
                        dbOffers.GetOrSetPercentageSavingRetailer = defaultValue;

                    //If variables have values, calculate and/or convert them to an appropriate format.
                    } else {
                        dbOffers.GetOrSetNormalPrice = (decimal)offers[i].pricing.pre_price;
                        kroner_savings = dbOffers.GetOrSetNormalPrice - dbOffers.GetOrSetOnSalePrice;
                        dbOffers.GetOrSetKrSaving = kroner_savings;
                        percent_saving_retailer = (dbOffers.GetOrSetOnSalePrice / dbOffers.GetOrSetNormalPrice) * 100;
                        dbOffers.GetOrSetPercentageSavingRetailer = percent_saving_retailer;

                        //TODO: once the database has been set up and each offer has been matched with ingredient, do this.
                        dbOffers.GetOrSetPercentageSavingGeneral = (decimal)-1.0;
                    }

                    //TODO: ingredientId?? - See TODO above
                    dbOffers.GetOrSetIngredientId = 1;

                    //Save to Database
                    DBController dbc = new DBController();
                    dbc.AddOffers(dbOffers);
                    dbc.Close();
                }
            }
        }
    }
}
