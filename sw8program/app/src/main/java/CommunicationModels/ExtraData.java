package CommunicationModels;

import java.math.BigDecimal;

/**
 * Created by Morten on 27-04-2015.
 */
public class ExtraData {

    public BigDecimal Price;
    public BigDecimal SavingsStorePrice;

    public ExtraData(BigDecimal price, BigDecimal savingsStorePrice) {
        Price = price;
        SavingsStorePrice = savingsStorePrice;
    }
}
