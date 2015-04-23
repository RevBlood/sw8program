using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ServiceModel.Description;
using System.Net;
using System.Net.Sockets;

using Newtonsoft.Json;

namespace whatsfordinner {
    public class Program {
        public static bool sqlDebugMessages = true;

        static void Main(string[] args) {

            Script.ExcelExtractionScript();
            UpdateDatabaseWithOffers();

            IngredientIdentifier.Identify();
            
            //DBDebug.dbMassInsert();
            Console.WriteLine("Starting Service...");
            //startRestService();
            
            //Script.ExcelExtractionScript();
            Console.WriteLine("Program Ended");
			while (true) {
			}

            Console.ReadLine();
        }

        static void startRestService() {
            string localIP = "?";
            IPHostEntry myHost = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in myHost.AddressList) {
                if (ip.AddressFamily == AddressFamily.InterNetwork) {
                    localIP = ip.ToString();
                }
            }

            //Uri uri = new Uri("http://192.168.1.206:8000/RestService");
            //Uri uri = new Uri("http://localhost:8000/RestService");
            Uri uri = new Uri("http://" + localIP + ":8000/RestService");
            WebServiceHost host = new WebServiceHost(typeof(RestService), uri);
            host.AddServiceEndpoint(typeof(IAccount), new WebHttpBinding(), new Uri(uri + "/Account"));
            host.AddServiceEndpoint(typeof(IComment), new WebHttpBinding(), new Uri(uri + "/Comment"));
            host.AddServiceEndpoint(typeof(IIngredient), new WebHttpBinding(), new Uri(uri + "/Ingredient"));
            host.AddServiceEndpoint(typeof(IRecipe), new WebHttpBinding(), new Uri(uri + "/Recipe"));
            host.AddServiceEndpoint(typeof(IRetailer), new WebHttpBinding(), new Uri(uri + "/Retailer"));
            host.AddServiceEndpoint(typeof(IFavorises), new WebHttpBinding(), new Uri(uri + "/Favorises"));
            host.AddServiceEndpoint(typeof(IHasEaten), new WebHttpBinding(), new Uri(uri + "/HasEaten"));
            host.AddServiceEndpoint(typeof(IIngredientIn), new WebHttpBinding(), new Uri(uri + "/IngredientIn"));
            host.AddServiceEndpoint(typeof(IOffers), new WebHttpBinding(), new Uri(uri + "/Offers"));
            host.AddServiceEndpoint(typeof(IPictures), new WebHttpBinding(), new Uri(uri + "/Pictures"));
            host.AddServiceEndpoint(typeof(ILogin), new WebHttpBinding(), new Uri(uri + "/Login"));
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

        static void UpdateDatabaseWithOffers() {

            // This part is for updating local files with new Offers from eTilbudsAvisen

            /*
            eTilbudRetriever retriever = new eTilbudRetriever();
            FileManager.write("Dealers", retriever.GetDealersList());
            FileManager.write("Stores", retriever.GetStoresList());
            FileManager.write("Offers", retriever.GetOffersList());
            */

            // Read local files retrieved from eTilbudsAvisen
            List<String> dealerData = FileManager.read("Dealers");
            List<String> storeData = FileManager.read("Stores");
            List<String> offerData = FileManager.read("Offers");

            // Store all data in lists of matching classes
            List<Dealer> dealers = new List<Dealer>();
            List<Store> stores = new List<Store>();
            List<Offer> offers = new List<Offer>();

            foreach (String line in dealerData) {
                dealers.AddRange(JsonConvert.DeserializeObject<List<Dealer>>(line));
            };


            foreach (String line in storeData) {
                stores.AddRange(JsonConvert.DeserializeObject<List<Store>>(line));
            };


            foreach (String line in offerData) {
                offers.AddRange(JsonConvert.DeserializeObject<List<Offer>>(line));
            };

            // Fix the date format in offers to match a supported format (Inserts a colon)
            foreach (Offer offer in offers) {
                offer.run_from = offer.run_from.Insert(offer.run_from.IndexOf('+') + 3, ":");
                offer.run_till = offer.run_till.Insert(offer.run_till.IndexOf('+') + 3, ":");
            }

            // Convert eTilbud classes to classes recognized by the database - Then save them
            eTilbudDatabaseHandler handler = new eTilbudDatabaseHandler();
            handler.save(dealers, stores, offers);
        }
    }
}
