using System;
using System.Collections.Generic;
using Npgsql;
using System.Data;
using Microsoft.Win32.SafeHandles;
using System.Configuration;

namespace whatsfordinner {
    public class DBController {
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();
        private NpgsqlConnection conn;

        private static string dbHost = "localhost";
        private static string dbName = "testDB";
        private static string dbUser = "casper";
        private static string dbPass = "1234";

        public DBController() {
            string connstring = String.Format(
                "Server={0};User Id={1};Password={2};Database={3};",
                dbHost, dbUser, dbPass, dbName);
            conn = new NpgsqlConnection(connstring);
            conn.Open();
        }

        public void Close() {
            conn.Close();
        }

        private DataRowCollection Query(string sql) {
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];

            return dt.Rows;
        }

        private int NonQuery(NpgsqlCommand command, string table) {
            int affectedRows = command.ExecuteNonQuery();
            if (affectedRows == 0) {
                return -1;
            } else {
                return affectedRows;
            }
        }
        //
        // GetAll of the Entities
        //
        public List<Account> GetAllAccounts() {
            string sql = String.Format("SELECT * FROM accounts");
            DataRowCollection res = Query(sql);
            List<Account> allAccounts = new List<Account>();
            if (res.Count >= 1) {
                foreach (DataRow account in res) {
                    allAccounts.Add(new Account(account));
                }
                return allAccounts;
            } else {
                return allAccounts;
            }
        }

        public List<Comment> GetAllComments() {
            string sql = String.Format("SELECT * FROM comments");
            DataRowCollection res = Query(sql);
            List<Comment> allComments = new List<Comment>();
            if (res.Count >= 1) {
                foreach (DataRow comment in res) {
                    allComments.Add(new Comment(comment));
                }
                return allComments;
            } else {
                return allComments;
            }
        }

        public List<Ingredient> GetAllIngredients() {
            string sql = String.Format("SELECT * FROM ingredients");
            DataRowCollection res = Query(sql);
            List<Ingredient> allIngredients = new List<Ingredient>();
            if (res.Count >= 1) {
                foreach (DataRow ingredient in res) {
                    allIngredients.Add(new Ingredient(ingredient));
                }

                return allIngredients;
            } else {
                return allIngredients;
            }
        }

        public List<Recipe> GetAllRecipes() {
            string sql = String.Format("SELECT * FROM recipes");
            DataRowCollection res = Query(sql);
            List<Recipe> allRecipes = new List<Recipe>();
            if (res.Count >= 1) {
                foreach (DataRow datarow in res) {
                    Recipe recipe = new Recipe(datarow);
                    allRecipes.Add(recipe);
                }
                return allRecipes;
            } else {
                return allRecipes;
            }
        }

        public List<Retailer> GetAllRetailers() {
            string sql = String.Format("SELECT * FROM retailers");
            DataRowCollection res = Query(sql);
            List<Retailer> allRetailers = new List<Retailer>();
            if (res.Count >= 1) {
                foreach (DataRow datarow in res) {
                    Retailer retailer = new Retailer(datarow);
                    allRetailers.Add(retailer);
                }
                return allRetailers;
            } else {
                return allRetailers;
            }
        }
        //
        // Get all of the Relationships
        //
        public List<Favorises> GetAllFavorises() {
            string sql = String.Format("SELECT * FROM favorises");
            DataRowCollection res = Query(sql);
            List<Favorises> allFavorises = new List<Favorises>();
            if (res.Count >= 1) {
                foreach (DataRow datarow in res) {
                    Favorises favorises = new Favorises(datarow);
                    allFavorises.Add(favorises);
                }
                return allFavorises;
            } else {
                return allFavorises;
            }
        }

        public List<HasEaten> GetAllHasEaten() {
            string sql = String.Format("SELECT * FROM haseaten");
            DataRowCollection res = Query(sql);
            List<HasEaten> allHasEaten = new List<HasEaten>();
            if (res.Count >= 1) {
                foreach (DataRow datarow in res) {
                    HasEaten hasEaten = new HasEaten(datarow);
                    allHasEaten.Add(hasEaten);
                }
                return allHasEaten;
            } else {
                return allHasEaten;
            }
        }

