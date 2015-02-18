using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace whatsfordinner {
    public static class JSONHelper {

        public static string Serialize<T>(T obj) {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
            MemoryStream ms = new MemoryStream();
            serializer.WriteObject(ms, obj);
            string retVal = Encoding.Default.GetString(ms.ToArray());
            ms.Dispose();
            return retVal;
        }

        public static T Deserialize<T>(string json) {
            T obj = Activator.CreateInstance<T>();
            MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(json));
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
            obj = (T)serializer.ReadObject(ms);
            ms.Close();
            ms.Dispose();
            return obj;
        }


        // Legacy JSON Serialization
        /*
        public int add(Account acc) {
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Account));
            MemoryStream ms = new MemoryStream();
            js.WriteObject(ms, acc);

            Console.WriteLine("\r\nUdemy.com - Serializing and Deserializing JSON in C#\r\n");
            ms.Position = 0;
            StreamReader sr = new StreamReader(ms);
            Console.WriteLine(sr.ReadToEnd());
            sr.Close();
            ms.Close();

            return 1;
        }
         * */

    }
}
