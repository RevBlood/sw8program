package program.sw8.sw8program;

import android.content.res.Resources;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.Toast;

import java.util.ArrayList;

public class FavouritesFragment extends Fragment {

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        ViewGroup rootView = (ViewGroup) inflater.inflate(R.layout.fragment_favourites, container, false);

        ArrayList<ListItem> favourites = new ArrayList<>();

        //Test data for favourite list
        favourites.add(new ListItem(R.drawable.placeholder_recipe_2, "Awesome sauce"));
        favourites.add(new ListItem(R.drawable.placeholder_recipe_1, "Din mors sauce"));

        ListView list = (ListView) rootView.findViewById(R.id.list_favourites);

        //Set the adapter to control the list
        FavouritesAdapter favouritesAdapter = new FavouritesAdapter(getActivity(), R.layout.row_item_favourites, favourites);
        list.setAdapter(favouritesAdapter);

        return rootView;
    }
}