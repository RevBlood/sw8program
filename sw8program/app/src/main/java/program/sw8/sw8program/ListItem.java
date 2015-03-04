package program.sw8.sw8program;

/**
 * Created by Morten on 20-02-2015.
 */
public class ListItem {
    private int DrawableId = 0;
    private String Name;

    public ListItem(int drawableId, String name) {
        DrawableId = drawableId;
        Name = name;
    }

    public ListItem(String name) {
        Name = name;
    }

    public int getDrawableId() {
        return DrawableId;
    }

    public String getName() {
        return Name;
    }
}
