using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whatsfordinner
{
    class Branding {

        String name;
        String url_name;
        String website;
        String logo;
        String logo_background;
        String color;
        Pageflip pageflip;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Url_name
        {
            get
            {
                return url_name;
            }

            set
            {
                url_name = value;
            }
        }

        public string Website
        {
            get
            {
                return website;
            }

            set
            {
                website = value;
            }
        }

        public string Logo
        {
            get
            {
                return logo;
            }

            set
            {
                logo = value;
            }
        }

        public string Logo_background
        {
            get
            {
                return logo_background;
            }

            set
            {
                logo_background = value;
            }
        }

        public string Color
        {
            get
            {
                return color;
            }

            set
            {
                color = value;
            }
        }

        internal Pageflip Pageflip
        {
            get
            {
                return pageflip;
            }

            set
            {
                pageflip = value;
            }
        }
    }
}
