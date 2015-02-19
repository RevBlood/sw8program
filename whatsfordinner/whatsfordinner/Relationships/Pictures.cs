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
    class Pictures {
        // Contains:
        // Pictures AccountId
        // Pictures RecipeId
        // Pictures PicturePath
        // Pictures CreationDate

        // Here to use JSON Deserialize
        public Pictures() { }

        public Pictures(DataRow row) {
            this.GetOrSetAccountId = row.Field<int>("accountid");
            this.GetOrSetRecipeId = row.Field<int>("recipeid");
            this.GetOrSetPicturePath = row.Field<string>("picturepath");
            this.GetOrSetCreationDate = row.Field<DateTime>("creationdate");
        }

        public Pictures(int picturesAcccountId, int picturesRecipeId, string picturesPicturePath, DateTime picturesCreationDate) {
            this.GetOrSetAccountId = picturesAcccountId;
            this.GetOrSetRecipeId = picturesRecipeId;
            this.GetOrSetPicturePath = picturesPicturePath;
            this.GetOrSetCreationDate = picturesCreationDate;
        }

        [DataMember(Name = "accountid")]
        public int GetOrSetAccountId {
            get {
                return _picturesAccountId;
            }
            set {
                _picturesAccountId = value;
            }
        }
        private int _picturesAccountId;

        [DataMember(Name = "recipeid")]
        public int GetOrSetRecipeId {
            get {
                return _picturesRecipeId;
            }
            set {
                _picturesRecipeId = value;
            }
        }
        private int _picturesRecipeId;

        [DataMember(Name = "picturepath")]
        public string GetOrSetPicturePath {
            get {
                return _picturesPicturePath;
            }
            set {
                _picturesPicturePath = value;
            }
        }
        private string _picturesPicturePath;

        [DataMember(Name = "creationdate")]
        public DateTime GetOrSetCreationDate {
            get {
                return _picturesCreationDate;
            }
            set {
                _picturesCreationDate = value;
            }
        }
        private DateTime _picturesCreationDate;

        public override string ToString() {
            return this.GetOrSetAccountId
            + " " + this.GetOrSetRecipeId
            + " " + this.GetOrSetPicturePath
            + " " + this.GetOrSetCreationDate.ToString("dd/MM/yyyy HH:mm");
        }


    }
}
