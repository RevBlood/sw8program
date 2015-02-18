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
            Comment com = new Comment(dt, "noget med comment text");
            return com;
        }

        public static Ingredient GetTestIngredient() {
            Ingredient ing = new Ingredient("pasta", "gram", 5.95, "mel, gluten, billig, nem");
            return ing;
        }

        public static Recipe GetTestRecipe() {
            DateTime dt = DateTime.Now;
            Recipe rec = new Recipe("hakkebøf", "steg en hakkebøf", dt, 4, "bøf, kød, kvalitet", 4.5);
            return rec;
        }

        public static Retailer GetTestRetailer() {
            Retailer ret = new Retailer("SuperBrugsen", "Description af superbrugsen");
            return ret;
        }

    }
}
