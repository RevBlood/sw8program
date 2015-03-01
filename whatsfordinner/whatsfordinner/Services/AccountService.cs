using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace whatsfordinner {
    public partial class RestService : IAccount {

        [WebInvoke(Method = "POST", UriTemplate = "AddAccount", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void AddAccount(Account acc) {
            DBController dbc = new DBController();
            dbc.AddAccount(acc);
            dbc.Close();
        }

        [WebInvoke(Method = "GET", UriTemplate = "GetAccountById?accId={accId}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public Account GetAccountById(int accId) {
            DBController dbc = new DBController();
            Account tempAcc = dbc.GetAccountById(accId);
            dbc.Close();
            return tempAcc;
        }

        [WebInvoke(Method = "GET", UriTemplate = "GetAccountByUsername?username={username}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public Account GetAccountByUsername(string username) {
            DBController dbc = new DBController();
            Account tempAcc = dbc.GetAccountByUsername(username);
            dbc.Close();
            return tempAcc;
        }

        [WebInvoke(Method = "GET", UriTemplate = "GetAllAccounts", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public List<Account> GetAllAccounts() {
            DBController dbc = new DBController();
            List<Account> tempList = dbc.GetAllAccounts();
            dbc.Close();
            return tempList;
        }

        [WebInvoke(Method = "DELETE", UriTemplate = "DeleteAccountById?accId={accId}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void DeleteAccById(int accId) {
            DBController dbc = new DBController();
            dbc.DeleteAccountById(accId);
            dbc.Close();
        }
    }
}
