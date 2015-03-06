using System;
using System.Collections.Generic;
using Npgsql;
using System.Data;
using Microsoft.Win32.SafeHandles;
using System.Configuration;


namespace whatsfordinner {
        public static class DBDebug {
        /*
        public int AddIngredient() {
            string sql = "INSERT INTO whatsfordinner.ingredient(name, measure_type) VALUES (@name, @measure_type)";

            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            command.Parameters.AddWithValue("@name", "test1");
            command.Parameters.AddWithValue("@measure_type", "test2");

            return NonQuery(command, "whatsfordinner.ingredient");
        }

        public int AddOneTestAccount() {
            string sql = "INSERT INTO accounts(username, password, email, settings, preferences) VALUES (@username, @password, @email, @settings, @preferences)";

            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            command.Parameters.AddWithValue("@username", "andrejas");
            command.Parameters.AddWithValue("@password", "drdrois");
            command.Parameters.AddWithValue("@email", "drois@drois.dk");
            command.Parameters.AddWithValue("@settings", "noget med settings");
            command.Parameters.AddWithValue("@preferences", "noget med preferences");

            return NonQuery(command, "accounts");
        }

        public int AddTwoTestAccount() {
            string sql = "INSERT INTO accounts(username, password, email, settings, preferences) VALUES (@username, @password, @email, @settings, @preferences), (@username, @password, @email, @settings, @preferences)";

            NpgsqlCommand command = new NpgsqlCommand(sql, conn);
            command.Parameters.AddWithValue("@username", "andrejas");
            command.Parameters.AddWithValue("@password", "drdrois");
            command.Parameters.AddWithValue("@email", "drois@drois.dk");
            command.Parameters.AddWithValue("@settings", "noget med settings");
            command.Parameters.AddWithValue("@preferences", "noget med preferences");

            return NonQuery(command, "accounts");
        }
        */
        public static void dbMassEntityInsert() {
            DBController dbc = new DBController();

            dbc.AddAccount(ModelDebug.GetTestAccount());
            dbc.AddIngredient(ModelDebug.GetTestIngredient());
            dbc.AddRetailer(ModelDebug.GetTestRetailer());
            dbc.AddRecipe(ModelDebug.GetTestRecipe());
            dbc.AddComment(ModelDebug.GetTestComment());

            dbc.Close();
        }

        public static void dbMassInsert() {
            DBController dbc = new DBController();

            dbc.AddAccount(ModelDebug.GetTestAccount());
            dbc.AddIngredient(ModelDebug.GetTestIngredient());
            dbc.AddRetailer(ModelDebug.GetTestRetailer());
            dbc.AddRecipe(ModelDebug.GetTestRecipe());
            dbc.AddComment(ModelDebug.GetTestComment());

            dbc.AddFavorises(ModelDebug.GetTestFavorises());
            dbc.AddHasEaten(ModelDebug.GetTestHasEaten());
            dbc.AddIngredientIn(ModelDebug.GetTestIngredientIn());
            dbc.AddOffers(ModelDebug.GetTestOffers());
            dbc.AddPictures(ModelDebug.GetTestPictures());

            dbc.Close();

        }

        public static void dbCountAllTables() {
            DBController dbc = new DBController();
            Console.WriteLine("Accounts: " + dbc.GetAllAccounts().Count);
            Console.WriteLine("Comments: " + dbc.GetAllComments().Count);
            Console.WriteLine("Ingredients: " + dbc.GetAllIngredients().Count);
            Console.WriteLine("Recipes: " + dbc.GetAllRecipes().Count);
            Console.WriteLine("Retailers: " + dbc.GetAllRetailers().Count);

            Console.WriteLine("Favorises: " + dbc.GetAllFavorises().Count);
            Console.WriteLine("HasEaten: " + dbc.GetAllHasEaten().Count);
            Console.WriteLine("IngredientIn: " + dbc.GetAllIngredientIn().Count);
            Console.WriteLine("Offers: " + dbc.GetAllOffers().Count);
            Console.WriteLine("Pictures: " + dbc.GetAllPictures().Count);
            dbc.Close();
        }
    }
}
