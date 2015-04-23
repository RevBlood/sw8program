using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace whatsfordinner {
    [DataContract]

    class RecipeWithExtradata {

        private Dictionary<Recipe, ExtraData> _recipeWithExtraData;

        public RecipeWithExtradata() { }

        public RecipeWithExtradata(Dictionary<Recipe, ExtraData> sortedData) {

            this.GetOrSetRecipeWithExtraData = sortedData;
        }

        [DataMember(Name = "recipeWithExtraData")]
        public Dictionary<Recipe, ExtraData> GetOrSetRecipeWithExtraData {
            get {
                return _recipeWithExtraData;
            }
            set {
                _recipeWithExtraData = value;
            }
        }
    }
}
