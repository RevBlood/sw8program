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
    public partial class RestService : IFavorises {

        [WebInvoke(Method = "POST", UriTemplate = "AddFavorises", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void AddFavorises(Favorises fav) {
            DBController dbc = new DBController();
            try {
                dbc.AddFavorises(fav);
            } catch (NpgsqlException e) {
                Console.WriteLine((Program.sqlDebugMessages) ? "AddFavorises: " + e.BaseMessage.ToString() : "");
                WebOperationContext ctx = WebOperationContext.Current;
                ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.Conflict;
                ctx.OutgoingResponse.StatusDescription = e.BaseMessage;
            } finally {
                dbc.Close();
            }
        }

        [WebInvoke(Method = "GET", UriTemplate = "GetFavorisesByAccountId?accountId={accountId}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public List<Favorises> GetFavorisesByAccountId(int accountId) {
            DBController dbc = new DBController();
            WebOperationContext ctx = WebOperationContext.Current;
            try {
                List<Favorises> tempList = dbc.GetFavorisesByAccountId(accountId);
                if (tempList != null) {
                    return tempList;
                }
            } catch (NpgsqlException e) {
                Console.WriteLine((Program.sqlDebugMessages) ? "GetFavorisesByAccountId: " + e.BaseMessage.ToString() : "");
                ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.Conflict;
                ctx.OutgoingResponse.StatusDescription = e.BaseMessage;
                return null;
            } finally {
                dbc.Close();
            }
            ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.NoContent;
            return null;
        }

        [WebInvoke(Method = "GET", UriTemplate = "GetFavorisesByRecipeId?recipeId={recipeId}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public List<Favorises> GetFavorisesByRecipeId(int recipeId) {
            DBController dbc = new DBController();
            WebOperationContext ctx = WebOperationContext.Current;
            try {
                List<Favorises> tempList = dbc.GetFavorisesByRecipeId(recipeId);
                if (tempList != null) {
                    return tempList;
                }
            } catch (NpgsqlException e) {
                Console.WriteLine((Program.sqlDebugMessages) ? "GetFavorisesByRecipeId: " + e.BaseMessage.ToString() : "");
                ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.Conflict;
                ctx.OutgoingResponse.StatusDescription = e.BaseMessage;
                return null;
            } finally {
                dbc.Close();
            }
            ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.NoContent;
            return null;
        }

        [WebInvoke(Method = "GET", UriTemplate = "GetFavorisedRecipesByAccountId?accountId={accountId}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public List<Recipe> GetFavorisedRecipesByAccountId(int accountId) {
            DBController dbc = new DBController();
            WebOperationContext ctx = WebOperationContext.Current;
            try {
                List<Recipe> tempList = dbc.GetFavorisedRecipesByAccountId(accountId);
                if (tempList != null) {
                    return tempList;
                }
            } catch (NpgsqlException e) {
                Console.WriteLine((Program.sqlDebugMessages) ? "GetFavorisedRecipesByAccountId: " + e.BaseMessage.ToString() : "");
                ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.Conflict;
                ctx.OutgoingResponse.StatusDescription = e.BaseMessage;
                return null;
            } finally {
                dbc.Close();
            }
            ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.NoContent;
            return null;
        }

        [WebInvoke(Method = "DELETE", UriTemplate = "DeleteFavorisesByAccountIdAndRecipeId?accountId={accountId}&recipeId={recipeId}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public bool DeleteFavorisesByAccountIdAndRecipeId(int accountId, int recipeId) {
            DBController dbc = new DBController();
            WebOperationContext ctx = WebOperationContext.Current;
            try {
                bool deleted = dbc.DeleteFavorisesByAccountIdAndRecipeId(accountId, recipeId);
                if(deleted) {
                    return true;
                }
            } catch (NpgsqlException e) {
                Console.WriteLine((Program.sqlDebugMessages) ? "DeleteFavorisesByAccountIdAndRecipeId: " + e.BaseMessage.ToString() : "");
                ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.Conflict;
                ctx.OutgoingResponse.StatusDescription = e.BaseMessage;
                return false;
            } finally {
                dbc.Close();
            }

            ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.Gone;
            return false;
            

        }

    }
}
