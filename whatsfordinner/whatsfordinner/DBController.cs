using System;
using System.Collections.Generic;
using Npgsql;
using System.Data;
using Microsoft.Win32.SafeHandles;
using System.Configuration;

namespace whatsfordinner {
    class DBController {
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();
        private NpgsqlConnection conn;

        private static string dbHost = "localhost";
        private static string dbName = "testDB";
        //		private static string dbName = "CornfieldDB";
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
            string sql = "INSERT INTO ingredients(name, measurementtype, price, tags) VALUES (@name, @measurementtype, @price, @tags)";

            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            command.Parameters.AddWithValue("@name", ingredientToInsert.GetOrSetName);
            command.Parameters.AddWithValue("@measurementtype", ingredientToInsert.GetOrSetMeasurementType);
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

    }
}
