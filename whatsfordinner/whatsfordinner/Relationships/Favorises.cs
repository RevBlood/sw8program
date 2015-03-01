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
    public class Favorises {
        // Contains:
        // Favorises accountid
        // Favorises recipeid

        // Here to use JSON Deserialize
        public Favorises() { }

        public Favorises(DataRow row) {
            this.GetOrSetAccountId = row.Field<int>("accountid");
            this.GetOrSetRecipeId = row.Field<int>("recipeid");
        }

        public Favorises(int favorisesAcccountId, int favorisesRecipeId) {
            this.GetOrSetAccountId = favorisesAcccountId;
            this.GetOrSetRecipeId = favorisesRecipeId;
        }

        [DataMember(Name = "accountid")]
        public int GetOrSetAccountId {
            get {
                return _favorisesAccountId;
            }
            set {
                _favorisesAccountId = value;
            }
        }
        private int _favorisesAccountId;

        [DataMember(Name = "recipeid")]
        public int GetOrSetRecipeId {
            get {
                return _favorisesRecipeId;
            }
            set {
                _favorisesRecipeId = value;
            }
        }
        private int _favorisesRecipeId;

        public override string ToString() {
            return this.GetOrSetAccountId
            + " " + this.GetOrSetRecipeId;
        }
    }
}
