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
            this.GetOrSetId = row.Field<int>("retailerid");
            this.GetOrSetLatitude = row.Field<string>("latitude");
            this.GetOrSetLongitude = row.Field<string>("longitude");
            this.GetOrSetCompanyName = row.Field<string>("companyname");
            this.GetOrSetDescription = row.Field<string>("description");
            this.GetOrSetOpeningHours = row.Field<string>("openinghours");
        }

        public Retailer(string retailerLatitude, string retailerLongitude, string retailerCompanyName, string retailerDescription, string retailerOpeningHours) {
            this.GetOrSetLatitude = retailerLatitude;
            this.GetOrSetLongitude = retailerLongitude;
            this.GetOrSetCompanyName = retailerCompanyName;
            this.GetOrSetDescription = retailerDescription;
            this.GetOrSetOpeningHours = retailerOpeningHours;
        }

        [DataMember(Name = "id")]
        public int GetOrSetId {
            get {
                return _retailerId;
            }
            set {
                _retailerId = value;
            }
        }
        private int _retailerId;

        [DataMember(Name = "latitude")]
        public string GetOrSetLatitude {
            get {
                return _retailerLatitude;
            }
            set {
                _retailerLatitude = value;
            }
        }
        private string _retailerLatitude;

        [DataMember(Name = "longitude")]
        public string GetOrSetLongitude {
            get {
                return _retailerLongitude;
            }
            set {
                _retailerLongitude = value;
            }
        }
        private string _retailerLongitude;

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

        [DataMember(Name = "openinghours")]
        public string GetOrSetOpeningHours {
            get {
                return _retailerOpeningHours;
            }
            set {
                _retailerOpeningHours = value;
            }
        }
        private string _retailerOpeningHours;

        public override string ToString() {
            return this.GetOrSetLatitude
            + " " + this.GetOrSetLongitude
            + " " + this.GetOrSetCompanyName
            + " " + this.GetOrSetDescription
            + " " + this.GetOrSetOpeningHours;
        }
    }
}
