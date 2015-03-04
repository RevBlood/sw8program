package program.sw8.sw8program;

import android.app.Activity;
import android.content.res.Resources;
import android.graphics.drawable.Drawable;
import android.os.Bundle;
import android.support.v4.view.ViewPager;
import android.widget.ListView;
import android.widget.TextView;

import java.util.ArrayList;
import java.util.List;

public class RecipeActivity extends Activity {

    List<Drawable> RecipeImages = new ArrayList<>();
    String RecipeName;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_recipe);

        TextView recipeNameView = (TextView) findViewById(R.id.recipe_name);
        ViewPager recipeImagePager = (ViewPager) findViewById(R.id.paged_image_layout);
        ListView recipeIngredientList = (ListView) findViewById(R.id.ingredient_list);
        TextView recipePreparationView = (TextView) findViewById(R.id.preparation_text);
        TextView recipeCommentBox = (TextView) findViewById(R.id.comment_box);
        ListView recipeCommentList = (ListView) findViewById(R.id.comments);

        //Testdata
        //TODO: Slet
        RecipeName = "Sauce";

        Resources r = getResources();
        RecipeImages.add(r.getDrawable(R.drawable.placeholder_recipe_1));
        RecipeImages.add(r.getDrawable(R.drawable.placeholder_recipe_2));

        //Populate views
        recipeNameView.setText(RecipeName);

        RecipeImageAdapter recipeImageAdapter = new RecipeImageAdapter(this, RecipeImages);
        recipeImagePager.setAdapter(recipeImageAdapter);
    }
}