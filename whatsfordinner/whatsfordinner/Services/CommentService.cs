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
    public partial class RestService : IComment {

        [WebInvoke(Method = "PUT", UriTemplate = "AddComment", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void AddComment(Comment com) {
            DBController dbc = new DBController();
            try {
                dbc.AddComment(com);
            } catch (NpgsqlException e) {
                Console.WriteLine((Program.sqlDebugMessages) ? "AddComment: " + e.BaseMessage.ToString() : "");
                WebOperationContext ctx = WebOperationContext.Current;
                ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.Conflict;
                ctx.OutgoingResponse.StatusDescription = e.BaseMessage;
            } finally {
                dbc.Close();
            }
        }

        [WebInvoke(Method = "GET", UriTemplate = "GetCommentById?commentId={commentId}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public Comment GetCommentById(int commentId) {
            DBController dbc = new DBController();
            WebOperationContext ctx = WebOperationContext.Current;
            try {
                Comment tempCom = dbc.GetCommentById(commentId);
                if (tempCom != null) {
                    return tempCom;
                }
            } catch (NpgsqlException e) {
                Console.WriteLine((Program.sqlDebugMessages) ? "GetCommentById: " + e.BaseMessage.ToString() : "");
                ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.Conflict;
                ctx.OutgoingResponse.StatusDescription = e.BaseMessage;
                return null;
            } finally {
                dbc.Close();
            }
            ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.NoContent;
            return null;
        }

        [WebInvoke(Method = "GET", UriTemplate = "GetCommentsByRecipeId?recipeid={recipeId}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public List<Comment> GetCommentsByRecipeId(int recipeId) {
            DBController dbc = new DBController();
            WebOperationContext ctx = WebOperationContext.Current;
            try {
                List<Comment> tempList = dbc.GetCommentsByRecipeId(recipeId);
                if (tempList != null) {
                    return tempList;
                }
            } catch (NpgsqlException e) {
                Console.WriteLine((Program.sqlDebugMessages) ? "GetCommentsByRecipeId: " + e.BaseMessage.ToString() : "");
                ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.Conflict;
                ctx.OutgoingResponse.StatusDescription = e.BaseMessage;
                return null;
            } finally {
                dbc.Close();
            }
            ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.NoContent;
            return null;
        }

        [WebInvoke(Method = "GET", UriTemplate = "GetAllComments", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public List<Comment> GetAllComments() {
            DBController dbc = new DBController();
            WebOperationContext ctx = WebOperationContext.Current;
            try {
                List<Comment> tempList = dbc.GetAllComments();
                if (tempList != null) {
                    return tempList;
                }
            } catch (NpgsqlException e) {
                Console.WriteLine((Program.sqlDebugMessages) ? "GetAllComments: " + e.BaseMessage.ToString() : "");
                ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.Conflict;
                ctx.OutgoingResponse.StatusDescription = e.BaseMessage;
                return null;
            } finally {
                dbc.Close();
            }
            ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.NoContent;
            return null;
        }

        [WebInvoke(Method = "DELETE", UriTemplate = "DeleteCommentById?commentId={commentId}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void DeleteComById(int commentId) {
            DBController dbc = new DBController();
            dbc.DeleteCommentById(commentId);
            dbc.Close();
        }
    }
}
