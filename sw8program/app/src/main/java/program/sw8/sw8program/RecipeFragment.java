package program.sw8.sw8program;

import android.content.SharedPreferences;
import android.content.res.Resources;
import android.graphics.drawable.Drawable;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.view.ViewPager;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageButton;
import android.widget.LinearLayout;
import android.widget.TextView;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.List;

import Helpers.JSONHelper;
import Helpers.ServiceHelper;
import Models.Ingredient;
import Models.Recipe;
import Relationships.Favorises;

public class RecipeFragment extends Fragment {
    List<Drawable> RecipeImages = new ArrayList<>();
    List<Ingredient> RecipeIngredients = new ArrayList<>();
    String JSONRecipe;
    Recipe recipe;
    Integer AccountId;
    Integer RecipeId;
    ImageButton RecipeFavouriteToggleButton;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        ViewGroup rootView = (ViewGroup) inflater.inflate(R.layout.fragment_recipe, container, false);

        SharedPreferences session = getActivity().getApplicationContext().getSharedPreferences(getString(R.string.app_name), 0);
        AccountId = session.getInt("id", -1);

        JSONRecipe = getActivity().getIntent().getStringExtra("recipe");
        RecipeId = getActivity().getIntent().getIntExtra("id", -1);
        Log.d("RecipeActivity", "this is what is in the intent for RecipeFragment: " + JSONRecipe);
        recipe = JSONHelper.Deserialize(JSONRecipe, Recipe.class);
        Log.d("RecipeActivity","this is the name of the recipe used in RecipeActivity: " + recipe.getName());
        recipe.setId(RecipeId);

        TextView recipeNameView = (TextView) rootView.findViewById(R.id.recipe_name);
        RecipeFavouriteToggleButton = (ImageButton) rootView.findViewById(R.id.toggle_favourite);
        ViewPager recipeImagePager = (ViewPager) rootView.findViewById(R.id.paged_image_layout);
        LinearLayout recipeIngredientLayout = (LinearLayout) rootView.findViewById(R.id.ingredient_layout);
        TextView recipePreparationView = (TextView) rootView.findViewById(R.id.preparation_text);

        RecipeFavouriteToggleButton.setOnClickListener(toggleFavouriteListener);

        ArrayList<Favorises> favourites = ServiceHelper.GetFavorisesByAccountId(AccountId);
        Favorises toCompare = new Favorises(AccountId, recipe.getId());
        for (Favorises f : favourites) {
            if (f.equals(toCompare)) {
                RecipeFavouriteToggleButton.setSelected(true);
                break;
            }
        }

        PreparePictures();
        PrepareIngredients();

        //Populate views and set adapters
        recipeNameView.setText(recipe.getName());
        recipePreparationView.setText(recipe.getDescription());

        RecipeImageAdapter recipeImageAdapter = new RecipeImageAdapter(getActivity(), RecipeImages);
        recipeImagePager.setAdapter(recipeImageAdapter);

        RecipeIngredientAdapter recipeIngredientAdapter = new RecipeIngredientAdapter(getActivity(), R.layout.row_item_ingredients, RecipeIngredients);

        for (int i = 0; i < RecipeIngredients.size(); i++) {
            Log.d("RecipeActivity","This is an ingredient in the list: " + RecipeIngredients.get(i).getName());
            View row = recipeIngredientAdapter.getView(i, null, null);
            recipeIngredientLayout.addView(row);
        }

        return rootView;
    }

    public void PrepareIngredients() {
        if (getString(R.string.debug).equals("on")) {
            BigDecimal biggie = new BigDecimal(5.0);
            RecipeIngredients.add(new Ingredient("One", "ingredientMeasurementType", "ingredientMeasure", biggie, "ingredientTags"));
            RecipeIngredients.add(new Ingredient("Two", "ingredientMeasurementType", "ingredientMeasure", biggie, "ingredientTags"));
            RecipeIngredients.add(new Ingredient("Three", "ingredientMeasurementType", "ingredientMeasure", biggie, "ingredientTags"));
        } else {
            RecipeIngredients = ServiceHelper.GetIngredientsByRecipeId(recipe.getId());
        }
    }

    public void PreparePictures() {
        Resources r = getResources();

        if (getString(R.string.debug).equals("on")) {
            RecipeImages.add(r.getDrawable(R.drawable.placeholder_recipe_1));
            RecipeImages.add(r.getDrawable(R.drawable.placeholder_recipe_2));
        } else {
            //TODO: fix whenever pictures is supported.
        }
    }

    ImageButton.OnClickListener toggleFavouriteListener = new ImageButton.OnClickListener() {
        @Override
        public void onClick(View v) {
            if (getString(R.string.debug).equals("off")) {
                if (!RecipeFavouriteToggleButton.isSelected()) {
                    if (ServiceHelper.PostFavorises(new Favorises(AccountId, recipe.getId()))) {
                        RecipeFavouriteToggleButton.setSelected(true);
                    } else {
                        //TODO: Handle that server was shit.
                    }
                } else {
                    if (ServiceHelper.DeleteFavorises(AccountId, recipe.getId())) {

                        RecipeFavouriteToggleButton.setSelected(false);
                    } else {
                        //TODO: Handle server pooped
                    }
                }
            } else {
                RecipeFavouriteToggleButton.setSelected(!RecipeFavouriteToggleButton.isSelected());
            }
        }
    };
}
