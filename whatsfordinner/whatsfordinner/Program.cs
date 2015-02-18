using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whatsfordinner {
    class Program {
        static void Main(string[] args) {
            DBController dbc = new DBController();
            dbMassInsert();

            Console.WriteLine(dbc.GetAllAccounts().Count());
            Console.WriteLine(dbc.GetAllComments().Count());
            Console.WriteLine(dbc.GetAllIngredients().Count());
            Console.WriteLine(dbc.GetAllRecipes().Count());
            Console.WriteLine(dbc.GetAllRetailers().Count());


            dbc.Close();
            

            Console.WriteLine("Program Ended");
            Console.ReadLine();
        }


        static void dbControl() {
            DBController dbc = new DBController();
            List<Account> myList = dbc.GetAllAccounts();
            dbc.Close();
        }

        static void dbMassInsert() {
            DBController dbc = new DBController();

            dbc.AddAccount(ModelDebug.GetTestAccount());
            dbc.AddIngredient(ModelDebug.GetTestIngredient());
            dbc.AddRetailer(ModelDebug.GetTestRetailer());
            dbc.AddRecipe(ModelDebug.GetTestRecipe());
            dbc.AddComment(ModelDebug.GetTestComment());

            dbc.Close();

        }


    }
}