        public List<IngredientIn> GetAllIngredientIn() {
            string sql = String.Format("SELECT * FROM ingredientin");
            DataRowCollection res = Query(sql);
            List<IngredientIn> allIngredientIn = new List<IngredientIn>();
            if (res.Count >= 1) {
                foreach (DataRow datarow in res) {
                    IngredientIn ingredientIn = new IngredientIn(datarow);
                    allIngredientIn.Add(ingredientIn);
                }
                return allIngredientIn;
            } else {
                return allIngredientIn;
            }
        }

        public List<Offers> GetAllOffers() {
            string sql = String.Format("SELECT * FROM offers");
            DataRowCollection res = Query(sql);
            List<Offers> allOffers = new List<Offers>();
            if (res.Count >= 1) {
                foreach (DataRow datarow in res) {
                    Offers offers = new Offers(datarow);
                    allOffers.Add(offers);
                }
                return allOffers;
            } else {
                return allOffers;
            }
        }

        public List<Pictures> GetAllPictures() {
            string sql = String.Format("SELECT * FROM pictures");
            DataRowCollection res = Query(sql);
            List<Pictures> allPictures = new List<Pictures>();
            if (res.Count >= 1) {
                foreach (DataRow datarow in res) {
                    Pictures pictures = new Pictures(datarow);
                    allPictures.Add(pictures);
                }
                return allPictures;
            } else {
                return allPictures;
            }
        }
        //
        // All Entities methods for adding a single instance to the DB
        //
        public int AddAccount(Account accountToInsert) {
            string sql = "INSERT INTO accounts(username, password, email, settings, preferences) VALUES (@username, @password, @email, @settings, @preferences)";

            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            command.Parameters.AddWithValue("@username", accountToInsert.GetOrSetUsername);
            command.Parameters.AddWithValue("@password", accountToInsert.GetOrSetPassword);
            command.Parameters.AddWithValue("@email", accountToInsert.GetOrSetEmail);
            command.Parameters.AddWithValue("@settings", accountToInsert.GetOrSetSettings);
            command.Parameters.AddWithValue("@preferences", accountToInsert.GetOrSetPreferences);

            return NonQuery(command, "accounts");
        }

        public int AddComment(Comment commentToInsert) {
            string sql = "INSERT INTO comments(accountid, recipeid, text) VALUES (@accountid, @recipeid, @text)";

            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            command.Parameters.AddWithValue("@accountid", commentToInsert.GetOrSetAccountId);
            command.Parameters.AddWithValue("@recipeid", commentToInsert.GetOrSetRecipeId);
            command.Parameters.AddWithValue("@text", commentToInsert.GetOrSetText);

            return NonQuery(command, "comments");
        }

        public int AddIngredient(Ingredient ingredientToInsert) {
            string sql = "INSERT INTO ingredients(name, measurementtype, measure, price, tags) VALUES (@name, @measurementtype, @measure, @price, @tags)";

            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            command.Parameters.AddWithValue("@name", ingredientToInsert.GetOrSetName);
            command.Parameters.AddWithValue("@measurementtype", ingredientToInsert.GetOrSetMeasurementType);
            command.Parameters.AddWithValue("@measure", ingredientToInsert.GetOrSetMeasure);
            command.Parameters.AddWithValue("@price", ingredientToInsert.GetOrSetPrice);
            command.Parameters.AddWithValue("@tags", ingredientToInsert.GetOrSetTags);

            return NonQuery(command, "ingredients");
        }

        public int AddRecipe(Recipe recipeToInsert) {
            string sql = "INSERT INTO recipes(accountid, name, description, numberofservings, tags, rating) VALUES (@accountid, @name, @description, @numberofservings, @tags, @rating)";

            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            command.Parameters.AddWithValue("@accountid", recipeToInsert.GetOrSetAccountId);
            command.Parameters.AddWithValue("@name", recipeToInsert.GetOrSetName);
            command.Parameters.AddWithValue("@description", recipeToInsert.GetOrSetDescription);
            command.Parameters.AddWithValue("@numberofservings", recipeToInsert.GetOrSetNumberOfServings);
            command.Parameters.AddWithValue("@tags", recipeToInsert.GetOrSetTags);
            command.Parameters.AddWithValue("@rating", recipeToInsert.GetOrSetRating);

            return NonQuery(command, "recipes");
        }

