using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whatsfordinner
{
    class Dealer {

        String id;
        String ern;
        String name;
        String url_name;
        String website;
        String logo;
        String color;
        Pageflip pageflip;
        IList<String> category_ids;
        Country country;
        String favorite_count;

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

        public string Ern
        {
            get
            {
                return ern;
            }

            set
            {
                ern = value;
            }
        }

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

        public IList<string> Category_ids
        {
            get
            {
                return category_ids;
            }

            set
            {
                category_ids = value;
            }
        }

        internal Country Country
        {
            get
            {
                return country;
            }

            set
            {
                country = value;
            }
        }

        public string Favorite_count
        {
            get
            {
                return favorite_count;
            }

            set
            {
                favorite_count = value;
            }
        }

    }
}
