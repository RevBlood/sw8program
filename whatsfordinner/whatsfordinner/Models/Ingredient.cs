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
    class Ingredient {
        // Contains:
        // Ingredient Id
        // Ingredient Name
        // Ingredient Measurementtype
        // Ingredient Price
        // Ingredient Tags

        // Here to use JSON Deserialize
        public Ingredient() { }

        public Ingredient(DataRow row) {
            this.GetOrSetId = row.Field<int>("ingredientid");
            this.GetOrSetName = row.Field<string>("name");
            this.GetOrSetMeasurementType = row.Field<string>("measurementtype");
            this.GetOrSetPrice = row.Field<Decimal>("price");
            this.GetOrSetTags = row.Field<string>("tags");
        }

        public Ingredient(string ingredientName, string ingredientMeasureType, decimal ingredientPrice, string ingredientTags) {
            this.GetOrSetMeasurementType = ingredientMeasureType;
            this.GetOrSetName = ingredientName;
            this.GetOrSetPrice = ingredientPrice;
            this.GetOrSetTags = ingredientTags;
        }

        [DataMember(Name = "id")]
        public int GetOrSetId {
            get {
                return _ingredientId;
            }
            set {
                _ingredientId = value;
            }
        }
        private int _ingredientId;

        [DataMember(Name = "name")] 
        public string GetOrSetName {
            get {
                return _ingredientName;
            }
            set {
                _ingredientName = value;
            }
        }
        private string _ingredientName;

        [DataMember(Name = "measurementtype")]
        public string GetOrSetMeasurementType {
            get {
                return _ingredientMeasurementType;
            }
            set {
                _ingredientMeasurementType = value;
            }
        }
        private string _ingredientMeasurementType;

        [DataMember(Name = "price")]
        public decimal GetOrSetPrice {
            get {
                return _ingredientPrice;
            }
            set {
                _ingredientPrice = value;
            }
        }
        private decimal _ingredientPrice;

        [DataMember(Name = "tags")]
        public string GetOrSetTags {
            get {
                return _ingredientTags;
            }
            set {
                _ingredientTags = value;
            }
        }
        private string _ingredientTags;

        public override string ToString() {
            return this.GetOrSetName
            + " " + this.GetOrSetMeasurementType
            + " " + this.GetOrSetPrice
            + " " + this.GetOrSetTags;
        }
    }
}
