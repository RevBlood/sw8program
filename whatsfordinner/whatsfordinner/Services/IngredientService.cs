using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace whatsfordinner {
    public partial class RestService : IIngredient {

        [WebInvoke(Method = "POST", UriTemplate = "AddIngredient", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void AddIngredient(Ingredient ing) {
            DBController dbc = new DBController();
            dbc.AddIngredient(ing);
            dbc.Close();
        }

        [WebInvoke(Method = "GET", UriTemplate = "GetIngredientById?ingId={ingId}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public Ingredient GetIngredientById(int ingId) {
            DBController dbc = new DBController();
            Ingredient tempIng = dbc.GetIngredientById(ingId);
            dbc.Close();
            return tempIng;
        }

        [WebInvoke(Method = "GET", UriTemplate = "GetIngredientByName?name={name}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public Ingredient GetIngredientByName(string name) {
            DBController dbc = new DBController();
            Ingredient tempIng = dbc.GetIngredientByName(name);
            dbc.Close();
            return tempIng;
        }

        [WebInvoke(Method = "GET", UriTemplate = "GetAllIngredients", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public List<Ingredient> GetAllIngredients() {
            DBController dbc = new DBController();
            List<Ingredient> tempList = dbc.GetAllIngredients();
            dbc.Close();
            return tempList;
        }

        [WebInvoke(Method = "GET", UriTemplate = "GetIngredientsByRecipeId?recipeId={recipeId}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public List<Ingredient> GetIngredientsByRecipeId(int recipeId) {
            DBController dbc = new DBController();
            List<Ingredient> tempList = dbc.GetIngredientsByRecipeId(recipeId);
            dbc.Close();
            return tempList;
        }

        [WebInvoke(Method = "DELETE", UriTemplate = "DeleteIngredientById?ingId={ingId}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void DeleteIngById(int ingId) {
            DBController dbc = new DBController();
            dbc.DeleteIngredientById(ingId);
            dbc.Close();
        }



    }
}
