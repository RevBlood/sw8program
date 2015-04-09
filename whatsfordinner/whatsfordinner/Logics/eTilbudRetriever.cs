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
        readonly String ParamOffset = "offset";

        //Parameter values
        String Latitude = "57.051188"; //Havnen i Aalborg
        String Longitude = "9.922371";
        String Radius = "800000"; //Radius in meters (800km)
        String Limit = "48"; // Max amount of results in a query

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
        String XToken; //Same as a Session Token in documentation
        String XSignature; //Same as a Session Signature in documentation

        public eTilbudRetriever() {

            //Create a body consisting of the API key
            List<KeyValuePair<String, String>> body = new List<KeyValuePair<String, String>>();
            body.Add(new KeyValuePair<String, String>(ParamApiKey, ApiKey));

            //Send request to create a new session
            String response = SendWebRequest(Post, Sessions, body);

            //Get the Session Token from the response
            dynamic json = JObject.Parse(response);
            XToken = json.token;

            //Save the Session Signature as well (SHA256 version of API Secret combined with Session Token)
            XSignature = ConvertToSha256(ApiSecret + XToken);
            
        }

        public void GetDealersList() {
            GetList(Dealers);
        }

        public void GetStoresList() {
            GetList(Stores);
        }

        public void GetOffersList() {
            GetList(Offers);
        }

        private void GetList(string target) {

            List<String> resultSet = new List<String>();
            String result;
            int offset = 0;

            //Add desired parameters as headers for the eTilbudsavisen API
            List<KeyValuePair<String, String>> query = new List<KeyValuePair<String, String>>();
            query.Add(new KeyValuePair<String, String>(ParamLatitude, Latitude));
            query.Add(new KeyValuePair<String, String>(ParamLongitude, Longitude));
            query.Add(new KeyValuePair<String, String>(ParamRadius, Radius));
            query.Add(new KeyValuePair<String, String>(ParamLimit, Limit));
            query.Add(new KeyValuePair<String, String>(ParamOffset, offset.ToString()));

            //Retrieve a result through the request
            result = SendWebRequest(Get, target, query);

            /*
             * If result is valid, add it to the set of valid results.
             * Keep sending requests and increase the offset to avoid duplicated results
             * Stop when returned results are no longer valid
             */
            while (!String.IsNullOrEmpty(result)) {
                resultSet.Add(result);
                offset += Int32.Parse(Limit);
                query[query.Count-1] = new KeyValuePair<String, String>(ParamOffset, offset.ToString());
                result = SendWebRequest(Get, target, query);
            }
        }

        private String SendWebRequest(String method, String extension, List<KeyValuePair<String, String>> arguments) {

            try {
                String finalAddress = HostAddress + extension;

                //Add query to Address (if applicable)
                if (method.Equals(Get)) {
                    finalAddress += '?';
                    finalAddress += arguments[0].Key + '=' + arguments[0].Value;
                    for (int i = 1; i < arguments.Count; i++) {
                        finalAddress += '&' + arguments[i].Key + '=' + arguments[i].Value;
                    }
                }

                //Create request and set mandatory header properties
                var request = (HttpWebRequest)WebRequest.Create(finalAddress);
                request.Method = method;
                request.ContentType = ContentType;
                request.Accept = ContentType;

                //If a Session Token and Signature are available (= After session create), add as headers
                if (!String.IsNullOrEmpty(XToken)) {
                    request.Headers.Add(HeaderXToken, XToken);
                    request.Headers.Add(HeaderXSignature, XSignature);
                }

                //Create JSON string containing the desired body arguments (if applicable)
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
