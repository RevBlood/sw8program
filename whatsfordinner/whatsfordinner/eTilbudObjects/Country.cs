using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whatsfordinner
{
    class Country
    {
        String id;
        String unsubscribe_print_url;

        public string Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Unsubscribe_print_url
        {
            get
            {
                return unsubscribe_print_url;
            }

            set
            {
                unsubscribe_print_url = value;
            }
        }
    }
}
