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
    public partial class RestService : IRetailer {

        [WebInvoke(Method = "POST", UriTemplate = "AddRetailer", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void AddRetailer(Retailer ret) {
            DBController dbc = new DBController();
            try {
                dbc.AddRetailer(ret);
            } catch (NpgsqlException e) {
                Console.WriteLine((Program.sqlDebugMessages) ? "AddRetailer: " + e.BaseMessage.ToString() : "");
                WebOperationContext ctx = WebOperationContext.Current;
                ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.Conflict;
                ctx.OutgoingResponse.StatusDescription = e.BaseMessage;
            } finally {
                dbc.Close();
            }
        }

        [WebInvoke(Method = "GET", UriTemplate = "GetRetailerById?retailerId={retailerId}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public Retailer GetRetailerById(int retailerId) {
            DBController dbc = new DBController();
            WebOperationContext ctx = WebOperationContext.Current;
            try {
                Retailer tempRet = dbc.GetRetailerById(retailerId);
                if (tempRet != null) {
                    return tempRet;
                }
            } catch (NpgsqlException e) {
                Console.WriteLine((Program.sqlDebugMessages) ? "GetRetailerById: " + e.BaseMessage.ToString() : "");
                ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.Conflict;
                ctx.OutgoingResponse.StatusDescription = e.BaseMessage;
                return null;
            } finally {
                dbc.Close();
            }
            ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.NoContent;
            return null;
        }

        [WebInvoke(Method = "GET", UriTemplate = "GetAllRetailers", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public List<Retailer> GetAllRetailers() {
            DBController dbc = new DBController();
            WebOperationContext ctx = WebOperationContext.Current;
            try {
                List<Retailer> tempList = dbc.GetAllRetailers();
                if (tempList != null) {
                    return tempList;
                }
            } catch (NpgsqlException e) {
                Console.WriteLine((Program.sqlDebugMessages) ? "GetAllRetailers : " + e.BaseMessage.ToString() : "");
                ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.Conflict;
                ctx.OutgoingResponse.StatusDescription = e.BaseMessage;
            } finally {
                dbc.Close();
            }
            ctx.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.NoContent;
            return null;
        }

        [WebInvoke(Method = "DELETE", UriTemplate = "DeleteRetailerById?retailerId={retailerId}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public bool DeleteRetById(int retailerId) {
            DBController dbc = new DBController();
            dbc.DeleteRetailerById(retailerId);
            dbc.Close();

            return true;
        }
    }
}
