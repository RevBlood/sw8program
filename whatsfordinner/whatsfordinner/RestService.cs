using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace whatsfordinner {
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, AddressFilterMode = AddressFilterMode.Any)]
    public class RestService : IAccount {

        List<Account> accList = null;
        public RestService() {
            if (accList == null) {
                accList = new List<Account>();
                DateTime dt = DateTime.Now;
                accList.Add(new Account("andrejs", "andrejspw", "andrejs@andrejs.com", dt, "noget med setting", "noget med preferences"));
                Console.WriteLine(accList.Count());
            }
        }

        [WebInvoke(Method = "POST", UriTemplate = "AddAccount", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void AddAccount(Account acc) {
            accList.Add(acc);
            Console.WriteLine(acc.ToString());
            Console.WriteLine(accList.Count.ToString());
        }

        [WebInvoke(Method = "GET", UriTemplate = "GetAccountByUsername?username={username}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public Account GetAccountByUsername(string username) {
            List<Account> tempList = new List<Account>();
            foreach (Account acc in accList) {
                if (acc.GetOrSetUsername == username) {
                    tempList.Add(acc);
                }
            }

            return tempList.First();
        }

        public void GetAllAccounts() {
            throw new NotImplementedException();
        }

        public void DeleteAccById(int accId) {
            throw new NotImplementedException();
        }
    }
}
