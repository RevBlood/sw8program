using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using Npgsql;

namespace whatsfordinner {
    public partial class RestService : IIngredientIn {

        [WebInvoke(Method = "PUT", UriTemplate = "AddIngredientIn", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void AddIngredientIn(IngredientIn ing) {
            DBController dbc = new DBController();
            try {
                dbc.AddIngredientIn(ing);
            } catch (NpgsqlException e) {
                Console.WriteLine((Program.sqlDebugMessages) ? "AddIngredientIn: " + e.BaseMessage.ToString() : "");
                WebOperationContext ctx = WebOperationContext.Current;
                ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.Conflict;
                ctx.OutgoingResponse.StatusDescription = e.BaseMessage;
            } finally {
                dbc.Close();
            }
        }

        [WebInvoke(Method = "GET", UriTemplate = "GetIngredientsInByIngredientId?ingredientId={ingredientId}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public List<IngredientIn> GetIngredientInsByIngredientId(int ingredientId) {
            DBController dbc = new DBController();
            WebOperationContext ctx = WebOperationContext.Current;
            try {
                List<IngredientIn> tempList = dbc.GetIngredientInsByIngredientId(ingredientId);
                if (tempList != null) {
                    return tempList;
                }
            } catch (NpgsqlException e) {
                Console.WriteLine((Program.sqlDebugMessages) ? "GetIngredientsInByIngredientId: " + e.BaseMessage.ToString() : "");
                ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.Conflict;
                ctx.OutgoingResponse.StatusDescription = e.BaseMessage;
                return null;
            } finally {
                dbc.Close();
            }
            ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.NoContent;
            return null;
        }

        [WebInvoke(Method = "GET", UriTemplate = "GetIngredientsInByRecipeId?recipeId={recipeId}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public List<IngredientIn> GetIngredientInsByRecipeId(int recipeId) {
            DBController dbc = new DBController();
            WebOperationContext ctx = WebOperationContext.Current;
            try {
                List<IngredientIn> tempList = dbc.GetIngredientInsByRecipeId(recipeId);
                if (tempList != null) {
                    return tempList;
                }
            } catch (NpgsqlException e) {
                Console.WriteLine((Program.sqlDebugMessages) ? "GetIngredientsInByRecipeId: " + e.BaseMessage.ToString() : "");
                ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.Conflict;
                ctx.OutgoingResponse.StatusDescription = e.BaseMessage;
                return null;
            } finally {
                dbc.Close();
            }
            ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.NoContent;
            return null;
        }

        [WebInvoke(Method = "DELETE", UriTemplate = "DeleteIngredientInByIngredientIdAndRecipeId?ingredientId={ingredientId}&recipeId={recipeId}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void DeleteIngredientInByIngredientIdAndRecipeId(int ingredientId, int recipeId) {
            DBController dbc = new DBController();
            dbc.DeleteIngredientInByIngredientIdAndRecipeId(ingredientId, recipeId);
            dbc.Close();
        }

    }
}
