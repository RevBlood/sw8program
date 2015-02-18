using System;
using System.Collections.Generic;
using Npgsql;
using System.Data;
using Microsoft.Win32.SafeHandles;
using System.Configuration;



namespace whatsfordinner {
    class DBDebug {
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();
        private NpgsqlConnection conn;

        private static string dbHost = "localhost";
        private static string dbName = "testDB";
        //		private static string dbName = "CornfieldDB";
        private static string dbUser = "casper";
        private static string dbPass = "1234";

        public DBDebug() {
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
    }
}
