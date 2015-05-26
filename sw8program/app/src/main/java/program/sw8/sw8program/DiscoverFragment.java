package program.sw8.sw8program;

import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.util.Log;
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
import java.util.Comparator;
import java.util.Date;

import Helpers.ServiceHelper;
import Models.Recipe;

public class DiscoverFragment extends Fragment {

    private final int ContextRecipeRemove = 11; //TODO: This value is copy-pasted from FavouritesFragment. It's not allowed to be 11. Need fix.
    private final String[] DropDownOptions = {"Pris", "Besparelse", "Besparelse", "Rating"};
    private ArrayList<Recipe> Recipes = new ArrayList<>();
    private RecipeListAdapter RecipeAdapter;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        ViewGroup rootView = (ViewGroup) inflater.inflate(R.layout.fragment_discover, container, false);

        //TODO: Remove debug
        if(getString(R.string.debug).equals("on")) {
            Recipes.add(new Recipe(1, 1, "Poelsemix", "Semper nascetur class pretium. Fusce nibh vel ac, suscipit sagittis, lobortis viverra. Integer odio nulla a parturient, nulla luctus massa adipiscing senectus lectus. Diam felis amet metus, donec ac vivamus orci cras sed, lacus enim mattis eu, velit tristique, faucibus fusce nulla velit. Odio non nunc vel mi malesuada diam. Vivamus nam ante, primis massa nec placerat justo posuere sociis, sit maecenas eget ac condimentum. Integer a sem id, est maecenas hendrerit aliquam est in lacus, mollis quis tempor risus sollicitudin vitae. Rutrum eleifend, nunc magnis enim turpis sem condimentum porttitor, aliquam ornare felis sed. Elit integer vitae sem, neque cursus lobortis arcu pede tortor amet.", new Date(), 3, "house", new BigDecimal(3.91231)));
            Recipes.add(new Recipe(3, 2, "Flaeskesteg", "flot mad", new Date(), 5, "house", new BigDecimal(3.41231)));
        } else {
            //TODO: this shit is wrong - we need a method for discovering based on something (e.g search by ingredient, price limitation or whatever)
            //Try to retrieve recipes from server. In case the list retrieved is null, instantiate Recipes again to avoid NullPointerException
            Recipes = ServiceHelper.GetRecipesByIngredientId(1);
            if (Recipes == null) {
                Recipes = new ArrayList<>();
            }
        }

        Spinner sortbySpinner = (Spinner) rootView.findViewById(R.id.sortby_spinner);
        SortbySpinnerAdapter SpinnerAdapter = new SortbySpinnerAdapter(getActivity(), R.layout.row_item_sort, DropDownOptions);
        sortbySpinner.setAdapter(SpinnerAdapter);

        ListView recipeList = (ListView) rootView.findViewById(R.id.recipe_list);
        recipeList.setEmptyView(rootView.findViewById(R.id.empty));
        RecipeAdapter = new RecipeListAdapter(getActivity(), R.layout.row_item_recipe, Recipes);
        recipeList.setAdapter(RecipeAdapter);
        sortbySpinner.setOnItemSelectedListener(spinnerListener);

        registerForContextMenu(recipeList);

        return rootView;
    }

    @Override
    public void onCreateContextMenu(ContextMenu menu, View v, ContextMenu.ContextMenuInfo menuInfo) {
        super.onCreateContextMenu(menu, v, menuInfo);
        AdapterView.AdapterContextMenuInfo info = (AdapterView.AdapterContextMenuInfo) menuInfo;

        //Recipe name as title for menu
        String title = (RecipeAdapter.getItem(info.position)).getName();
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
                RecipeAdapter.getItem(info.position);
                RecipeAdapter.remove(RecipeAdapter.getItem(info.position));
                return true;
            //If case was not found, return false. This causes Android to look in other overrides for a case that matches
            default: return false;
        }
    }

    public ArrayList<Recipe> SortBy(Integer i, ArrayList<Recipe> _recipes) {
        switch (i) {
            case 0:
                RecipeAdapter.sort(new Comparator<Recipe>() {
                    @Override
                    public int compare(Recipe recipe, Recipe recipe2) {
                        return ((Integer) recipe.getNumberOfServings()).compareTo(recipe2.getNumberOfServings());
                        // return recipe.getPrice().compareTo(recipe2.getPrice());
                    }
                });
                break;
            case 1:
                RecipeAdapter.sort(new Comparator<Recipe>() {
                    @Override
                    public int compare(Recipe recipe, Recipe recipe2) {
                        return ((Integer) recipe.getId()).compareTo(recipe2.getId());
                        // return recipe.getSavingsInPrice().compareTo(recipe2.getSavingsInPrice());
                    }
                });
                break;
            case 2:
                RecipeAdapter.sort(new Comparator<Recipe>() {
                @Override
                public int compare(Recipe recipe, Recipe recipe2) {
                    return ((Integer) recipe.getId()).compareTo(recipe2.getId());
                    // return recipe.getSavingsInPrice().compareTo(recipe2.getSavingsInPrice());
                    }
                });
                break;
            case 3:
                RecipeAdapter.sort(new Comparator<Recipe>() {
                    @Override
                    public int compare(Recipe recipe, Recipe recipe2) {
                        return recipe.getRating().compareTo(recipe2.getRating());
                    }
                });
                break;
            default:
        }
        return _recipes;
    }

    public AdapterView.OnItemSelectedListener spinnerListener = new AdapterView.OnItemSelectedListener() {
        @Override
        public void onItemSelected(AdapterView<?> adapterView, View view, int i, long l) {
            SortBy(i, Recipes);
            RecipeAdapter.notifyDataSetChanged();
        }

        @Override
        public void onNothingSelected(AdapterView<?> adapterView) {
        }
    };

}