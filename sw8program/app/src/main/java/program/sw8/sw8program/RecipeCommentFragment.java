package program.sw8.sw8program;

import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.ListView;
import android.widget.TextView;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import Helpers.JSONHelper;
import Helpers.ServiceHelper;
import Models.Comment;
import Models.Recipe;

public class RecipeCommentFragment extends Fragment {


    List<Comment> RecipeComments = new ArrayList<>();
    TextView recipeCommentBox;
    String newComment;

    String JSONRecipe;
    Recipe recipe;

    Date thisdate;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        ViewGroup rootView = (ViewGroup) inflater.inflate(R.layout.fragment_recipe_comment, container, false);

        recipeCommentBox = (TextView) rootView.findViewById(R.id.comment_edit_text);
        Button recipeCommentSubmitButton = (Button) rootView.findViewById(R.id.comment_save_button);
        final ListView commentsListView = (ListView) rootView.findViewById(R.id.comment_list);

        JSONRecipe = getActivity().getIntent().getStringExtra("recipe");
        Log.d("RecipeCommentFragment", "this is what is in the intent for RecipeCommentFragment: " + JSONRecipe);
        recipe = JSONHelper.Deserialize(JSONRecipe, Recipe.class);
        Log.d("RecipeCommentFragment","this is the name of the recipe used in RecipeCommentFragment: " + recipe.getName());

        PrepareComments();

        final RecipeCommentAdapter recipeCommentAdapter = new RecipeCommentAdapter(getActivity(), R.layout.row_item_comment, RecipeComments);
        commentsListView.setAdapter(recipeCommentAdapter);

        recipeCommentSubmitButton.setOnClickListener(new Button.OnClickListener() {
            @Override
            public void onClick(View v) {
                newComment = recipeCommentBox.getText().toString();
                recipeCommentBox.setText("");
                RecipeComments.add(new Comment(1,1,1,new Date(),newComment));
                recipeCommentAdapter.notifyDataSetChanged();
                commentsListView.setSelection(commentsListView.getAdapter().getCount()-1);
            }
        });

        return rootView;
    }

    public void PrepareComments() {

        if (getString(R.string.debug).equals("on")) {
            Date thisdate = new Date();
            RecipeComments.add(new Comment(1,1,1,thisdate,"this is a really cool comment"));
            RecipeComments.add(new Comment(1,1,1,thisdate,"this is another reeeeeeeally cool comment, and it is very long. That is pretty neat, I really find this recipe something out of the spectacular and i really hope that i could create something as beautiful as it at some point in my life, i wish to make to love to it"));
            RecipeComments.add(new Comment(1,1,1,thisdate,"this is another reeeeeeeally, reeeeeeeeeeeeeeeeeeeeeally cool comment"));
        } else {
            RecipeComments = ServiceHelper.GetCommentsByRecipeId(recipe.getId());
        }

    }


}
