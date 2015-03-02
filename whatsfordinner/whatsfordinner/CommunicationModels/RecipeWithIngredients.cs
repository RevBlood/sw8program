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
    public class RecipeWithIngredients {

        // Here to use JSON Deserialize
        public RecipeWithIngredients() { }

        public RecipeWithIngredients(Recipe recipe, List<Ingredient> ingredients, List<IngredientIn> amounts) {
            this.GetOrSetRecipe = recipe;
            this.GetOrSetIngredients = ingredients;
            this.GetOrSetIngredientIns = amounts;
        }

        [DataMember(Name = "recipe")]
        public Recipe GetOrSetRecipe {
            get {
                return _privateRecipe;
            }
            set {
                _privateRecipe = value;
            }
        }
        private Recipe _privateRecipe;

        [DataMember(Name = "ingredients")]
        public List<Ingredient> GetOrSetIngredients {
            get {
                return _privateIngredients;
            }
            set {
                _privateIngredients = value;
            }
        }
        private List<Ingredient> _privateIngredients;

        [DataMember(Name = "amounts")]
        public List<IngredientIn> GetOrSetIngredientIns {
            get {
                return _privateIngredientIns;
            }
            set {
                _privateIngredientIns = value;
            }
        }
        private List<IngredientIn> _privateIngredientIns;
    }
}
