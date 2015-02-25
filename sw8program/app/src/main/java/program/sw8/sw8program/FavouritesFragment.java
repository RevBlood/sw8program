package program.sw8.sw8program;

import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.ContextMenu;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ListView;

import java.util.ArrayList;

public class FavouritesFragment extends Fragment implements View.OnCreateContextMenuListener{

    private FavouritesAdapter FavAdapter;
    private final int ContextFavouriteRemove = 11;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        ViewGroup rootView = (ViewGroup) inflater.inflate(R.layout.fragment_favourites, container, false);
        ArrayList<ListItem> favourites = new ArrayList<>();

        //Test data for favourite list
        favourites.add(new ListItem(R.drawable.placeholder_recipe_2, "Awesome sauce"));
        favourites.add(new ListItem(R.drawable.placeholder_recipe_1, "Din mors sauce"));

        ListView list = (ListView) rootView.findViewById(R.id.list_favourites);
        list.setEmptyView(rootView.findViewById(R.id.empty));

        //Set the adapter to control the list
        FavAdapter = new FavouritesAdapter(getActivity(), R.layout.row_item_favourites, favourites);
        list.setAdapter(FavAdapter);
        registerForContextMenu(list);

        return rootView;
    }

    @Override
    public void onCreateContextMenu(ContextMenu menu, View v, ContextMenu.ContextMenuInfo menuInfo) {
        super.onCreateContextMenu(menu, v, menuInfo);
        AdapterView.AdapterContextMenuInfo info = (AdapterView.AdapterContextMenuInfo) menuInfo;

        //Recipe name as title for menu
        String title = (FavAdapter.getItem(info.position)).getName();
        menu.setHeaderTitle(title);

        //Create menu entry for deleting the recipe
        menu.add(Menu.NONE, ContextFavouriteRemove, Menu.NONE, getString(R.string.favourite_remove));
    }

    @Override
    public boolean onContextItemSelected(MenuItem item) {

        //Figure what menu entry was pressed
        switch (item.getItemId()) {
            case ContextFavouriteRemove:
                //Find the item that was pressed and delete it
                AdapterView.AdapterContextMenuInfo info = (AdapterView.AdapterContextMenuInfo) item.getMenuInfo();
                FavAdapter.getItem(info.position);
                FavAdapter.remove(FavAdapter.getItem(info.position));
                return true;
            default: return false;
        }
    }
}