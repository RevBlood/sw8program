using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace whatsfordinner {
    [DataContract]
    class Retailer {
        // Contains:
        // Retailer CompanyName
        // Retailer Description

        // Here to use JSON Deserialize
        public Retailer() { }

        public Retailer(DataRow row) {
            this.GetOrSetCompanyName = row.Field<string>("companyname");
            this.GetOrSetDescription = row.Field<string>("description");
        }

        public Retailer(string retailerCompanyName, string retailerDescription) {
            this.GetOrSetCompanyName = retailerCompanyName;
            this.GetOrSetDescription = retailerDescription;
        }

        [DataMember(Name = "companyname")]
        public string GetOrSetCompanyName {
            get {
                return _retailerCompanyName;
            }
            set {
                _retailerCompanyName = value;
            }
        }
        private string _retailerCompanyName;

        [DataMember(Name = "description")]
        public string GetOrSetDescription {
            get {
                return _retailerDescription;
            }
            set {
                _retailerDescription = value;
            }
        }
        private string _retailerDescription;

        public override string ToString() {
            return this.GetOrSetCompanyName
            + " " + this.GetOrSetDescription;
        }
    }
}
