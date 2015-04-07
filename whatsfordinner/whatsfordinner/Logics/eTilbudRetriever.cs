using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Text;

using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace whatsfordinner {

    public class eTilbudRetriever {
        
        //Web method names
        readonly String Get = "GET";
        readonly String Post = "POST";
        readonly String Update = "UPDATE";
        readonly String Delete = "DELETE";

        //Parameter identifiers
        readonly String ParamApiKey = "api_key";
        readonly String ParamLatitude = "r_lat";
        readonly String ParamLongitude = "r_lng";
        readonly String ParamRadius = "r_radius";
        readonly String ParamLimit = "limit";

        //Parameter values
        String Latitude = "57.051188"; //Havnen i Aalborg
        String Longitude = "9.922371";
        String Radius = "800000"; //Radius in meters (800km)
        String Limit = "50"; //Get 50 offers

        //Custom header identifiers
        readonly String HeaderXToken = "X-Token";
        readonly String HeaderXSignature = "X-Signature";

        //Custom header values
        readonly String ContentType = "application/json";

        //Web Addresses
        readonly String HostAddress = "https://api.etilbudsavis.dk/v2/";
        readonly String Sessions = "sessions";
        readonly String Stores = "stores";
        readonly String Offers = "offers";
        readonly String Dealers = "dealers";

        //Keys
        readonly String ApiKey = "00i7q0nv9vp6kvbhzgr2ggsev4jrvy4f";
        readonly String ApiSecret = "00i7q0nv9vfaf8xgygg0qmxlkcwr3nvh";
        String XToken = null; //Same as a Session Token in documentation
        String XSignature = null; //Same as a Session Signature in documentation

        public eTilbudRetriever() {

            List<KeyValuePair<String, String>> body = new List<KeyValuePair<String, String>>();
            body.Add(new KeyValuePair<String, String>(ParamApiKey, ApiKey));
            String response = SendWebRequest(Post, Sessions, body);
            dynamic json = JObject.Parse(response);
            XToken = json.token;
            XSignature = ConvertToSha256(ApiSecret + XToken);
            
        }

        public String GetOfferList() {

            List<KeyValuePair<String, String>> body = new List<KeyValuePair<String, String>>();
            body.Add(new KeyValuePair<String, String>(ParamLatitude, Latitude));
            body.Add(new KeyValuePair<String, String>(ParamLongitude, Longitude));
            body.Add(new KeyValuePair<String, String>(ParamRadius, Radius));
            body.Add(new KeyValuePair<String, String>(ParamLimit, Limit));
            return SendWebRequest(Get, Offers, body);
        }

        public String GetStoreList() {

            List<KeyValuePair<String, String>> body = new List<KeyValuePair<String, String>>();
            body.Add(new KeyValuePair<String, String>(ParamLatitude, Latitude));
            body.Add(new KeyValuePair<String, String>(ParamLongitude, Longitude));
            body.Add(new KeyValuePair<String, String>(ParamRadius, Radius));
            body.Add(new KeyValuePair<String, String>(ParamLimit, Limit));
            return SendWebRequest(Get, Stores, body);
        }

        public String GetDealerList() {

            List<KeyValuePair<String, String>> body = new List<KeyValuePair<String, String>>();
            body.Add(new KeyValuePair<String, String>(ParamLatitude, Latitude));
            body.Add(new KeyValuePair<String, String>(ParamLongitude, Longitude));
            body.Add(new KeyValuePair<String, String>(ParamRadius, Radius));
            body.Add(new KeyValuePair<String, String>(ParamLimit, Limit));
            return SendWebRequest(Get, Dealers, body); ;
        }

        private String SendWebRequest(String method, String extension, List<KeyValuePair<String, String>> arguments) {

            try {
                //Set properties of the request
                var request = (HttpWebRequest)WebRequest.Create(HostAddress + extension);
                request.Method = method;
                request.ContentType = ContentType;
                request.Accept = ContentType;

                if (!String.IsNullOrEmpty(XToken)) {
                    request.Headers.Add(HeaderXToken, XToken);
                    request.Headers.Add(HeaderXSignature, XSignature);
                }
                
                //Create JSON string containing the desired body arguments
                if (method.Equals(Post)) {

                    //Write body to API
                    using (var writer = new StreamWriter(request.GetRequestStream())) {
                        writer.Write(MakeJsonBody(arguments));
                    }
                }

                //get response as a JSON object in string format
                var response = (HttpWebResponse)request.GetResponse();
                return new StreamReader(response.GetResponseStream()).ReadToEnd();

            } catch (UriFormatException e) {
                Console.WriteLine(e.ToString());
                return null;
            } catch (WebException e) {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        private String ConvertToSha256(String text) {

            byte[] bytes = Encoding.UTF8.GetBytes(text);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;

            foreach (byte x in hash) {
                hashString += String.Format("{0:x2}", x);
            }

            return hashString;
        }

        private String MakeJsonBody(List<KeyValuePair<String, String>> arguments) {

            String json = "{";

            foreach (KeyValuePair<String, String> kv in arguments) {
                json += "\"" + kv.Key + "\": \"" + kv.Value + "\"";

                if (arguments.IndexOf(kv) != arguments.Count() - 1) {
                    json += ", ";
                }
            }

            json += "}";
            return json;
        }
    }
}
