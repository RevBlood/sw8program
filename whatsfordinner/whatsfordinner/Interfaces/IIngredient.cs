using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace whatsfordinner {
    [ServiceContract]
    public interface IIngredient {
        [OperationContract]
        void AddIngredient(Ingredient ing);
        [OperationContract]
        Ingredient GetIngredientById(int ingId);
        [OperationContract]
        Ingredient GetIngredientByName(string name);
        [OperationContract]
        List<Ingredient> GetAllIngredients();
        [OperationContract]
        List<Ingredient> GetIngredientsByRecipeId(int recipeId);
        [OperationContract]
        void DeleteIngById(int ingId);
    }
}
