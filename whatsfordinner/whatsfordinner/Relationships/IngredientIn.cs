using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace whatsfordinner {
    [DataContract]
    class IngredientIn {
        // Contains:
        // IngredientIn AccountId
        // IngredientIn RecipeId
        // IngredientIn Amount

        // Here to use JSON Deserialize
        public IngredientIn() { }

        public IngredientIn(DataRow row) {
            this.GetOrSetRecipeId = row.Field<int>("ingredientid");
            this.GetOrSetRecipeId = row.Field<int>("recipeid");
            this.GetOrSetRecipeId = row.Field<int>("amount");
        }

        public IngredientIn(int ingredientInIngredientId, int ingredientInRecipeId, int ingredientInAmount) {
            this.GetOrSetIngredientId = ingredientInIngredientId;
            this.GetOrSetRecipeId = ingredientInRecipeId;
            this.GetOrSetAmount = ingredientInAmount;
        }

        [DataMember(Name = "ingredientid")]
        public int GetOrSetIngredientId {
            get {
                return _ingredientInIngredientId;
            }
            set {
                _ingredientInIngredientId = value;
            }
        }
        private int _ingredientInIngredientId;

        [DataMember(Name = "recipeid")]
        public int GetOrSetRecipeId {
            get {
                return _ingredientInRecipeId;
            }
            set {
                _ingredientInRecipeId = value;
            }
        }
        private int _ingredientInRecipeId;

        [DataMember(Name = "amount")]
        public int GetOrSetAmount {
            get {
                return _ingredientInAmount;
            }
            set {
                _ingredientInAmount = value;
            }
        }
        private int _ingredientInAmount;

        public override string ToString() {
            return this.GetOrSetIngredientId
            + " " + this.GetOrSetRecipeId
            + " " + this.GetOrSetAmount;
        }
    }
}
