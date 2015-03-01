using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace WebService {
    [ServiceContract]
    public interface IEmployee {
        [OperationContract]
        void AddEmployee(Employee emp);
        [OperationContract]
        Employee GetEmployeesByName(string name);
        [OperationContract]
        void DeleteEmpById(string empId);
        [OperationContract]
        string GetStuff();
    }
}
