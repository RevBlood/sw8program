using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Web;
using WebService;
using whatsfordinner;
using System.ServiceModel.Description;

namespace Host {
    class Program {
        static void Main(string[] args) {
            /*
            WebServiceHost host = new WebServiceHost(
                typeof(AccountService),
                new Uri("http://localhost:8000")
                );
            var binding = new WebHttpBinding();
            host.AddServiceEndpoint(typeof(IAccount), binding, new Uri("http://localhost:8000/RestService"));
            host.AddServiceEndpoint(typeof(IEmployee), binding, new Uri("http://localhost:8000/RestService"));
            */
            
            WebServiceHost host = new WebServiceHost(
                typeof(WebService.RestService),
                new Uri("http://localhost:8000/RestService")
                );
            host.AddServiceEndpoint(typeof(IAccount), new WebHttpBinding(), new Uri("http://localhost:8000/RestService/Account"));
            host.AddServiceEndpoint(typeof(IEmployee), new WebHttpBinding(), new Uri("http://localhost:8000/RestService/Employee"));
            
            host.Open();


            foreach (ServiceEndpoint se in host.Description.Endpoints) {
                Console.WriteLine(string.Format("Binding name:{0}, Address:{1},Contract:{2}", se.Binding.Name, se.Address.ToString(), se.Contract.Name));
            }
            Console.ReadLine();
            host.Close();
            
        }
    }
}
