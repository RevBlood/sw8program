package program.sw8.sw8program;

import android.app.Activity;
import android.content.res.Resources;
import android.graphics.drawable.Drawable;
import android.os.Bundle;
import android.support.v4.view.ViewPager;
import android.view.View;
import android.view.ViewGroup;
import android.widget.LinearLayout;
import android.widget.ListAdapter;
import android.widget.ListView;
import android.widget.RelativeLayout;
import android.widget.TextView;

import java.util.ArrayList;
import java.util.List;

public class RecipeActivity extends Activity {

    List<Drawable> RecipeImages = new ArrayList<>();
    String RecipeName;
    List<Ingredient> RecipeIngredients = new ArrayList<>();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_recipe);

        TextView recipeNameView = (TextView) findViewById(R.id.recipe_name);
        ViewPager recipeImagePager = (ViewPager) findViewById(R.id.paged_image_layout);
        LinearLayout recipeIngredientLayout = (LinearLayout) findViewById(R.id.ingredient_layout);
        TextView recipePreparationView = (TextView) findViewById(R.id.preparation_text);
        TextView recipeCommentBox = (TextView) findViewById(R.id.comment_box);
        ListView recipeCommentList = (ListView) findViewById(R.id.comments);

        //Testdata
        //TODO: Slet
        RecipeName = "Sauce";

        Resources r = getResources();
        RecipeImages.add(r.getDrawable(R.drawable.placeholder_recipe_1));
        RecipeImages.add(r.getDrawable(R.drawable.placeholder_recipe_2));

        RecipeIngredients.add(new Ingredient("2 kg", "spices"));
        RecipeIngredients.add(new Ingredient("2 tsk", "shit"));
        RecipeIngredients.add(new Ingredient("15 minutes", "love"));
        RecipeIngredients.add(new Ingredient("3g", "salt"));

        //Populate views
        recipeNameView.setText(RecipeName);

        RecipeImageAdapter recipeImageAdapter = new RecipeImageAdapter(this, RecipeImages);
        recipeImagePager.setAdapter(recipeImageAdapter);

        RecipeIngredientAdapter recipeIngredientAdapter = new RecipeIngredientAdapter(this, R.layout.row_item_ingredients, RecipeIngredients);

        for (int i = 0; i < RecipeIngredients.size(); i++) {
            View row = recipeIngredientAdapter.getView(i, null, null);
            recipeIngredientLayout.addView(row);
        }


        //recipeIngredientList.setAdapter(recipeIngredientAdapter);
        //setListViewHeightBasedOnChildren(recipeIngredientList);


    }

    private void setListViewHeightBasedOnChildren(ListView listView) {
        ListAdapter listAdapter = listView.getAdapter();

        int totalHeight = listView.getPaddingTop() + listView.getPaddingBottom();
        for (int i = 0; i < listAdapter.getCount(); i++) {
            View listItem = listAdapter.getView(i, null, listView);
            if (listItem instanceof ViewGroup) {
                listItem.setLayoutParams(new RelativeLayout.LayoutParams(RelativeLayout.LayoutParams.WRAP_CONTENT, RelativeLayout.LayoutParams.WRAP_CONTENT));
            }
            listItem.measure(0, 0);
            totalHeight += listItem.getMeasuredHeight();
        }

        ViewGroup.LayoutParams params = listView.getLayoutParams();
        params.height = totalHeight + (listView.getDividerHeight() * (listAdapter.getCount() - 1));
        listView.setLayoutParams(params);
    }
}