using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whatsfordinner
{
    class Store
    {
        public String id;
        public String ern;
        public String street;
        public String city;
        public String zip_code;
        public Country country;
        public double latitude;
        public double longitude;
        public String dealer_url;
        public String dealer_id;
        public Branding branding;
        public String contact;
        public IList<String> category_ids;

    }
}