        public int AddRetailer(Retailer retailerToInsert) {
            string sql = "INSERT INTO retailers(latitude, longitude, companyname, description, openinghours) VALUES (@latitude, @longitude, @companyname, @description, @openinghours)";

            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            command.Parameters.AddWithValue("@latitude", retailerToInsert.GetOrSetLatitude);
            command.Parameters.AddWithValue("@longitude", retailerToInsert.GetOrSetLongitude);
            command.Parameters.AddWithValue("@companyname", retailerToInsert.GetOrSetCompanyName);
            command.Parameters.AddWithValue("@description", retailerToInsert.GetOrSetDescription);
            command.Parameters.AddWithValue("@openinghours", retailerToInsert.GetOrSetOpeningHours);

            return NonQuery(command, "retailers");
        }
        //
        // All Entities methods for adding a single instance to the DB
        //
        public int AddFavorises(Favorises favorisesToInsert) {
            string sql = "INSERT INTO favorises(accountid, recipeid) VALUES (@accountid, @recipeid)";

            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            command.Parameters.AddWithValue("@accountid", favorisesToInsert.GetOrSetAccountId);
            command.Parameters.AddWithValue("@recipeid", favorisesToInsert.GetOrSetRecipeId);

            return NonQuery(command, "favorises");
        }

        public int AddHasEaten(HasEaten hasEatenToInsert) {
            string sql = "INSERT INTO haseaten(accountid, recipeid, eatenat, rating) VALUES (@accountid, @recipeid, @eatenat, @rating)";

            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            command.Parameters.AddWithValue("@accountid", hasEatenToInsert.GetOrSetAccountId);
            command.Parameters.AddWithValue("@recipeid", hasEatenToInsert.GetOrSetRecipeId);
            command.Parameters.AddWithValue("@eatenat", hasEatenToInsert.GetOrSetEatenAt);
            command.Parameters.AddWithValue("@rating", hasEatenToInsert.GetOrSetRating);

            return NonQuery(command, "haseaten");
        }

        public int AddIngredientIn(IngredientIn ingredientInToInsert) {
            string sql = "INSERT INTO ingredientin(ingredientid, recipeid, amount) VALUES (@ingredientid, @recipeid, @amount)";

            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            command.Parameters.AddWithValue("@ingredientid", ingredientInToInsert.GetOrSetIngredientId);
            command.Parameters.AddWithValue("@recipeid", ingredientInToInsert.GetOrSetRecipeId);
            command.Parameters.AddWithValue("@amount", ingredientInToInsert.GetOrSetAmount);

            return NonQuery(command, "ingredientin");
        }

        public int AddOffers(Offers offersToInsert) {
            string sql = "INSERT INTO offers(retailerid, ingredientid, offerfrom, offerto, normalprice, onsaleprice, krsaving, percentagesavingretailer, percentagesavinggeneral) "
                            + "VALUES (@retailerid, @ingredientid, @offerfrom, @offerto, @normalprice, @onsaleprice, @krsaving, @percentagesavingretailer, @percentagesavinggeneral)";

            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            command.Parameters.AddWithValue("@retailerid", offersToInsert.GetOrSetRetailerId);
            command.Parameters.AddWithValue("@ingredientid", offersToInsert.GetOrSetIngredientId);
            command.Parameters.AddWithValue("@offerfrom", offersToInsert.GetOrSetOfferFrom);
            command.Parameters.AddWithValue("@offerto", offersToInsert.GetOrSetOfferTo);
            command.Parameters.AddWithValue("@normalprice", offersToInsert.GetOrSetNormalPrice);
            command.Parameters.AddWithValue("@onsaleprice", offersToInsert.GetOrSetOnSalePrice);
            command.Parameters.AddWithValue("@krsaving", offersToInsert.GetOrSetKrSaving);
            command.Parameters.AddWithValue("@percentagesavingretailer", offersToInsert.GetOrSetPercentageSavingRetailer);
            command.Parameters.AddWithValue("@percentagesavinggeneral", offersToInsert.GetOrSetPercentageSavingGeneral);

            return NonQuery(command, "offers");
        }

        public int AddPictures(Pictures picturesToInsert) {
            string sql = "INSERT INTO pictures(accountid, recipeid, picturepath, creationdate) VALUES (@accountid, @recipeid, @picturepath, @creationdate)";

            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            command.Parameters.AddWithValue("@accountid", picturesToInsert.GetOrSetAccountId);
            command.Parameters.AddWithValue("@recipeid", picturesToInsert.GetOrSetRecipeId);
            command.Parameters.AddWithValue("@picturepath", picturesToInsert.GetOrSetPicturePath);
            command.Parameters.AddWithValue("@creationdate", picturesToInsert.GetOrSetCreationDate);

            return NonQuery(command, "pictures");
        }

    }
}
