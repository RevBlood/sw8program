package program.sw8.sw8program;

/**
 * Created by Morten on 04-03-2015.
 */
public class Ingredient {
    private String Amount;
    private String Name;

    public Ingredient (String amount, String name) {
        Amount = amount;
        Name = name;
    }

    public String getAmount() {
        return Amount;
    }

    public String getName() {
        return Name;
    }
}
