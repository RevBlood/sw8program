using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace whatsfordinner {
    [ServiceContract]
    public interface IRetailer {
        [OperationContract]
        void AddRetailer(Retailer ret);
        [OperationContract]
        Retailer GetRetailerById(int retailerId);
        [OperationContract]
        List<Retailer> GetAllRetailers();
        [OperationContract]
        void DeleteRetById(int retailerId);
    }
}
