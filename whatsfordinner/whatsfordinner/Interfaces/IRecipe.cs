using System;
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
        Recipe GetRecipeById(int recId);
        [OperationContract]
        List<Recipe> GetRecipesByAccountId(int accountId);
        [OperationContract]
        List<Recipe> GetAllRecipes();
        [OperationContract]
        void DeleteRecById(int recId);
    }
}
