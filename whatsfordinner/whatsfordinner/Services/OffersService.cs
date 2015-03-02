using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace whatsfordinner {
    public partial class RestService : IOffers {

        [WebInvoke(Method = "POST", UriTemplate = "AddOffers", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void AddOffers(Offers off) {
            DBController dbc = new DBController();
            dbc.AddOffers(off);
            dbc.Close();
        }

        [WebInvoke(Method = "GET", UriTemplate = "GetOffersByRetailerId?retailerId={retailerId}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public List<Offers> GetOffersByRetailerId(int retailerId) {
            DBController dbc = new DBController();
            List<Offers> tempList = dbc.GetOfferByRetailerId(retailerId);
            dbc.Close();
            return tempList;
        }

        [WebInvoke(Method = "GET", UriTemplate = "GetOffersByIngredientId?ingredientId={ingredientId}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public List<Offers> GetOffersByIngredientId(int ingredientId) {
            DBController dbc = new DBController();
            List<Offers> tempList = dbc.GetOfferByIngredientId(ingredientId);
            dbc.Close();
            return tempList;
        }

        [WebInvoke(Method = "DELETE", UriTemplate = "DeleteOffersByRetailerIdAndIngredientId?retailerId={retailerId}&ingredientId={ingredientId}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void DeleteOffersByRetailerIdAndIngredientId(int retailerId, int ingredientId) {
            DBController dbc = new DBController();
            dbc.DeletePictursByAccountIdAndRecipeId(retailerId, ingredientId);
            dbc.Close();
        }
    }
}
