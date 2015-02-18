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

        public int AddIngredient(Ingredient ingredientToInsert) {
            string sql = "INSERT INTO whatsfordinner.ingredient(name, measure_type) VALUES (@name, @measure_type)";

            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            command.Parameters.AddWithValue("@name", ingredientToInsert.GetOrSetName);
            command.Parameters.AddWithValue("@measure_type", ingredientToInsert.GetOrSetMeasurementType);

            return NonQuery(command, "whatsfordinner.ingredient");
        }

        public int AddAccount(Account accountToInsert) {
            string sql = "INSERT INTO whatsfordinner.account(name, password, email, creation_date) VALUES (@name, @password, @email, @creation_date)";

            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            command.Parameters.AddWithValue("@name", accountToInsert.GetOrSetUsername);
            command.Parameters.AddWithValue("@password", accountToInsert.GetOrSetPassword);
            command.Parameters.AddWithValue("@email", accountToInsert.GetOrSetEmail);


            return NonQuery(command, "whatsfordinner.account");
        }
    }
}
