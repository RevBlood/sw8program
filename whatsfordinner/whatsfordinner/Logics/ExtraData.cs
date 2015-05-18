using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whatsfordinner {
    public class ExtraData {

        public decimal Price;
        public decimal SavingStorePrice;
        public decimal SavingGeneralPrice;
        public decimal SavingStorePercent;
        public decimal SavingGeneralPercent;
        public int RetailerId;
        public decimal Rating = 0;

        public ExtraData(decimal price, decimal savingStorePrice, decimal savingGeneralPrice, decimal savingStorePercent, 
                            decimal savingGeneralPercent, int retailerId) {

            this.Price = price;
            this.SavingStorePrice = savingStorePrice;
            this.SavingGeneralPrice = savingGeneralPrice;
            this.SavingStorePercent = savingStorePercent;
            this.SavingGeneralPercent = savingGeneralPercent;
            this.RetailerId = retailerId;
        }
    }
}
