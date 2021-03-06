﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace whatsfordinner {
    [ServiceContract]
    public interface IRecipe {
        [OperationContract]
        void AddRecipe(Recipe rec);
        [OperationContract]
        Recipe GetRecipeById(int recipeId);
        [OperationContract]
        List<Recipe> GetRecipesByAccountId(int accountId);
        [OperationContract]
        List<Recipe> GetRecipesByIngredientId(int ingredientId);
        [OperationContract]
        RecipeWithIngredients GetRecipesByIdWithIngredients(int recipeId);
        [OperationContract]
        RecipeWithExtradata GetRecipesWithExtraData(int pricePreference, int savingsPreference, int numberOfRecipes, int radius, double latitude, double longitude);
        [OperationContract]
        List<Recipe> GetAllRecipes();
        [OperationContract]
        bool DeleteRecById(int recipeId);
    }
}
