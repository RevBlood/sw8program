package program.sw8.sw8program;

import android.content.Context;
import android.util.Log;
import android.view.ContextMenu;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ImageButton;
import android.widget.ImageView;
import android.widget.TextView;

import java.util.List;

/**
 * Created by Morten on 20-02-2015.
 */
public class FavouritesAdapter extends ArrayAdapter<ListItem> implements View.OnCreateContextMenuListener {
    List<ListItem> Favourites;
    Context FavouritesFragmentContext;
    int LayoutId;

    public FavouritesAdapter(Context favouritesFragmentContext, int layoutId, List<ListItem> favourites) {
        super(favouritesFragmentContext, layoutId, favourites);

        Favourites = favourites;
        FavouritesFragmentContext = favouritesFragmentContext;
        LayoutId = layoutId;
    }

    @Override
    public View getView(int position, View view, ViewGroup parent) {
        //Find relevant elements from the layout
        LayoutInflater inflater = (LayoutInflater) FavouritesFragmentContext.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        View row = inflater.inflate(LayoutId, parent, false);

        ImageView recipeImageView = (ImageView) row.findViewById(R.id.row_item_image);
        TextView recipeNameView = (TextView) row.findViewById(R.id.row_item_name);
        View recipeLayout = row.findViewById(R.id.row_recipe_layout);
        ImageButton toggleFavouriteButton = (ImageButton) row.findViewById(R.id.row_item_toggle_favourite);

        //Set text of view
        recipeNameView.setText(Favourites.get(position).getName());

        //Override stock image, only if recipe has an image. 0 indicates no image
        if ((Favourites.get(position).getDrawableId() != 0)) {
            recipeImageView.setImageResource(Favourites.get(position).getDrawableId());
        }

        //Set listeners to open recipe or toggle favourite
        toggleFavouriteButton.setOnClickListener(onToggleFavouriteListener);
        recipeLayout.setOnClickListener(onRecipeClickListener);
        recipeLayout.setOnCreateContextMenuListener(this);

        return row;
    }

    View.OnClickListener onRecipeClickListener = new View.OnClickListener() {
        @Override
        public void onClick(View v) {
            Log.w("fuck", "2");
        }
    };

    View.OnClickListener onToggleFavouriteListener = new View.OnClickListener() {
        @Override
        public void onClick(View v) {
            Log.w("fuck", "1");
        }
    };

    public void onCreateContextMenu(ContextMenu contextMenu, View view, ContextMenu.ContextMenuInfo contextMenuInfo) {
        // Pray that FavouritesFragment implements this
    }
}
