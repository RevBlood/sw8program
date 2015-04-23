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
    public class Offers {
        // Contains:
        // Offers RetailerId
        // Offers IngredientId
        // Offers OfferFrom
        // Offers OfferTo
        // Offers NormalPrice
        // Offers OnSalePrice
        // Offers KrSaving
        // Offers PercentageSavingRetailer
        // Offers PercentageSavingGeneral

        // Here to use JSON Deserialize
        public Offers() { }

        public Offers(DataRow row) {
            this.GetOrSetRetailerId = row.Field<int>("retailerid");
            this.GetOrSetIngredientId = row.Field<int>("ingredientid");
            this.GetOrSetOfferFrom = row.Field<DateTime>("offerfrom");
            this.GetOrSetOfferTo = row.Field<DateTime>("offerto");
            this.GetOrSetNormalPrice = row.Field<decimal?>("normalprice");
            this.GetOrSetOnSalePrice = row.Field<decimal>("onsaleprice");
            this.GetOrSetKrSaving = row.Field<decimal>("krsaving");
            this.GetOrSetPercentageSavingRetailer = row.Field<decimal>("percentagesavingretailer");
            this.GetOrSetPercentageSavingGeneral = row.Field<decimal>("percentagesavinggeneral");
        }

        public Offers(int offersRetailerId, int offersAccountId, DateTime offerFrom, DateTime offerTo, decimal? offersNormalPrice, decimal offersOnSalePrice, 
                        decimal offersKrSaving, decimal offerPercentageSavingRetailer, decimal offerPercentageSavingGeneral) {
            this.GetOrSetRetailerId = offersRetailerId;
            this.GetOrSetIngredientId = offersAccountId;
            this.GetOrSetOfferFrom = offerFrom;
            this.GetOrSetOfferTo = offerTo;
            this.GetOrSetNormalPrice = offersNormalPrice;
            this.GetOrSetOnSalePrice = offersOnSalePrice;
            this.GetOrSetKrSaving = offersKrSaving;
            this.GetOrSetPercentageSavingRetailer = offerPercentageSavingRetailer;
            this.GetOrSetPercentageSavingGeneral = offerPercentageSavingGeneral;
        }

        [DataMember(Name = "retailerid")]
        public int GetOrSetRetailerId {
            get {
                return _offersRetailerId;
            }
            set {
                _offersRetailerId = value;
            }
        }
        private int _offersRetailerId;

        [DataMember(Name = "ingredientid")]
        public int GetOrSetIngredientId {
            get {
                return _offersIngredientId;
            }
            set {
                _offersIngredientId = value;
            }
        }
        private int _offersIngredientId;

        [DataMember(Name = "offerfrom")]
        public DateTime GetOrSetOfferFrom {
            get {
                return _offersOfferFrom;
            }
            set {
                _offersOfferFrom = value;
            }
        }
        private DateTime _offersOfferFrom;

        [DataMember(Name = "offerto")]
        public DateTime GetOrSetOfferTo {
            get {
                return _offersOfferTo;
            }
            set {
                _offersOfferTo = value;
            }
        }
        private DateTime _offersOfferTo;

        [DataMember(Name = "normalprice")]
        public decimal? GetOrSetNormalPrice {
            get {
                return _offersNormalPrice;
            }
            set {
                _offersNormalPrice = value;
            }
        }
        private decimal? _offersNormalPrice;

        [DataMember(Name = "onsaleprice")]
        public decimal GetOrSetOnSalePrice {
            get {
                return _offersOnSalePrice;
            }
            set {
                _offersOnSalePrice = value;
            }
        }
        private decimal _offersOnSalePrice;

        [DataMember(Name = "krsaving")]
        public decimal GetOrSetKrSaving {
            get {
                return _offersKrSaving;
            }
            set {
                _offersKrSaving = value;
            }
        }
        private decimal _offersKrSaving;

        [DataMember(Name = "percentagesavingretailer")]
        public decimal GetOrSetPercentageSavingRetailer {
            get {
                return _offersPercentageSavingRetailer;
            }
            set {
                _offersPercentageSavingRetailer = value;
            }
        }
        private decimal _offersPercentageSavingRetailer;

        [DataMember(Name = "percentagesavinggeneral")]
        public decimal GetOrSetPercentageSavingGeneral {
            get {
                return _offersPercentageSavingGeneral;
            }
            set {
                _offersPercentageSavingGeneral = value;
            }
        }
        private decimal _offersPercentageSavingGeneral;

        public override string ToString() {
            return this.GetOrSetRetailerId
            + " " + this.GetOrSetIngredientId
            + " " + this.GetOrSetOfferFrom.ToString("dd/MM/yyyy HH:mm")
            + " " + this.GetOrSetOfferTo.ToString("dd/MM/yyyy HH:mm")
            + " " + this.GetOrSetNormalPrice
            + " " + this.GetOrSetOnSalePrice
            + " " + this.GetOrSetKrSaving
            + " " + this.GetOrSetPercentageSavingRetailer
            + " " + this.GetOrSetPercentageSavingGeneral;
        }
    }
}
