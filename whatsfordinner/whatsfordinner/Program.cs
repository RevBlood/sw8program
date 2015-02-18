using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whatsfordinner {
    class Program {
        static void Main(string[] args) {

            Account myacc = ModelDebug.GetTestAccount(); 
            string acc = JSONHelper.Serialize<Account>(myacc);
            Console.WriteLine(acc);

            Account backToAcc = JSONHelper.Deserialize<Account>(acc);
            Console.WriteLine(backToAcc.ToString());

            Console.WriteLine("Program Ended");
            Console.ReadLine();
        }


        static void dbControl() {
            DBController dbc = new DBController();
            List<Account> myList = dbc.GetAllAccounts();
            dbc.Close();
        }


    }
}
