using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace whatsfordinner {
    [ServiceContract]
    public interface IHasEaten {
        [OperationContract]
        void AddHasEaten(HasEaten has);

    }
}
