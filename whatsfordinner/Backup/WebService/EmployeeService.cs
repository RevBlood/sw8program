using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using whatsfordinner;

namespace WebService {
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, AddressFilterMode = AddressFilterMode.Any)]
    public class EmployeeService: IEmployee {
        List<Employee> empList = null;
        public EmployeeService() {
            if (empList == null) {
                empList = new List<Employee>();
                empList.Add(new Employee("1", "Ramana", "nrsundby"));
            }
        }

        [WebInvoke(Method = "POST", UriTemplate = "AddEmployee", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void AddEmployee(Employee emp) {
            empList.Add(emp);
            Console.WriteLine(emp);
            Console.WriteLine(empList.Count.ToString());
        }

        [WebInvoke(Method = "GET", UriTemplate = "GetEmployeesByName?name={name}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public Employee GetEmployeesByName(string name) {
            List<Employee> tempList = new List<Employee>();
            foreach (Employee emp in empList) {
                if (emp.Name == name) {
                    tempList.Add(emp);
                }
            }

            return tempList.First();
        }   

        public void DeleteEmpById(string empId) {
            empList.Remove(empList.Find(a => a.EmpID.Equals(empId)));
        }

        [WebInvoke(Method = "GET", UriTemplate = "GetStuff", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public string GetStuff() {

            int x = 1;
            //string acc = "{\"hello\":\"json\"}";
            //whatsfordinner.Account acc = whatsfordinner.ModelDebug.GetTestAccount();
            //return whatsfordinner.JSONHelper.Serialize<whatsfordinner.Account>(acc);

            Employee emp = empList.First();
            return emp.Name;



            //return "{\"test\":\"cmon\"}";
            //return acc;
        }
    }
}
