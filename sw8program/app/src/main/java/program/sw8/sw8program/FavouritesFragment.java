package program.sw8.sw8program;

import android.content.SharedPreferences;
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

import Helpers.ServiceHelper;
import Models.Recipe;

public class FavouritesFragment extends Fragment implements View.OnCreateContextMenuListener{
    private final int ContextFavouriteRemove = 11;
    private RecipeListAdapter FavAdapter;
    String[] sortStrings = {"Pris","Besparelse","Besparelse","Rating"};
    ArrayList<Recipe> Recipes = new ArrayList<>();
    Date date = new Date();
    BigDecimal bigdiddy = new BigDecimal(3.31231);
    Integer AccountId;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        ViewGroup rootView = (ViewGroup) inflater.inflate(R.layout.fragment_favourites, container, false);

        //TODO: Remove debug
        if(getString(R.string.debug).equals("on")) {
            Recipes.add(new Recipe(1, 1, "Poelsemix", "Semper nascetur class pretium. Fusce nibh vel ac, suscipit sagittis, lobortis viverra. Integer odio nulla a parturient, nulla luctus massa adipiscing senectus lectus. Diam felis amet metus, donec ac vivamus orci cras sed, lacus enim mattis eu, velit tristique, faucibus fusce nulla velit. Odio non nunc vel mi malesuada diam. Vivamus nam ante, primis massa nec placerat justo posuere sociis, sit maecenas eget ac condimentum. Integer a sem id, est maecenas hendrerit aliquam est in lacus, mollis quis tempor risus sollicitudin vitae. Rutrum eleifend, nunc magnis enim turpis sem condimentum porttitor, aliquam ornare felis sed. Elit integer vitae sem, neque cursus lobortis arcu pede tortor amet.", date, 3, "house", bigdiddy));
            Recipes.add(new Recipe(3, 2, "Flaeskesteg", "flot mad", date, 5, "house", bigdiddy));
        } else {
            //Get user id from shared preferences.  In case the list retrieved is null, instantiate Recipes again to avoid NullPointerException
            SharedPreferences session = getActivity().getApplicationContext().getSharedPreferences(getString(R.string.app_name), 0);
            AccountId = session.getInt("id", -1);
            Recipes = ServiceHelper.GetFavorisedRecipesByAccountId(AccountId);
            if (Recipes == null) {
                Recipes = new ArrayList<>();
            }
        }

        Spinner sortbySpinner = (Spinner) rootView.findViewById(R.id.sortby_spinner);
        SortbySpinnerAdapter SpinnerAdapter = new SortbySpinnerAdapter(getActivity(), R.layout.row_item_sort, sortStrings);
        sortbySpinner.setAdapter(SpinnerAdapter);

        ListView listOfRecipes = (ListView) rootView.findViewById(R.id.list_favourites);
        listOfRecipes.setEmptyView(rootView.findViewById(R.id.empty));
        FavAdapter = new RecipeListAdapter(getActivity(), R.layout.row_item_recipe, Recipes);
        listOfRecipes.setAdapter(FavAdapter);

        registerForContextMenu(listOfRecipes);

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

                //TODO: Remove debug
                if (getString(R.string.debug).equals("off")) {
                    if (ServiceHelper.DeleteFavorises(AccountId, FavAdapter.getItem(info.position).getId())) {
                        FavAdapter.remove(FavAdapter.getItem(info.position));
                    } else {
                        //TODO: Complain to user about shitty server
                    }
                } else {
                    FavAdapter.remove(FavAdapter.getItem(info.position));
                }

                return true;
            //If case was not found, return false. This causes Android to look in other overrides for a case that matches
            default: return false;
        }
    }
}