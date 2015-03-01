using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace whatsfordinner {
    public partial class RestService : IRetailer {

        [WebInvoke(Method = "POST", UriTemplate = "AddRetailer", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void AddRetailer(Retailer ret) {
            DBController dbc = new DBController();
            dbc.AddRetailer(ret);
            dbc.Close();
        }

        [WebInvoke(Method = "GET", UriTemplate = "GetRetailerById?retId={retId}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public Retailer GetRetailerById(int retId) {
            DBController dbc = new DBController();
            Retailer tempRet = dbc.GetRetailerById(retId);
            dbc.Close();
            return tempRet;
        }

        [WebInvoke(Method = "GET", UriTemplate = "GetAllRetailers", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public List<Retailer> GetAllRetailers() {
            DBController dbc = new DBController();
            List<Retailer> tempList = dbc.GetAllRetailers();
            dbc.Close();
            return tempList;
        }

        [WebInvoke(Method = "DELETE", UriTemplate = "DeleteRetailerById?retId={retId}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void DeleteRetById(int retId) {
            DBController dbc = new DBController();
            dbc.DeleteRetailerById(retId);
            dbc.Close();
        }
    }
}
