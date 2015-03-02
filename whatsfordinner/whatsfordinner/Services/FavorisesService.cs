using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace whatsfordinner {
    public partial class RestService : IFavorises {

        [WebInvoke(Method = "POST", UriTemplate = "AddFavorises", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void AddFavorises(Favorises fav) {
            DBController dbc = new DBController();
            dbc.AddFavorises(fav);
            dbc.Close();
        }

        [WebInvoke(Method = "GET", UriTemplate = "GetFavorisesByAccountId?accountId={accountId}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public List<Favorises> GetFavorisesByAccountId(int accountId) {
            DBController dbc = new DBController();
            List<Favorises> tempList = dbc.GetFavorisesByAccountId(accountId);
            dbc.Close();
            return tempList;
        }

        [WebInvoke(Method = "GET", UriTemplate = "GetFavorisesByRecipeId?recipeId={recipeId}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public List<Favorises> GetFavorisesByRecipeId(int recipeId) {
            DBController dbc = new DBController();
            List<Favorises> tempList = dbc.GetFavorisesByAccountId(recipeId);
            dbc.Close();
            return tempList;
        }

        
        [WebInvoke(Method = "DELETE", UriTemplate = "DeleteFavorisesByAccountIdAndRecipeId?accountId={accountId}&recipeId={recipeId}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void DeleteFavorisesByAccountIdAndRecipeId(int accountId, int recipeId) {
            DBController dbc = new DBController();
            dbc.DeleteFavorisesByAccountIdAndRecipeId(accountId, recipeId);
            dbc.Close();
        }

    }
}
