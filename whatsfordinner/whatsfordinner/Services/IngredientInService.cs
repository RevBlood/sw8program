using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace whatsfordinner {
    public partial class RestService : IIngredientIn {

        [WebInvoke(Method = "POST", UriTemplate = "AddIngredientIn", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void AddIngredientIn(IngredientIn ing) {
            DBController dbc = new DBController();
            dbc.AddIngredientIn(ing);
            dbc.Close();
        }

        [WebInvoke(Method = "GET", UriTemplate = "GetIngredientsInByIngredientId?ingredientId={ingredientId}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public List<IngredientIn> GetIngredientInsByIngredientId(int ingredientId) {
            DBController dbc = new DBController();
            List<IngredientIn> tempList = dbc.GetIngredientInsByIngredientId(ingredientId);
            dbc.Close();
            return tempList;
        }

        [WebInvoke(Method = "GET", UriTemplate = "GetIngredientsInByRecipeId?recipeId={recipeId}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public List<IngredientIn> GetIngredientInsByRecipeId(int recipeId) {
            DBController dbc = new DBController();
            List<IngredientIn> tempList = dbc.GetIngredientInsByRecipeId(recipeId);
            dbc.Close();
            return tempList;
        }

        
        [WebInvoke(Method = "DELETE", UriTemplate = "DeleteIngredientInByIngredientIdAndRecipeId?ingredientId={ingredientId}&recipeId={recipeId}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void DeleteIngredientInByIngredientIdAndRecipeId(int ingredientId, int recipeId) {
            DBController dbc = new DBController();
            dbc.DeleteIngredientInByIngredientIdAndRecipeId(ingredientId, recipeId);
            dbc.Close();
        }

    }
}
