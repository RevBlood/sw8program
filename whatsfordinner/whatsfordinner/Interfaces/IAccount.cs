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
        Account GetAccountById(int accountId);
        [OperationContract]
        Account GetAccountByEmail(string email);
        [OperationContract]
        List<Account> GetAllAccounts();
        [OperationContract]
        void DeleteAccById(int accountId);
    }
}
