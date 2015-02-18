using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whatsfordinner {
    static class ModelDebug {
        public static Account GetTestAccount() {
            DateTime dt = DateTime.Now;        
            Account acc = new Account("andrejs", "andrejspw", "andrejs@andrejs.com", dt, "noget med setting", "noget med preferences");
            return acc;
        }

        public static Comment GetTestComment() {
            DateTime dt = DateTime.Now;
            Comment com = new Comment(1, 1, dt, "noget med comment text");
            return com;
        }

        public static Ingredient GetTestIngredient() {
            Ingredient ing = new Ingredient("pasta", "gram", 5.95m, "mel, gluten, billig, nem");
            return ing;
        }

        public static Recipe GetTestRecipe() {
            DateTime dt = DateTime.Now;
            Recipe rec = new Recipe(1, "hakkebøf", "steg en hakkebøf", dt, 4, "bøf, kød, kvalitet", 4.5m);
            return rec;
        }

        public static Retailer GetTestRetailer() {
            Retailer ret = new Retailer("57.052648", "9.917516", "SuperBrugsen", "Description af superbrugsen", "noget med openinghours");
            return ret;
        }

    }
}
