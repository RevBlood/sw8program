package program.sw8.sw8program;

import android.content.SharedPreferences;
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
import java.util.Collections;
import java.util.Comparator;
import java.util.Date;

import Helpers.ServiceHelper;
import Models.Recipe;

public class DiscoverFragment extends Fragment {

    private final int ContextRecipeRemove = 11;

    private Spinner sortbySpinner;
    private SortbySpinnerAdapter SpinnerAdapter;
    private RecipeListAdapter discAdapter;
    String[] sortStrings = {"Pris","Besparelse","Besparelse","Rating"};

    Date date = new Date();
    BigDecimal bigdiddy = new BigDecimal(3.91231);
    BigDecimal bigdaddy = new BigDecimal(3.41231);

    ArrayList<Recipe> recipes;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        ViewGroup rootView = (ViewGroup) inflater.inflate(R.layout.fragment_discover, container, false);

        ArrayList<Recipe> recipes = new ArrayList<>();

        //TODO: Remove debug
        if(getString(R.string.debug).equals("on")) {
            recipes.add(new Recipe(1, 1, "Pøllemix", "Semper nascetur class pretium. Fusce nibh vel ac, suscipit sagittis, lobortis viverra. Integer odio nulla a parturient, nulla luctus massa adipiscing senectus lectus. Diam felis amet metus, donec ac vivamus orci cras sed, lacus enim mattis eu, velit tristique, faucibus fusce nulla velit. Odio non nunc vel mi malesuada diam. Vivamus nam ante, primis massa nec placerat justo posuere sociis, sit maecenas eget ac condimentum. Integer a sem id, est maecenas hendrerit aliquam est in lacus, mollis quis tempor risus sollicitudin vitae. Rutrum eleifend, nunc magnis enim turpis sem condimentum porttitor, aliquam ornare felis sed. Elit integer vitae sem, neque cursus lobortis arcu pede tortor amet.", date, 3, "house", bigdiddy));
            recipes.add(new Recipe(3, 2, "magiskmad", "flot mad", date, 5, "house", bigdaddy));
        } else {

            //TODO: this shit is wrong - we need a method for discovering based on something (e.g search by ingredient, price limitation or whatever)
            recipes = ServiceHelper.GetRecipesByIngredientId(1);
        }

        sortbySpinner = (Spinner) rootView.findViewById(R.id.sortby_spinner);
        SpinnerAdapter = new SortbySpinnerAdapter(getActivity(), R.layout.row_item_sort, sortStrings);
        sortbySpinner.setAdapter(SpinnerAdapter);

        ListView recipeList = (ListView) rootView.findViewById(R.id.recipe_list);
        recipeList.setEmptyView(rootView.findViewById(R.id.empty));
        discAdapter = new RecipeListAdapter(getActivity(), R.layout.row_item_recipe,recipes);
        recipeList.setAdapter(discAdapter);
        sortbySpinner.setOnItemSelectedListener(spinnerListener);

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

    public ArrayList<Recipe> SortBy(Integer i, ArrayList<Recipe> _recipes) {
        switch (i) {
            case 0:
                discAdapter.sort(new Comparator<Recipe>() {
                    @Override
                    public int compare(Recipe recipe, Recipe recipe2) {
                        return ((Integer) recipe.getNumberOfServings()).compareTo(recipe2.getNumberOfServings());
                        // return recipe.getPrice().compareTo(recipe2.getPrice());
                    }
                });
                break;
            case 1:
                discAdapter.sort(new Comparator<Recipe>() {
                    @Override
                    public int compare(Recipe recipe, Recipe recipe2) {
                        return ((Integer) recipe.getId()).compareTo(recipe2.getId());
                        // return recipe.getSavingsInPrice().compareTo(recipe2.getSavingsInPrice());
                    }
                });
                break;
            case 2:
                discAdapter.sort(new Comparator<Recipe>() {
                @Override
                public int compare(Recipe recipe, Recipe recipe2) {
                    return ((Integer) recipe.getId()).compareTo(recipe2.getId());
                    // return recipe.getSavingsInPrice().compareTo(recipe2.getSavingsInPrice());
                    }
                });
                break;
            case 3:
                discAdapter.sort(new Comparator<Recipe>() {
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
            SortBy(i, recipes);
            discAdapter.notifyDataSetChanged();
        }

        @Override
        public void onNothingSelected(AdapterView<?> adapterView) {
            Log.e("fuck", "Johan er til mænd");
        }
    };

}