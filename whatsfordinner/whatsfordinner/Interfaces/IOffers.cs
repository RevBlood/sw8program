using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace whatsfordinner {
    [ServiceContract]
    public interface IOffers {
        [OperationContract]
        void AddOffers(Offers off);
        [OperationContract]
        List<Offers> GetOffersByRetailerId(int retailerId);
        [OperationContract]
        List<Offers> GetOffersByIngredientId(int ingredientId);
        [OperationContract]
        void DeleteOffersByRetailerIdAndIngredientId(int retailerId, int ingredientId);
    }
}
