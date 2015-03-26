using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Net;
using System.IO;

namespace whatsfordinner {

    public class eTilbudRetriever {
        String ApiKey = "00i7q0nv9vp6kvbhzgr2ggsev4jrvy4f";
        String HostAddress = "https://api.etilbudsavis.dk/v2/sessions";
        String ContentType = "application/json";
        Double Latitude;
        Double Longitude;

        public eTilbudRetriever(Double lat, Double lng) {
            Latitude = lat;
            Longitude = lng;
            try {
                var request = (HttpWebRequest)WebRequest.Create(HostAddress);
                request.Method = "POST";
                request.ContentType = ContentType;
                request.Accept = ContentType;

                using (var writer = new StreamWriter(request.GetRequestStream())) {
                    writer.Write("{\"api_key\": \"" + ApiKey + "\"}");
                }

                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            } catch (UriFormatException e) {
                Console.WriteLine(e.ToString());
                return;
            } catch (WebException e) {
                Console.WriteLine(e.ToString());
                return;
            }
        }

        public static void something() {

        }
    }
}
