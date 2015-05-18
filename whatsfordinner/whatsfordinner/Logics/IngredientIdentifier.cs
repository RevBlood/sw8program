using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whatsfordinner {
    public static class IngredientIdentifier {
        public static void Identify() {

            List<string> comparisonList = new List<string>();
            comparisonList.Add("Gær");
            comparisonList.Add("Vand");
            comparisonList.Add("Salt");
            comparisonList.Add("Olie");
            comparisonList.Add("Fuldkornshvedemel");
            comparisonList.Add("Hvedemel");
            comparisonList.Add("Løg");
            comparisonList.Add("Hakkede tomater, konserves");
            comparisonList.Add("Oregano, tørret");
            comparisonList.Add("Grøn peberfrugt");
            comparisonList.Add("Medisterpølse. røget");
            comparisonList.Add("Oliven. sorte. uden sten. i saltlage");
            comparisonList.Add("Revet ost, mozzarella 45+");
            comparisonList.Add("Parmesanost. revet");
            comparisonList.Add("mini");

            /*
            foreach (string str in comparisonList) {
                Console.WriteLine(str);
            }
            */

            string longestString = "";
            int size = 0;
            string testString = "Chili Medisterpølse";
            int curSize = 0;
            string resultString = "";

            foreach (string str in comparisonList) {
                curSize = LongComSubstring.LongestCommonSubstring(testString, str, out longestString);
                if (curSize > size) {
                    size = curSize;
                    resultString = longestString;
                }
            }

            Console.WriteLine(resultString);







            /*
            //Jaccard Similarity
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
             * */

        }
        /*
        public static void saved() {
            List<string> coNames = names.ToList();
            coNames.Remove(names[x]);

            bool coNamesInDescripton = false;
            int coNameCounting = 0;

            foreach (string coName in coNames) {
                if (header.ToLower().Contains(coName.ToLower())) {
                    coNamesInDescripton = true;
                    coNameCounting++;
                    break;
                } else if (description.ToLower().Contains(coName.ToLower())) {
                    coNamesInDescripton = true;
                    coNameCounting++;
                    break;
                }

            }
            if (coNamesInDescripton == true && coNameCounting == coNames.Count()) {
                Console.WriteLine("Jeg fandt noget!!!");
                Console.WriteLine(ing.GetOrSetName);
            }
        }
        */
        static List<string> badWords = new List<string> {"i", "med", "fra", "af", "i", "og"};

        public static bool detectImportantWord(string word, ref List<Ingredient> allIngredients) {
            foreach (Ingredient ing in allIngredients) {
                string[] splitIngName = ing.GetOrSetName.Split(' ');
                foreach (string str in splitIngName) {
                    if (str.Contains(word)) {
                        //Fix bad words

                        if (badWords.Contains(str)) {

                        } else {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public static List<string> importantWordsFromString(string text, ref List<Ingredient> allIngredients) {
            List<string> importantWords = new List<string>();
            foreach (string str in text.Split(' ')) {
                if (detectImportantWord(str, ref allIngredients)) {
                    importantWords.Add(str);
                }
            }

            importantWords.AddRange(hyphenParsing(text, ref allIngredients));


            return importantWords;
        }

        public static List<string> hyphenParsing(string text, ref List<Ingredient> allIngredients) {
            List<string> importantHyphenWords = new List<string>();
            string[] words = text.Split(' ');

            for (int i = 0; i < words.Count(); i++) {
                if (words[i].Last() == '-' && !(words[i].Count() == 1)) {
                    if (words[i + 1] != null && words[i + 2] != null && (words[i + 1] == "eller" || words[i + 1] == "og")) {
                        StringBuilder sb = new StringBuilder();
                        string guessing = words[i].Substring(0, words[i].Count() - 1);
                        //Appending small parts of the next word to the base word and check whether we hit something in the ingredient database
                        for (int wordLength = 0; wordLength < words[i + 2].Count(); wordLength++) {
                            sb.Clear();
                            sb.Append(guessing);

                            //Uses the for-loop to insert decreasing substring of the next word
                            string nextWordParts = words[i + 2].Substring(wordLength, words[i + 2].Count() - wordLength);
                            sb.Append(nextWordParts);
                            foreach (Ingredient ing in allIngredients) {
                                string[] names = ing.GetOrSetName.Split(' ');
                                for (int x = 0; x < names.Count(); x++) {
                                    if (names[x].ToLower() == sb.ToString().ToLower()) {
                                        if (!importantHyphenWords.Contains(names[x])) {
                                            importantHyphenWords.Add(names[x]);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return importantHyphenWords;
        }

    }
}
