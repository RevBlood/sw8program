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
import android.widget.Spinner;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.Date;

import Models.Recipe;

public class DiscoverFragment extends Fragment {

    private final int ContextRecipeRemove = 11;

    private Spinner sortbySpinner;
    private SortbySpinnerAdapter SpinnerAdapter;
    //private SortbySpinnerListener SpinnerListener;
    private RecipeListAdapter discAdapter;
    String[] sortStrings = {"Pris","Besparelse","Besparelse","Rating"};

    Date date = new Date();
    BigDecimal bigdiddy = new BigDecimal(3.31231);

    Recipe recipeOne = new Recipe(1,1,"Pøllemix", "flot mad", date, 3, "house", bigdiddy);
    Recipe recipeTwo = new Recipe(3,2,"magiskmad", "flot mad", date, 5, "house", bigdiddy);


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        ViewGroup rootView = (ViewGroup) inflater.inflate(R.layout.fragment_discover, container, false);

        ArrayList<Recipe> recipes = new ArrayList<>();

        recipes.add(recipeOne);
        recipes.add(recipeTwo);

        sortbySpinner = (Spinner) rootView.findViewById(R.id.sortby_spinner);
        SpinnerAdapter = new SortbySpinnerAdapter(getActivity(), R.layout.row_item_sort, sortStrings);
        sortbySpinner.setAdapter(SpinnerAdapter);

        ListView recipeList = (ListView) rootView.findViewById(R.id.recipe_list);
        recipeList.setEmptyView(rootView.findViewById(R.id.empty));
        discAdapter = new RecipeListAdapter(getActivity(), R.layout.row_item_recipe,recipes);
        recipeList.setAdapter(discAdapter);

        registerForContextMenu(recipeList);

        return rootView;
    }

    @Override
    public void onCreateContextMenu(ContextMenu menu, View v, ContextMenu.ContextMenuInfo menuInfo) {
        super.onCreateContextMenu(menu, v, menuInfo);
        AdapterView.AdapterContextMenuInfo info = (AdapterView.AdapterContextMenuInfo) menuInfo;

        //Recipe name as title for menu
        String title = (discAdapter.getItem(info.position)).getName();
        menu.setHeaderTitle(title);

        //Create menu entry for deleting the recipe
        menu.add(Menu.NONE, ContextRecipeRemove, Menu.NONE, getString(R.string.not_interested));
    }

    @Override
    public boolean onContextItemSelected(MenuItem item) {
        //Figure what menu entry was pressed
        switch (item.getItemId()) {
            case ContextRecipeRemove:
                //Find the item that was pressed and delete it
                AdapterView.AdapterContextMenuInfo info = (AdapterView.AdapterContextMenuInfo) item.getMenuInfo();
                discAdapter.getItem(info.position);
                discAdapter.remove(discAdapter.getItem(info.position));
                return true;
            //If case was not found, return false. This causes Android to look in other overrides for a case that matches
            default: return false;
        }
    }

}