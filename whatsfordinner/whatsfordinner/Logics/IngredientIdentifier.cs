using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whatsfordinner {
    public static class IngredientIdentifier {
        public static void Identify() {
            DBController dbc = new DBController();
            List<Ingredient> allIngredients = dbc.GetAllIngredients();

            foreach (Ingredient ing in allIngredients) {
                Console.WriteLine(ing.GetOrSetName.ToString());
            }


            
            List<string> comparisonList = new List<string>();
            comparisonList.Add("Gær");
            comparisonList.Add("Vand");
            comparisonList.Add("Salt");
            comparisonList.Add("Olie");
            comparisonList.Add("Fuldkornshvedemel");
            comparisonList.Add("Hvedemel");
            comparisonList.Add("Løg");
            comparisonList.Add("Olie");
            comparisonList.Add("Hakkede tomater, konserves");
            comparisonList.Add("Oregano, tørret");
            comparisonList.Add("Grøn peberfrugt");
            comparisonList.Add("Medisterpølse. røget");
            comparisonList.Add("Oliven. sorte. uden sten. i saltlage");
            comparisonList.Add("Revet ost, mozzarella 45+");
            comparisonList.Add("Parmesanost. revet");
            comparisonList.Add("mini");

            foreach (string str in comparisonList) {
                Console.WriteLine(str);
            }

            foreach (string str in comparisonList) {
                foreach (Ingredient ing in allIngredients) {

                    List<char> str1 = str.ToList<char>();
                    List<char> str2 = ing.GetOrSetName.ToString().ToList<char>();

                    List<char> intersection = str.Intersect(str2).ToList<char>();
                    List<char> union = str1.Union(str2).ToList<char>();
                    double t = Convert.ToDouble(intersection.Count) / Convert.ToDouble(union.Count);
                    if (t > 0.70) {
                        Console.WriteLine("A match?: " + str + " and " + ing.GetOrSetName);
                    }
                }
            }
            string test = "";

            














        }
    }
}
