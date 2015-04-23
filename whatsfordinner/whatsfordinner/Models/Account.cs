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
    public class Account {
        // Contains:
        // Account Id
        // Account Email
        // Account Password
        // Account Alias
        // Account CreationDate
        // Account Settings
        // Account Preferences

        // Here to use JSON Deserialize
        public Account() { }

        public Account(DataRow row) {
            this.GetOrSetId = row.Field<int>("accountid");
            this.GetOrSetEmail = row.Field<string>("email");
            this.GetOrSetPassword = row.Field<string>("password");
            this.GetOrSetAlias = row.Field<string>("alias");
            this.GetOrSetCreationDate = row.Field<DateTime>("creationdate");
            this.GetOrSetSettings = row.Field<string>("settings");
            this.GetOrSetPreferences = row.Field<string>("preferences");
        }

        // Test account
        public Account(string accountEmail, string accountPassword, string accountAlias, string accountSettings, string accountPreferences) {
            this.GetOrSetAlias = accountAlias;
            this.GetOrSetPassword = accountPassword;
            this.GetOrSetEmail = accountEmail;
            this.GetOrSetSettings = accountSettings;
            this.GetOrSetPreferences = accountPreferences;
        }

        public Account(int accountId, string accountEmail, string accountPassword, string accountAlias, DateTime creationdate, string accountSettings, string accountPreferences) {
            this.GetOrSetId = accountId;
            this.GetOrSetEmail = accountEmail;
            this.GetOrSetPassword = accountPassword;
            this.GetOrSetAlias = accountAlias;
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

        [DataMember(Name = "alias")]
        public string GetOrSetAlias {
            get {
                return _accountAlias;
            }
            set {
                _accountAlias = value;
            }
        }
        private string _accountAlias;

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
            return this.GetOrSetId
            + " " + this.GetOrSetEmail 
            + " " + this.GetOrSetPassword
            + " " + this.GetOrSetAlias 
            + " " + this.GetOrSetCreationDate.ToString("dd/MM/yyyy HH:mm")
            + " " + this.GetOrSetSettings
            + " " + this.GetOrSetPreferences;
        }
    }
}
