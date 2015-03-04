package program.sw8.sw8program;

import android.app.Activity;
import android.content.res.Resources;
import android.graphics.drawable.Drawable;
import android.os.Bundle;
import android.support.v4.view.ViewPager;
import android.view.KeyEvent;
import android.view.View;
import android.view.ViewGroup;
import android.view.inputmethod.EditorInfo;
import android.widget.LinearLayout;
import android.widget.ListAdapter;
import android.widget.ListView;
import android.widget.RelativeLayout;
import android.widget.TextView;
import android.widget.Toast;

import java.util.ArrayList;
import java.util.List;

public class RecipeActivity extends Activity {

    List<Drawable> RecipeImages = new ArrayList<>();
    String RecipeName;
    List<Ingredient> RecipeIngredients = new ArrayList<>();
    String RecipePreparationText;

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

        RecipePreparationText = "Bland det hele undtaget smørret. Lad sovsen stå at simre indtil den er reduceret til det halve. 5 dl. Tag sovsen af varmen og kom smørret i, i små stykker, imens du pisker rundt. Det hedder at montere den. En metode der kan bruges til mange saucer.";



        //Populate views and set adapters
        recipeNameView.setText(RecipeName);

        RecipeImageAdapter recipeImageAdapter = new RecipeImageAdapter(this, RecipeImages);
        recipeImagePager.setAdapter(recipeImageAdapter);

        RecipeIngredientAdapter recipeIngredientAdapter = new RecipeIngredientAdapter(this, R.layout.row_item_ingredients, RecipeIngredients);

        for (int i = 0; i < RecipeIngredients.size(); i++) {
            View row = recipeIngredientAdapter.getView(i, null, null);
            recipeIngredientLayout.addView(row);
        }

        recipePreparationView.setText(RecipePreparationText);

        recipeCommentBox.setOnEditorActionListener(OnSubmitCommentListener);
        recipeCommentBox.setImeActionLabel(getString(R.string.comment_submit), EditorInfo.IME_ACTION_DONE);
    }


    TextView.OnEditorActionListener OnSubmitCommentListener = new TextView.OnEditorActionListener() {
        @Override
        public boolean onEditorAction(TextView v, int actionId, KeyEvent event) {
            boolean handled = false;
            if (actionId == EditorInfo.IME_ACTION_SEND) {
                Toast toast = Toast.makeText(getParent(), "Ok.", Toast.LENGTH_SHORT);
                toast.show();
                handled = true;
            }
            return handled;
        }
    };
}