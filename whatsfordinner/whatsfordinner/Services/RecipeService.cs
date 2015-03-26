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
    public partial class RestService : IRecipe {

        [WebInvoke(Method = "POST", UriTemplate = "AddRecipe", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void AddRecipe(Recipe rec) {
            DBController dbc = new DBController();
            try {
                dbc.AddRecipe(rec);
            } catch (NpgsqlException e) {
                Console.WriteLine((Program.sqlDebugMessages) ? "AddRecipe: " + e.BaseMessage.ToString() : "");
                WebOperationContext ctx = WebOperationContext.Current;
                ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.Conflict;
                ctx.OutgoingResponse.StatusDescription = e.BaseMessage;
            } finally {
                dbc.Close();
            }
        }

        [WebInvoke(Method = "GET", UriTemplate = "GetRecipeById?recipeId={recipeId}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public Recipe GetRecipeById(int recipeId) {
            DBController dbc = new DBController();
            WebOperationContext ctx = WebOperationContext.Current;
            try {
                Recipe tempRec = dbc.GetRecipeById(recipeId);
                if (tempRec != null) {
                    return tempRec;
                }
            } catch (NpgsqlException e) {
                Console.WriteLine((Program.sqlDebugMessages) ? "GetRecipeById: " + e.BaseMessage.ToString() : "");
                ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.Conflict;
                ctx.OutgoingResponse.StatusDescription = e.BaseMessage;
                return null;
            } finally {
                dbc.Close();
            }
            ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.NoContent;
            return null;
        }

        [WebInvoke(Method = "GET", UriTemplate = "GetRecipeByAccountId?accountId={accountId}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public List<Recipe> GetRecipesByAccountId(int accountId) {
            DBController dbc = new DBController();
            WebOperationContext ctx = WebOperationContext.Current;
            try {
                List<Recipe> tempList = dbc.GetRecipesByAccountId(accountId);
                if (tempList != null) {
                    return tempList;
                }
            } catch (NpgsqlException e) {
                Console.WriteLine((Program.sqlDebugMessages) ? "GetRecipeByAccountId: " + e.BaseMessage.ToString() : "");
                ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.Conflict;
                ctx.OutgoingResponse.StatusDescription = e.BaseMessage;
                return null;
            } finally {
                dbc.Close();
            }
            ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.NoContent;
            return null;
        }

        [WebInvoke(Method = "GET", UriTemplate = "GetRecipesByIngredientId?ingredientId={ingredientId}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public List<Recipe> GetRecipesByIngredientId(int ingredientId) {
            DBController dbc = new DBController();
            WebOperationContext ctx = WebOperationContext.Current;
            try {
                List<Recipe> tempList = dbc.GetRecipesByIngredientId(ingredientId);
                if (tempList != null) {
                    return tempList;
                }
            } catch (NpgsqlException e) {
                Console.WriteLine((Program.sqlDebugMessages) ? "GetRecipesByIngredientId: " + e.BaseMessage.ToString() : "");
                ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.Conflict;
                ctx.OutgoingResponse.StatusDescription = e.BaseMessage;
                return null;
            } finally {
                dbc.Close();
            }
            ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.NoContent;
            return null;
        }

        [WebInvoke(Method = "GET", UriTemplate = "GetRecipesByIdWithIngredients?recipeId={recipeId}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public RecipeWithIngredients GetRecipesByIdWithIngredients(int recipeId) {
            DBController dbc = new DBController();
            WebOperationContext ctx = WebOperationContext.Current;
            try {
                RecipeWithIngredients tempRec = dbc.GetRecipeByIdWithIngredients(recipeId);
                if (tempRec != null) {
                    return tempRec;
                }
            } catch (NpgsqlException e) {
                Console.WriteLine((Program.sqlDebugMessages) ? "GetRecipesByIdWithIngredients: " + e.BaseMessage.ToString() : "");
                ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.Conflict;
                ctx.OutgoingResponse.StatusDescription = e.BaseMessage;
                return null;
            } finally {
                dbc.Close();
            }
            ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.NoContent;
            return null;
        }

        [WebInvoke(Method = "GET", UriTemplate = "GetAllRecipes", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public List<Recipe> GetAllRecipes() {
            DBController dbc = new DBController();
            WebOperationContext ctx = WebOperationContext.Current;
            try {
                List<Recipe> tempList = dbc.GetAllRecipes();
                if (tempList != null) {
                    return tempList;
                }
            } catch (NpgsqlException e) {
                Console.WriteLine((Program.sqlDebugMessages) ? "GetAllRecipes: " + e.BaseMessage.ToString() : "");
                ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.Conflict;
                ctx.OutgoingResponse.StatusDescription = e.BaseMessage;
                return null;
            } finally {
                dbc.Close();
            }
            ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.NoContent;
            return null;
        }

        [WebInvoke(Method = "DELETE", UriTemplate = "DeleteRecipeById?recipeId={recipeId}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public bool DeleteRecById(int recipeId) {
            DBController dbc = new DBController();
            dbc.DeleteRecipeById(recipeId);
            dbc.Close();

            return true;
        }
    }
}
