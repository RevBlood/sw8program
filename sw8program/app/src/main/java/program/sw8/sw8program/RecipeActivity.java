package program.sw8.sw8program;

import android.app.Activity;
import android.content.Intent;
import android.content.res.Resources;
import android.graphics.drawable.Drawable;
import android.os.Bundle;
import android.support.v4.view.ViewPager;
import android.util.Log;
import android.view.KeyEvent;
import android.view.View;
import android.view.inputmethod.EditorInfo;
import android.widget.Button;
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import Helpers.JSONHelper;
import Models.Comment;
import Models.Recipe;

public class RecipeActivity extends Activity {

    List<Drawable> RecipeImages = new ArrayList<>();
    List<Ingredient> RecipeIngredients = new ArrayList<>();
    List<Comment> RecipeComments = new ArrayList<>();
    TextView recipeCommentBox;

    Intent intent = getIntent();
    String JSONRecipe;

    Date date = new Date();
    BigDecimal bigdiddy = new BigDecimal(3.31231);

    Recipe recipe = new Recipe(3,2,"magiskmad", "Semper nascetur class pretium. Fusce nibh vel ac, suscipit sagittis, lobortis viverra. Integer odio nulla a parturient, nulla luctus massa adipiscing senectus lectus. Diam felis amet metus, donec ac vivamus orci cras sed, lacus enim mattis eu, velit tristique, faucibus fusce nulla velit. Odio non nunc vel mi malesuada diam. Vivamus nam ante, primis massa nec placerat justo posuere sociis, sit maecenas eget ac condimentum. Integer a sem id, est maecenas hendrerit aliquam est in lacus, mollis quis tempor risus sollicitudin vitae. Rutrum eleifend, nunc magnis enim turpis sem condimentum porttitor, aliquam ornare felis sed. Elit integer vitae sem, neque cursus lobortis arcu pede tortor amet.", date, 5, "house", bigdiddy);

    Date thisdate = new Date();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_recipe);

        /*
        if (savedInstanceState == null) {
            Bundle extras = getIntent().getExtras();
            if(extras == null) {
                JSONRecipe = null;
            } else {
                JSONRecipe = extras.getString("recipe");
            }
        }

        Log.d("this is JSONrecipe:", JSONRecipe);

        recipe = JSONHelper.Deserialize(JSONRecipe, Recipe.class);

        */

        TextView recipeNameView = (TextView) findViewById(R.id.recipe_name);
        ViewPager recipeImagePager = (ViewPager) findViewById(R.id.paged_image_layout);
        LinearLayout recipeIngredientLayout = (LinearLayout) findViewById(R.id.ingredient_layout);
        TextView recipePreparationView = (TextView) findViewById(R.id.preparation_text);
        //recipeCommentBox = (TextView) findViewById(R.id.comment_box);
        //Button recipeCommentSubmitButton = (Button) findViewById(R.id.comment_submit);
        LinearLayout recipeCommentLayout = (LinearLayout) findViewById(R.id.comments);


        //Testdata
        //TODO: Slet

        Resources r = getResources();
        RecipeImages.add(r.getDrawable(R.drawable.placeholder_recipe_1));
        RecipeImages.add(r.getDrawable(R.drawable.placeholder_recipe_2));

        RecipeIngredients.add(new Ingredient("2 kg", "spices"));
        RecipeIngredients.add(new Ingredient("2 tsk", "shit"));
        RecipeIngredients.add(new Ingredient("15 minutes", "love"));
        RecipeIngredients.add(new Ingredient("3g", "salt"));

        RecipeComments.add(new Comment(1,1,1,thisdate,"this is a really cool comment"));
        RecipeComments.add(new Comment(1,1,1,thisdate,"this is another reeeeeeeally cool comment, and it is very long. That is pretty neat, I really find this recipe something out of the spectacular and i really hope that i could create something as beautiful as it at some point in my life, i wish to make to love to it"));
        RecipeComments.add(new Comment(1,1,1,thisdate,"this is another reeeeeeeally, reeeeeeeeeeeeeeeeeeeeeally cool comment"));


        //Populate views and set adapters
        recipeNameView.setText(recipe.getName());
        recipePreparationView.setText(recipe.getDescription());

        RecipeImageAdapter recipeImageAdapter = new RecipeImageAdapter(this, RecipeImages);
        recipeImagePager.setAdapter(recipeImageAdapter);

        RecipeIngredientAdapter recipeIngredientAdapter = new RecipeIngredientAdapter(this, R.layout.row_item_ingredients, RecipeIngredients);

        for (int i = 0; i < RecipeIngredients.size(); i++) {
            View row = recipeIngredientAdapter.getView(i, null, null);
            recipeIngredientLayout.addView(row);
        }

        RecipeCommentAdapter recipeCommentAdapter = new RecipeCommentAdapter(this, R.layout.row_item_comment, RecipeComments);

        for (int i = 0; i < RecipeComments.size(); i++) {
            View row = recipeCommentAdapter.getView(i, null, null);
            recipeCommentLayout.addView(row);
        }

        //recipeCommentSubmitButton.setOnClickListener(onSubmitCommentListener);

    }

    Button.OnClickListener onSubmitCommentListener = (new Button.OnClickListener() {
        @Override
        public void onClick(View v) {
            //TODO: Post comment
        }
    });
}