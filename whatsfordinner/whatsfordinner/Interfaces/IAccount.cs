using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace whatsfordinner {
    [ServiceContract]
    public interface IAccount {
        [OperationContract]
        void AddAccount(Account acc);
        [OperationContract]
        Account GetAccountByUsername(string username);
        [OperationContract]
        void GetAllAccounts();
        [OperationContract]
        void DeleteAccById(int accId);
    }
}
