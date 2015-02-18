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
    class Account {
        // Contains:
        // Account Id
        // Account Username
        // Account Password
        // Account Email
        // Account CreationDate
        // Account Settings
        // Account Preferences

        // Here to use JSON Deserialize
        public Account() { }

        public Account(DataRow row) {
            this.GetOrSetId = row.Field<int>("accountid");
            this.GetOrSetUsername = row.Field<string>("username");
            this.GetOrSetPassword = row.Field<string>("password");
            this.GetOrSetEmail = row.Field<string>("email");
            this.GetOrSetCreationDate = row.Field<DateTime>("creationdate");
            this.GetOrSetSettings = row.Field<string>("settings");
            this.GetOrSetPreferences = row.Field<string>("preferences");
        }

        public Account(string accountUsername, string accountPassword, string accountEmail, DateTime creationdate, string accountSettings, string accountPreferences) {
            this.GetOrSetUsername = accountUsername;
            this.GetOrSetPassword = accountPassword;
            this.GetOrSetEmail = accountEmail;
            this.GetOrSetCreationDate = (creationdate);
            this.GetOrSetSettings = accountSettings;
            this.GetOrSetPreferences = accountPreferences;
        }

        [DataMember(Name = "id")]
        public int GetOrSetId {
            get {
                return _accountId;
            }
            set {
                _accountId = value;
            }
        }
        private int _accountId;

        [DataMember (Name = "username")]
        public string GetOrSetUsername {
            get {
                return _accountUsername;
            }
            set {
                _accountUsername = value;
            }
        }
        private string _accountUsername;

        [DataMember(Name = "password")]
        public string GetOrSetPassword {
            get {
                return _accountPassword;
            }
            set {
                _accountPassword = value;
            }
        }
        private string _accountPassword;

        [DataMember(Name = "email")]
        public string GetOrSetEmail {
            get {
                return _accountEmail;
            }
            set {
                _accountEmail = value;
            }
        }
        private string _accountEmail;

        [DataMember(Name = "creationdate")]
        public DateTime GetOrSetCreationDate {
            get {
                return _accountCreationDate;
            }
            set {
                _accountCreationDate = value;
            }
        }
        private DateTime _accountCreationDate;

        [DataMember(Name = "settings")]
        public string GetOrSetSettings {
            get {
                return _accountSettings;
            }
            set {
                _accountSettings = value;
            }
        }
        private string _accountSettings;

        [DataMember(Name = "preferences")]
        public string GetOrSetPreferences {
            get {
                return _accountPreferences;
            }
            set {
                _accountPreferences = value;
            }
        }
        private string _accountPreferences;

        public override string ToString() {
            return  this.GetOrSetUsername 
            + " " + this.GetOrSetPassword 
            + " " + this.GetOrSetEmail 
            + " " + this.GetOrSetCreationDate.ToString("dd/MM/yyyy HH:mm")
            + " " + this.GetOrSetSettings
            + " " + this.GetOrSetPreferences;
        }
    }
}
