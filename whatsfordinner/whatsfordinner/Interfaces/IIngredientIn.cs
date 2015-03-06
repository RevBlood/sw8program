using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace whatsfordinner {
    [ServiceContract]
    public interface IIngredientIn {
        [OperationContract]
        void AddIngredientIn(IngredientIn ing);
        [OperationContract]
        List<IngredientIn> GetIngredientInsByIngredientId(int ingredientId);
        [OperationContract]
        List<IngredientIn> GetIngredientInsByRecipeId(int recipeId);
        [OperationContract]
        void DeleteIngredientInByIngredientIdAndRecipeId(int ingredientId, int recipeId);
    }
}
