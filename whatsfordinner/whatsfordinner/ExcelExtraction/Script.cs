using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whatsfordinner {
    public static class Script {

        public static void ExcelExtractionScript() {

            List<string> Groceries = new List<string>();
            List<string> MeasurementType = new List<string>();
            List<decimal> Measure = new List<decimal>();
            List<decimal> Price = new List<decimal>();

            int i;

            string tempString;
            decimal tempValueOne;
            decimal tempValuetwo;

            //using (StreamReader reader = new StreamReader(@"C:/Users/Casper/Dropbox/P8/gnmsnit.csv", Encoding.Default)) {
            using (StreamReader reader = new StreamReader(@"C:/Users/Casper/Documents/My Dropbox/P8/gnmsnit.csv", Encoding.Default)) {
                string line;
                while ((line = reader.ReadLine()) != null) {
                    string[] fields = line.Split(';');


                    Groceries.Add(fields[0]);

                    string[] tempPrice = fields[13].Split('.');

                    tempValueOne = Convert.ToDecimal(tempPrice[0]);
                    tempValuetwo = Convert.ToDecimal(tempPrice[1]) * Convert.ToDecimal(0.01);

                    Price.Add(tempValueOne + tempValuetwo);


                    tempString = fields[1];
                    var measurefields = tempString.Split(' ');

                    if (measurefields.Count() > 1) {
                        if (measurefields[1] == "kg") {
                            MeasurementType.Add("gram");
                            decimal numVal = Convert.ToDecimal(measurefields[0]);
                            Measure.Add(numVal * 1000);
                        } else if (measurefields[1] == "stk") {
                            MeasurementType.Add("stk");
                            decimal numVal = Convert.ToDecimal(measurefields[0]);
                            Measure.Add(numVal);
                        } else if (measurefields[1] == "ltr" || measurefields[1] == "ltr.") {
                            MeasurementType.Add("Deciliter");
                            decimal numVal = Convert.ToDecimal(measurefields[0]);
                            Measure.Add(numVal * 10);
                        } else if (measurefields[1] == "g") {
                            MeasurementType.Add("gram");
                            decimal numVal = Convert.ToDecimal(measurefields[0]);
                            Measure.Add(numVal);
                        } else {
                        }
                    }
                }
            }

            for (i = 1; i < Groceries.Count; i++) {

                Console.WriteLine(Groceries[i].ToString());
                DBController dbc = new DBController();
                dbc.AddIngredient(new Ingredient(Groceries[i], MeasurementType[i], (int)Measure[i], Price[i], false, 0.00m, false, null));
                dbc.Close();
            }
        }
    }
}