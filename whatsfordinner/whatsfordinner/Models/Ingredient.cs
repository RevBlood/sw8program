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
    public class Ingredient {
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
            this.GetOrSetMeasure = row.Field<int>("measure");
            this.GetOrSetPrice = row.Field<decimal>("price");
            this.GetOrSetTags = row.Field<string>("tags");
        }

        public Ingredient(string ingredientName, string ingredientMeasureType, int ingredientMeasure, decimal ingredientPrice, string ingredientTags) {
            this.GetOrSetName = ingredientName;
            this.GetOrSetMeasurementType = ingredientMeasureType;
            this.GetOrSetMeasure = ingredientMeasure;
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

        [DataMember(Name = "measurementType")]
        public string GetOrSetMeasurementType {
            get {
                return _ingredientMeasurementType;
            }
            set {
                _ingredientMeasurementType = value;
            }
        }
        private string _ingredientMeasurementType;

        [DataMember(Name = "measure")]
        public int GetOrSetMeasure {
            get {
                return _ingredientMeasure;
            }
            set {
                _ingredientMeasure = value;
            }
        }
        private int _ingredientMeasure;

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
            return this.GetOrSetId
            + " " + this.GetOrSetName
            + " " + this.GetOrSetMeasurementType
            + " " + this.GetOrSetMeasure
            + " " + this.GetOrSetPrice
            + " " + this.GetOrSetTags;
        }
    }
}
