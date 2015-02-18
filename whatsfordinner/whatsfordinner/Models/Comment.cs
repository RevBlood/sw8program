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
    class Comment {
        // Contains:
        // Comment Id
        // Comment AccountId
        // Comment RecipeId
        // Comment creationdate
        // Comment text

        // Here to use JSON Deserialize
        public Comment() { }

        public Comment(DataRow row) {
            this.GetOrSetId = row.Field<int>("commentid");
            this.GetOrSetAccountId = row.Field<int>("accountid");
            this.GetOrSetRecipeId = row.Field<int>("recipeid");
            this.GetOrSetCreationDate = row.Field<DateTime>("creationdate");
            this.GetOrSetText = row.Field<string>("text");
        }

        public Comment(int commentAccountId, int commentRecipeId, DateTime commentCreationDate, string commentText) {
            this.GetOrSetAccountId = commentAccountId;
            this.GetOrSetRecipeId = commentRecipeId;
            this.GetOrSetCreationDate = commentCreationDate;
            this.GetOrSetText = commentText;
        }

        [DataMember(Name = "id")]
        public int GetOrSetId {
            get {
                return _commentId;
            }
            set {
                _commentId = value;
            }
        }
        private int _commentId;

        [DataMember(Name = "accountid")]
        public int GetOrSetAccountId {
            get {
                return _commentAccountId;
            }
            set {
                _commentAccountId = value;
            }
        }
        private int _commentAccountId;

        [DataMember(Name = "recipeid")]
        public int GetOrSetRecipeId {
            get {
                return _commentRecipeId;
            }
            set {
                _commentRecipeId = value;
            }
        }
        private int _commentRecipeId;

        [DataMember(Name = "creationdate")]
        public DateTime GetOrSetCreationDate {
            get {
                return _commentCreationDate;
            }
            set {
                _commentCreationDate = value;
            }
        }
        private DateTime _commentCreationDate;

        [DataMember (Name = "text")]
        public string GetOrSetText {
            get {
                return _commentText;
            }
            set {
                _commentText = value;
            }
        }
        private string _commentText;

        public override string ToString() {
            return this.GetOrSetAccountId
            + " " + this.GetOrSetRecipeId
            + " " + this.GetOrSetCreationDate.ToString("dd/MM/yyyy HH:mm")
            + " " + this.GetOrSetText;
        }
    }
}
