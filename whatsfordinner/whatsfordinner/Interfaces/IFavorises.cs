using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace whatsfordinner {
    [ServiceContract]
    public interface IFavorises {
        [OperationContract]
        void AddFavorises(Favorises fav);
        [OperationContract]
        List<Favorises> GetFavorisesByAccountId(int accountId);
        [OperationContract]
        List<Favorises> GetFavorisesByRecipeId(int recipeId);
        [OperationContract]
        List<Recipe> GetFavorisedRecipesByAccountId(int accountId);
        [OperationContract]
        void DeleteFavorisesByAccountIdAndRecipeId(int accountId, int recipeId);
    }
}
