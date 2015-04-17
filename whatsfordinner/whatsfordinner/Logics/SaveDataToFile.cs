using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace whatsfordinner
{
    public static class SaveDataToFile
    {

        public static void writeToFile(String target, List<String> data) {

            string filepath = Path.Combine(Environment.CurrentDirectory, target + ".txt");
            File.WriteAllLines(filepath, data);
        }

        public static List<String> readFromFile(String target) {

            string filepath = Path.Combine(Environment.CurrentDirectory, target + ".txt");
            return File.ReadAllLines(filepath).ToList();

        }

    }
}
