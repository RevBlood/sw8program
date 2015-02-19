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
    class HasEaten {
        // Contains:
        // HasEaten AccountId
        // HasEaten RecipeId
        // HasEaten EatenAt
        // HasEaten Rating

        // Here to use JSON Deserialize
        public HasEaten() { }

        public HasEaten(DataRow row) {
            this.GetOrSetAccountId = row.Field<int>("accountid");
            this.GetOrSetRecipeId = row.Field<int>("recipeid");
            this.GetOrSetEatenAt = row.Field<DateTime>("eatenat");
            this.GetOrSetRating = row.Field<decimal>("rating");
        }

        public HasEaten(int hasEatenAccountId, int hasEatenRecipeId, DateTime hasEatenEatenAt, decimal hasEatenRating) {
            this.GetOrSetAccountId = hasEatenAccountId;
            this.GetOrSetRecipeId = hasEatenRecipeId;
            this.GetOrSetEatenAt = hasEatenEatenAt;
            this.GetOrSetRating = hasEatenRating;
        }

        [DataMember(Name = "accountid")]
        public int GetOrSetAccountId {
            get {
                return _hasEatenAccountId;
            }
            set {
                _hasEatenAccountId = value;
            }
        }
        private int _hasEatenAccountId;

        [DataMember(Name = "recipeid")]
        public int GetOrSetRecipeId {
            get {
                return _hasEatenRecipeId;
            }
            set {
                _hasEatenRecipeId = value;
            }
        }
        private int _hasEatenRecipeId;

        [DataMember(Name = "eatenat")]
        public DateTime GetOrSetEatenAt {
            get {
                return _hasEatenEatenAt;
            }
            set {
                _hasEatenEatenAt = value;
            }
        }
        private DateTime _hasEatenEatenAt;

        [DataMember(Name = "rating")]
        public decimal GetOrSetRating {
            get {
                return _hasEatenRating;
            }
            set {
                _hasEatenRating = value;
            }
        }
        private decimal _hasEatenRating;

        public override string ToString() {
            return this.GetOrSetAccountId
            + " " + this.GetOrSetRecipeId
            + " " + this.GetOrSetEatenAt
            + " " + this.GetOrSetRating;
        }
    }
}
