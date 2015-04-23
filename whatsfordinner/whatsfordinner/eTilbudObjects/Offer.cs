using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whatsfordinner
{
    class Offer
    {
        public String id;
        public String ern;
        public String heading;
        public String description;
        public int catalog_page;
        public Pricing pricing;
        public Quantity quantity;
        public Images images;
        public Links links;
        public String run_from;
        public String run_till;
        public String dealer_url;
        public String store_url;
        public String catalog_url;
        public String dealer_id;
        public String store_id;
        public String catalog_id;
        public IList<String> catagory_ids;
        public Branding branding;

    }

    class Pricing
    {
        public double price;
        public double? pre_price;
        public String currency;

    }

    class Quantity
    {
        public Unit unit;
        public Size size;
        public Piece piece;
    }

    class Unit
    {
        public String symbol;
        public SI si;
    }

    class SI
    {
        public String symbol;
        public double factor;
    }

    class Size
    {
        public double from;
        public double to;
    }

    class Piece
    {
        public int from;
        public int to;
    }

    class Images
    {
        public String view;
        public String zoom;
        public String thumb;
    }

    class Links
    {
        public String webshop;
    }
}
