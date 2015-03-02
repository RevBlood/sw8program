using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace whatsfordinner {
    [ServiceContract]
    public interface IPictures {
        [OperationContract]
        void AddPictures(Pictures pic);
        [OperationContract]
        List<Pictures> GetPicturesByRecipeId(int recipeId);
        [OperationContract]
        void DeletePicByAccountIdAndRecipeId(int accountId, int recipeId);
    }
}
