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
            Console.WriteLine("Starting Service...");
            startRestService();
            Console.WriteLine("Service Started...");
            Console.WriteLine("Program Ended");
            Console.ReadLine();
        }

        static void startRestService() {
            WebServiceHost host = new WebServiceHost(
                typeof(RestService),
                new Uri("http://localhost:8000/RestService")
                );
            host.AddServiceEndpoint(typeof(IAccount), new WebHttpBinding(), new Uri("http://localhost:8000/RestService/Account"));
            //host.AddServiceEndpoint(typeof(IEmployee), new WebHttpBinding(), new Uri("http://localhost:8000/RestService/Employee"));

            host.Open();


            foreach (ServiceEndpoint se in host.Description.Endpoints) {
                Console.WriteLine(string.Format("Binding name:{0}, Address:{1},Contract:{2}", se.Binding.Name, se.Address.ToString(), se.Contract.Name));
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
