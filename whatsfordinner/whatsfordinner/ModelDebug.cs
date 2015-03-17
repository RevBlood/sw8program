using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whatsfordinner {
    public static class ModelDebug {
        public static Account GetTestAccount() {
            DateTime dt = DateTime.Now;
            Account acc = new Account("andrejs@andrejs.com", "andrejspw", "andrejs", dt, "noget med setting", "noget med preferences");
            return acc;
        }

        public static Comment GetTestComment() {
            DateTime dt = DateTime.Now;
            Comment com = new Comment(1, 1, dt, "noget med comment text");
            return com;
        }

        public static Ingredient GetTestIngredient() {
            Ingredient ing = new Ingredient("pasta", "gram", 500, 5.95m, "mel, gluten, billig, nem");
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

        public static Favorises GetTestFavorises() {
            Favorises fav = new Favorises(1, 1);
            return fav;
        }

        public static HasEaten GetTestHasEaten() {
            DateTime dt = DateTime.Now;  
            HasEaten has = new HasEaten(1, 1, dt, 4.5m);
            return has;
        }

        public static IngredientIn GetTestIngredientIn() {
            IngredientIn ing = new IngredientIn(1, 1, 300);
            return ing;
        }

        public static Offers GetTestOffers() {
            DateTime dt = DateTime.Now;
            DateTime dt2 = dt.AddDays(3);
            Offers off = new Offers(1, 1, dt, dt2, 20, 10, 10, 0.5m, 0.5m);
            return off;
        }

        public static Pictures GetTestPictures() {
            DateTime dt = DateTime.Now;
            Pictures pic = new Pictures(1, 1, "sti til picture", dt);
            return pic;
        }

    }
}
