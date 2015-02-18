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
        // Comment creationdate
        // Comment text

        // Here to use JSON Deserialize
        public Comment() { }

        public Comment(DataRow row) {
            this.GetOrSetCreationDate = row.Field<DateTime>("creationdate");
            this.GetOrSetText = row.Field<string>("text");
        }

        public Comment(DateTime commentCreationDate, string commentText) {
            this.GetOrSetCreationDate = commentCreationDate;
            this.GetOrSetText = commentText;
        }

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
            return this.GetOrSetCreationDate.ToString("dd/MM/yyyy HH:mm")
            + " " + this.GetOrSetText;
        }
    }
}
