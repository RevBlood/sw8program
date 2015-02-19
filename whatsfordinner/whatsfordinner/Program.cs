using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whatsfordinner {
    class Program {
        static void Main(string[] args) {
            


            Console.WriteLine("Program Ended");
            Console.ReadLine();
        }
        static void dbstuff() {
            DBController dbc = new DBController();
            DBDebug.dbMassEntityInsert();
            DBDebug.dbCountAllTables();
            dbc.Close();
        }

        static void jsonstuff() {
            JSONDebug.JSONAccountDebug(ModelDebug.GetTestAccount());
            JSONDebug.JSONCommentDebug(ModelDebug.GetTestComment());
            JSONDebug.JSONIngredientDebug(ModelDebug.GetTestIngredient());
            JSONDebug.JSONRecipeDebug(ModelDebug.GetTestRecipe());
            JSONDebug.JSONRetailerDebug(ModelDebug.GetTestRetailer());

            JSONDebug.JSONFavorisesDebug(ModelDebug.GetTestFavorises());
            JSONDebug.JSONHasEatenDebug(ModelDebug.GetTestHasEaten());
            JSONDebug.JSONIngredientInDebug(ModelDebug.GetTestIngredientIn());
            JSONDebug.JSONOffersDebug(ModelDebug.GetTestOffers());
            JSONDebug.JSONPicturesDebug(ModelDebug.GetTestPictures());
        }
    }
}
