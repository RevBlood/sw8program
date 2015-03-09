using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace WebService {
    [DataContract]
    public class Employee {
        public Employee(string id, string name, string address) {
            this.EmpID = id;
            this.Name = name;
            this.Address = address;
        }
        [DataMember]
        public string EmpID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Address { get; set; }
    }
}
