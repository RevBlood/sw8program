using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whatsfordinner {
    static class JSONDebug {
        //
        // Entities
        //
        
        //Account
        public static string SerializeAccount(Account acc) {
            string serializedAcc = JSONHelper.Serialize<Account>(acc);
            return serializedAcc;
        }
        public static Account DeSerializeAccount(string acc) {
            Account deserializedAcc = JSONHelper.Deserialize<Account>(acc);
            return deserializedAcc;
        }

        public static void JSONAccountDebug(Account acc) {
            string serializedAcc = SerializeAccount(acc);
            Console.WriteLine(serializedAcc);
            Account jsonAccount = DeSerializeAccount(serializedAcc);
            Console.WriteLine(jsonAccount.ToString());
        }

        //Comment
        public static string SerializeComment(Comment com) {
            string serializedCom = JSONHelper.Serialize<Comment>(com);
            return serializedCom;
        }
        public static Comment DeSerializeComment(string com) {
            Comment deserializedCom = JSONHelper.Deserialize<Comment>(com);
            return deserializedCom;
        }

        public static void JSONCommentDebug(Comment com) {
            string serializedCom = SerializeComment(com);
            Console.WriteLine(serializedCom);
            Comment jsonComment = DeSerializeComment(serializedCom);
            Console.WriteLine(jsonComment.ToString());
        }

        //Ingredient
        public static string SerializeIngredient(Ingredient ing) {
            string serializedIng = JSONHelper.Serialize<Ingredient>(ing);
            return serializedIng;
        }
        public static Ingredient DeSerializeIngredient(string ing) {
            Ingredient deserializedIng = JSONHelper.Deserialize<Ingredient>(ing);
            return deserializedIng;
        }

        public static void JSONIngredientDebug(Ingredient ing) {
            string serializedIng = SerializeIngredient(ing);
            Console.WriteLine(serializedIng);
            Ingredient jsonIngredient = JSONHelper.Deserialize<Ingredient>(serializedIng);
            Console.WriteLine(jsonIngredient.ToString());
        }

        //Recipe
        public static string SerializeRecipe(Recipe rec) {
            string serializedRec = JSONHelper.Serialize<Recipe>(rec);
            return serializedRec;
        }
        public static Recipe DeSerializeRecipe(string rec) {
            Recipe deserializedRec = JSONHelper.Deserialize<Recipe>(rec);
            return deserializedRec;
        }

        public static void JSONRecipeDebug(Recipe rec) {
            string serializedRec = SerializeRecipe(rec);
            Console.WriteLine(serializedRec);
            Recipe jsonRecipe = DeSerializeRecipe(serializedRec);
            Console.WriteLine(jsonRecipe.ToString());
        }

        //Retailer
        public static string SerializeRetailer(Retailer ret) {
            string serializedRet = JSONHelper.Serialize<Retailer>(ret);
            return serializedRet;
        }
        public static Retailer DeSerializeRetailer(string ret) {
            Retailer deserializedRet = JSONHelper.Deserialize<Retailer>(ret);
            return deserializedRet;
        }

        public static void JSONRetailerDebug(Retailer ret) {
            string serializedRet = SerializeRetailer(ret);
            Console.WriteLine(serializedRet);
            Retailer jsonRetailer = DeSerializeRetailer(serializedRet);
            Console.WriteLine(jsonRetailer.ToString());
        }

        //
        // Relationships
        //

        //Favorises
        public static string SerializeFavorises(Favorises fav) {
            string serializedFav = JSONHelper.Serialize<Favorises>(fav);
            return serializedFav;
        }
        public static Favorises DeSerializeFavorises(string fav) {
            Favorises deserializedFav = JSONHelper.Deserialize<Favorises>(fav);
            return deserializedFav;
        }

        public static void JSONFavorisesDebug(Favorises fav) {
            string serializedFav = SerializeFavorises(fav);
            Console.WriteLine(serializedFav);
            Favorises jsonFavorises = DeSerializeFavorises(serializedFav);
            Console.WriteLine(jsonFavorises.ToString());
        }

        //HasEaten
        public static string SerializeHasEaten(HasEaten has) {
            string serializedHasEaten = JSONHelper.Serialize<HasEaten>(has);
            return serializedHasEaten;
        }
        public static HasEaten DeSerializeHasEaten(string has) {
            HasEaten deserializedHasEaten = JSONHelper.Deserialize<HasEaten>(has);
            return deserializedHasEaten;
        }

        public static void JSONHasEatenDebug(HasEaten has) {
            string serializedHasEaten = SerializeHasEaten(has);
            Console.WriteLine(serializedHasEaten);
            HasEaten jsonHasEaten = DeSerializeHasEaten(serializedHasEaten);
            Console.WriteLine(jsonHasEaten.ToString());
        }

        //IngredientIn
        public static string SerializeIngredientIn(IngredientIn ing) {
            string serializedIngredientIn = JSONHelper.Serialize<IngredientIn>(ing);
            return serializedIngredientIn;
        }
        public static IngredientIn DeSerializeIngredientIn(string ing) {
            IngredientIn deserializedIngredientIn = JSONHelper.Deserialize<IngredientIn>(ing);
            return deserializedIngredientIn;
        }

        public static void JSONIngredientInDebug(IngredientIn ing) {
            string serializedIngredientIn = SerializeIngredientIn(ing);
            Console.WriteLine(serializedIngredientIn);
            IngredientIn jsonIngredientIn = DeSerializeIngredientIn(serializedIngredientIn);
            Console.WriteLine(jsonIngredientIn.ToString());
        }

        //Offers
        public static string SerializeOffers(Offers off) {
            string serializedOffers = JSONHelper.Serialize<Offers>(off);
            return serializedOffers;
        }
        public static Offers DeSerializeOffers(string off) {
            Offers deserializedOffers = JSONHelper.Deserialize<Offers>(off);
            return deserializedOffers;
        }

        public static void JSONOffersDebug(Offers off) {
            string serializedOffers = SerializeOffers(off);
            Console.WriteLine(serializedOffers);
            Offers jsonOffers = DeSerializeOffers(serializedOffers);
            Console.WriteLine(jsonOffers.ToString());
        }

        //Pictures
        public static string SerializePictures(Pictures pic) {
            string serializedPictures = JSONHelper.Serialize<Pictures>(pic);
            return serializedPictures;
        }
        public static Pictures DeSerializePictures(string pic) {
            Pictures deserializedPictures = JSONHelper.Deserialize<Pictures>(pic);
            return deserializedPictures;
        }

        public static void JSONPicturesDebug(Pictures pic) {
            string serializedPictures = SerializePictures(pic);
            Console.WriteLine(serializedPictures);
            Pictures jsonPictures = DeSerializePictures(serializedPictures);
            Console.WriteLine(jsonPictures.ToString());
        }
    }
}
