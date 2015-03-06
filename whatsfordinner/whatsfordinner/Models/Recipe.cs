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
    public class Recipe {
        // Contains:
        // Recipe Id
        // Recipe AccountId
        // Recipe Name
        // Recipe Description
        // Recipe CreationDate
        // Recipe NumberOfServings
        // Recipe Tags
        // Recipe Rating

        // Optional To Implement
        // Leftover rating
        // Freeze rating
        // Time before finsihed
        // Cooking time
        // Ingredients list

        // Here to use JSON Deserialize
        public Recipe() { }

        public Recipe(DataRow row) {
            this.GetOrSetId = row.Field<int>("recipeid");
            this.GetOrSetAccountId = row.Field<int>("accountid");
            this.GetOrSetName = row.Field<string>("name");
            this.GetOrSetDescription = row.Field<string>("description");
            this.GetOrSetCreationDate = row.Field<DateTime>("creationdate");
            this.GetOrSetNumberOfServings = row.Field<int>("numberofservings");
            this.GetOrSetTags = row.Field<string>("tags");
            this.GetOrSetRating = row.Field<decimal>("rating");
        }

        public Recipe(int recipeAccountId, string recipeName, string recipeDescription, DateTime recipeCreationDate, int recipeNumberOfServings, string recipeTags, decimal recipeRating) {
            this.GetOrSetAccountId = recipeAccountId;
            this.GetOrSetName = recipeName;
            this.GetOrSetDescription = recipeDescription;
            this.GetOrSetCreationDate = recipeCreationDate;
            this.GetOrSetNumberOfServings = recipeNumberOfServings;
            this.GetOrSetTags = recipeTags;
            this.GetOrSetRating = recipeRating;
        }

        [DataMember(Name = "id")]
        public int GetOrSetId {
            get {
                return _recipeId;
            }
            set {
                _recipeId = value;
            }
        }
        private int _recipeId;

        [DataMember(Name = "accountid")]
        public int GetOrSetAccountId {
            get {
                return _recipeAccountId;
            }
            set {
                _recipeAccountId = value;
            }
        }
        private int _recipeAccountId;

        [DataMember(Name = "name")]
        public string GetOrSetName {
            get {
                return _recipeName;
            }
            set {
                _recipeName = value;
            }
        }
        private string _recipeName;

        [DataMember(Name = "description")]
        public string GetOrSetDescription {
            get {
                return _recipeDescription;
            }
            set {
                _recipeDescription = value;
            }
        }
        private string _recipeDescription;

        [DataMember(Name = "creationdate")]
        public DateTime GetOrSetCreationDate {
            get {
                return _recipeCreationDate;
            }
            set {
                _recipeCreationDate = value;
            }
        }
        private DateTime _recipeCreationDate;

        [DataMember(Name = "numberofservings")]
        public int GetOrSetNumberOfServings {
            get {
                return _numberOfServings;
            }
            set {
                _numberOfServings = value;
            }
        }
        private int _numberOfServings;

        [DataMember(Name = "tags")]
        public string GetOrSetTags {
            get {
                return _recipeTags;
            }
            set {
                _recipeTags = value;
            }
        }
        private string _recipeTags;

        [DataMember(Name = "rating")]
        public decimal GetOrSetRating {
            get {
                return _recipeRating;
            }
            set {
                _recipeRating = value;
            }
        }
        private decimal _recipeRating;

        public override string ToString() {
            return this.GetOrSetId
            + " " + this.GetOrSetName
            + " " + this.GetOrSetDescription
            + " " + this.GetOrSetCreationDate.ToString("dd/MM/yyyy HH:mm")
            + " " + this.GetOrSetNumberOfServings
            + " " + this.GetOrSetTags
            + " " + this.GetOrSetRating;
        }
    }
}
