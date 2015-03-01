using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace whatsfordinner {
    public partial class RestService : IComment {

        [WebInvoke(Method = "POST", UriTemplate = "AddComment", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void AddComment(Comment com) {
            DBController dbc = new DBController();
            dbc.AddComment(com);
            dbc.Close();
        }

        [WebInvoke(Method = "GET", UriTemplate = "GetCommentById?comId={comId}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public Comment GetCommentById(int comId) {
            DBController dbc = new DBController();
            Comment tempCom = dbc.GetCommentById(comId);
            dbc.Close();
            return tempCom;
        }

        [WebInvoke(Method = "GET", UriTemplate = "GetCommentsByRecipeId?recipeid={recipeId}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public List<Comment> GetCommentsByRecipeId(int recipeId) {
            DBController dbc = new DBController();
            List<Comment> tempList = dbc.GetCommentsByRecipeId(recipeId);
            dbc.Close();
            return tempList;
        }

        [WebInvoke(Method = "GET", UriTemplate = "GetAllComments", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public List<Comment> GetAllComments() {
            DBController dbc = new DBController();
            List<Comment> tempList = dbc.GetAllComments();
            dbc.Close();
            return tempList;
        }

        [WebInvoke(Method = "DELETE", UriTemplate = "DeleteCommentById?comId={comId}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void DeleteComById(int comId) {
            DBController dbc = new DBController();
            dbc.DeleteCommentById(comId);
            dbc.Close();
        }



    }
}
