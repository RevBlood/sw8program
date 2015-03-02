using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace whatsfordinner {
    public partial class RestService : IRecipe {

        [WebInvoke(Method = "POST", UriTemplate = "AddRecipe", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void AddRecipe(Recipe rec) {
            DBController dbc = new DBController();
            dbc.AddRecipe(rec);
            dbc.Close();
        }

        [WebInvoke(Method = "GET", UriTemplate = "GetRecipeById?recId={recId}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public Recipe GetRecipeById(int recId) {
            DBController dbc = new DBController();
            Recipe tempRec = dbc.GetRecipeById(recId);
            dbc.Close();
            return tempRec;
        }

        [WebInvoke(Method = "GET", UriTemplate = "GetRecipeByAccountId?accountId={accountId}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public List<Recipe> GetRecipesByAccountId(int accountId) {
            DBController dbc = new DBController();
            List<Recipe> tempList = dbc.GetRecipesByAccountId(accountId);
            dbc.Close();
            return tempList;
        }

        [WebInvoke(Method = "GET", UriTemplate = "GetRecipesByIngredientId?ingredientId={ingredientId}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public List<Recipe> GetRecipesByIngredientId(int ingredientId) {
            DBController dbc = new DBController();
            List<Recipe> tempList = dbc.GetRecipesByIngredientId(ingredientId);
            dbc.Close();
            return tempList;
        }

        [WebInvoke(Method = "GET", UriTemplate = "GetRecipesByIdWithIngredients?recId={recId}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public RecipeWithIngredients GetRecipesByIdWithIngredients(int recId) {
            DBController dbc = new DBController();
            RecipeWithIngredients tempRec = dbc.GetRecipeByIdWithIngredients(recId);
            dbc.Close();
            return tempRec;
        }

        [WebInvoke(Method = "GET", UriTemplate = "GetAllRecipes", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public List<Recipe> GetAllRecipes() {
            DBController dbc = new DBController();
            List<Recipe> tempList = dbc.GetAllRecipes();
            dbc.Close();
            return tempList;
        }

        [WebInvoke(Method = "DELETE", UriTemplate = "DeleteRecipeById?recId={recId}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void DeleteRecById(int recId) {
            DBController dbc = new DBController();
            dbc.DeleteRecipeById(recId);
            dbc.Close();
        }



    }
}
