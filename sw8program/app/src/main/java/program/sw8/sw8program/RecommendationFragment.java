package program.sw8.sw8program;

import android.content.Intent;
import android.content.res.Resources;
import android.graphics.drawable.Drawable;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.view.ViewPager;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.TextView;

import java.math.BigDecimal;
import java.text.DecimalFormat;
import java.text.NumberFormat;
import java.util.ArrayList;
import java.util.List;

import Helpers.JSONHelper;
import Models.Recipe;

public class RecommendationFragment extends Fragment {

    String JsonRecipe;
    Recipe DeserializedRecipe;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        ViewGroup rootView = (ViewGroup) inflater.inflate(R.layout.fragment_recommendation, container, false);

        TextView recipeNameView = (TextView) rootView.findViewById(R.id.recipe_name);
        TextView priceView = (TextView) rootView.findViewById(R.id.text_price);
        TextView savingsView = (TextView) rootView.findViewById(R.id.text_saving);
        ViewPager recipeImagePager = (ViewPager) rootView.findViewById(R.id.paged_image_layout);

        Bundle bundle = this.getArguments();
        JsonRecipe = bundle.getString("recipe");
        DeserializedRecipe = JSONHelper.Deserialize(JsonRecipe, Recipe.class);

        DecimalFormat formatter = new DecimalFormat("##.00");
        priceView.setText(formatter.format(Double.parseDouble(bundle.getString("price", "-1"))));
        savingsView.setText(formatter.format(Double.parseDouble(bundle.getString("savingsStorePrice", "-1"))));


        String RecipeName = DeserializedRecipe.getName();
        List<Drawable> RecipeImages = new ArrayList<>();

        Resources r = getResources();
        RecipeImages.add(r.getDrawable(R.drawable.placeholder_recipe_1));
        RecipeImages.add(r.getDrawable(R.drawable.placeholder_recipe_2));

        //Populate views
        recipeNameView.setText(RecipeName);

        RecipeImageAdapter recipeImageAdapter = new RecipeImageAdapter(getActivity(), RecipeImages);
        recipeImagePager.setAdapter(recipeImageAdapter);

        //Handle navigation
        Button buttonRecommendationChoose = (Button) rootView.findViewById(R.id.button_recommendation_choose);
        Button buttonRecommendationNext = (Button) rootView.findViewById(R.id.button_recommendation_next);

        buttonRecommendationChoose.setOnClickListener(onChooseClickListener);
        buttonRecommendationNext.setOnClickListener(onNextClickListener);

        return rootView;
    }

    Button.OnClickListener onChooseClickListener = new Button.OnClickListener() {
        @Override
        public void onClick(View v) {
            Intent intent = new Intent(getActivity(), RecipeActivity.class);
            intent.putExtra("recipe", JsonRecipe);
            intent.putExtra("id", DeserializedRecipe.getId());
            startActivity(intent);
        }
    };
    Button.OnClickListener onNextClickListener = new Button.OnClickListener() {
        @Override
        public void onClick(View v) {
            ((RecommendActivity)getActivity()).getNextPage();
        }
    };
}