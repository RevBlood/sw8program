package program.sw8.sw8program;

import android.content.res.Resources;
import android.graphics.drawable.Drawable;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.view.ViewPager;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.LinearLayout;
import android.widget.TextView;

import java.util.ArrayList;
import java.util.List;

import Helpers.JSONHelper;
import Models.Recipe;


public class RecipeFragment extends Fragment {

    List<Drawable> RecipeImages = new ArrayList<>();
    List<Ingredient> RecipeIngredients = new ArrayList<>();

    String JSONRecipe;

    Recipe recipe;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        ViewGroup rootView = (ViewGroup) inflater.inflate(R.layout.fragment_recipe, container, false);

        JSONRecipe = getActivity().getIntent().getStringExtra("recipe");

        Log.d("this is JSONrecipe:", JSONRecipe);

        recipe = JSONHelper.Deserialize(JSONRecipe, Recipe.class);

        Log.d("this is JSONrecipe:", recipe.getName());


        TextView recipeNameView = (TextView) rootView.findViewById(R.id.recipe_name);
        ViewPager recipeImagePager = (ViewPager) rootView.findViewById(R.id.paged_image_layout);
        LinearLayout recipeIngredientLayout = (LinearLayout) rootView.findViewById(R.id.ingredient_layout);
        TextView recipePreparationView = (TextView) rootView.findViewById(R.id.preparation_text);


        Resources r = getResources();
        RecipeImages.add(r.getDrawable(R.drawable.placeholder_recipe_1));
        RecipeImages.add(r.getDrawable(R.drawable.placeholder_recipe_2));

        RecipeIngredients.add(new Ingredient("2 kg", "spices"));
        RecipeIngredients.add(new Ingredient("2 tsk", "shit"));
        RecipeIngredients.add(new Ingredient("15 minutes", "love"));
        RecipeIngredients.add(new Ingredient("3g", "salt"));

        //Populate views and set adapters
        recipeNameView.setText(recipe.getName());
        recipePreparationView.setText(recipe.getDescription());

        RecipeImageAdapter recipeImageAdapter = new RecipeImageAdapter(getActivity(), RecipeImages);
        recipeImagePager.setAdapter(recipeImageAdapter);

        RecipeIngredientAdapter recipeIngredientAdapter = new RecipeIngredientAdapter(getActivity(), R.layout.row_item_ingredients, RecipeIngredients);

        for (int i = 0; i < RecipeIngredients.size(); i++) {
            View row = recipeIngredientAdapter.getView(i, null, null);
            recipeIngredientLayout.addView(row);
        }

        return rootView;
    }

}
