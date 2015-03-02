using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace whatsfordinner {
    public partial class RestService : IHasEaten {

        [WebInvoke(Method = "POST", UriTemplate = "AddHasEaten", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public void AddHasEaten(HasEaten has) {
            DBController dbc = new DBController();
            dbc.AddHasEaten(has);
            dbc.Close();
        }
    }
}
