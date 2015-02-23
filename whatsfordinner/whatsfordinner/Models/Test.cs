using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace whatsfordinner {
    [DataContract]
    public class Test {
        public Test() { }

        public Test(string fetchTest) {
            this.GetTest = fetchTest;
        }

        [DataMember(Name = "test")]
        public string GetTest {
            get {
                return _test;
            }
            set {
                _test = value;
            }
        }
        private string _test = "not set";
    }
}
