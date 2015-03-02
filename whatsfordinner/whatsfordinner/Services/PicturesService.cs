using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace whatsfordinner {
    public partial class RestService : IPictures {

        [WebInvoke(Method = "POST", UriTemplate = "AddPictures", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void AddPictures(Pictures pic) {
            DBController dbc = new DBController();
            dbc.AddPictures(pic);
            dbc.Close();
        }

        [WebInvoke(Method = "GET", UriTemplate = "GetPicturesByRecipeId?recipeId={recipeId}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public List<Pictures> GetPicturesByRecipeId(int recipeId) {
            DBController dbc = new DBController();
            List<Pictures> tempList = dbc.GetPicturesByRecipeId(recipeId);
            dbc.Close();
            return tempList;
        }

        
        [WebInvoke(Method = "DELETE", UriTemplate = "DeletePicByAccountIdAndRecipeId?accountId={accountId}&recipeId={recipeId}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void DeletePicByAccountIdAndRecipeId(int accountId, int recipeId) {
            DBController dbc = new DBController();
            dbc.DeletePictursByAccountIdAndRecipeId(accountId, recipeId);
            dbc.Close();
        }

    }
}
