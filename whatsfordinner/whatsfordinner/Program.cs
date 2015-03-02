using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ServiceModel.Description;

namespace whatsfordinner {
    public class Program {
        static void Main(string[] args) {
            DBController dbc = new DBController();
            /*
            Account testAcc = ModelDebug.GetTestAccount();
            testAcc.GetOrSetUsername = "Peter";
            dbc.AddAccount(testAcc);


            List<Account> allAccs = dbc.GetAllAccounts();
            foreach (Account acc in allAccs) {
                Console.WriteLine(acc.ToString());
            }
            */

            //dbc.DeleteAccountById(3);
            dbc.Close();
            Console.WriteLine("Starting Service...");
            startRestService();
            Console.WriteLine("Program Ended");
            Console.ReadLine();
        }

        static void startRestService() {
            WebServiceHost host = new WebServiceHost(
                typeof(RestService),
                new Uri("http://localhost:8000/RestService")
                );
            host.AddServiceEndpoint(typeof(IAccount), new WebHttpBinding(), new Uri("http://localhost:8000/RestService/Account"));
            host.AddServiceEndpoint(typeof(IComment), new WebHttpBinding(), new Uri("http://localhost:8000/RestService/Comment"));
            host.AddServiceEndpoint(typeof(IIngredient), new WebHttpBinding(), new Uri("http://localhost:8000/RestService/Ingredient"));
            host.AddServiceEndpoint(typeof(IRecipe), new WebHttpBinding(), new Uri("http://localhost:8000/RestService/Recipe"));
            host.AddServiceEndpoint(typeof(IRetailer), new WebHttpBinding(), new Uri("http://localhost:8000/RestService/Retailer"));
            host.AddServiceEndpoint(typeof(IFavorises), new WebHttpBinding(), new Uri("http://localhost:8000/RestService/Favorises"));
            host.AddServiceEndpoint(typeof(IHasEaten), new WebHttpBinding(), new Uri("http://localhost:8000/RestService/HasEaten"));
            host.AddServiceEndpoint(typeof(IIngredientIn), new WebHttpBinding(), new Uri("http://localhost:8000/RestService/IngredientIn"));
            host.AddServiceEndpoint(typeof(IOffers), new WebHttpBinding(), new Uri("http://localhost:8000/RestService/Offers"));
            host.AddServiceEndpoint(typeof(IPictures), new WebHttpBinding(), new Uri("http://localhost:8000/RestService/Pictures"));
            host.Open();


            foreach (ServiceEndpoint se in host.Description.Endpoints) {
                Console.WriteLine(string.Format("Binding name:{0}, Address:{1}, Contract:{2}", se.Binding.Name, se.Address.ToString(), se.Contract.Name));
            }
            Console.ReadLine();
            host.Close();
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
