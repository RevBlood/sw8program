package program.sw8.sw8program;

import android.content.SharedPreferences;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

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
    String JSONRecipe;
    Recipe recipe;
    Integer RecipeId;
    Integer AccountId;
    RecipeCommentAdapter CommentAdapter;
    ListView CommentsListView;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        ViewGroup rootView = (ViewGroup) inflater.inflate(R.layout.fragment_recipe_comment, container, false);

        SharedPreferences session = getActivity().getApplicationContext().getSharedPreferences(getString(R.string.app_name), 0);
        AccountId = session.getInt("id", -1);

        recipeCommentBox = (TextView) rootView.findViewById(R.id.comment_edit_text);
        Button recipeCommentSubmitButton = (Button) rootView.findViewById(R.id.comment_save_button);
        CommentsListView = (ListView) rootView.findViewById(R.id.comment_list);

        JSONRecipe = getActivity().getIntent().getStringExtra("recipe");
        RecipeId = getActivity().getIntent().getIntExtra("id", -1);
        Log.d("RecipeCommentFragment", "this is what is in the intent for RecipeCommentFragment: " + JSONRecipe);
        recipe = JSONHelper.Deserialize(JSONRecipe, Recipe.class);
        Log.d("RecipeCommentFragment","this is the name of the recipe used in RecipeCommentFragment: " + recipe.getName());
        recipe.setId(RecipeId);

        PrepareComments();

        CommentAdapter = new RecipeCommentAdapter(getActivity(), R.layout.row_item_comment, RecipeComments);
        CommentsListView.setAdapter(CommentAdapter);

        recipeCommentSubmitButton.setOnClickListener(postCommentListener);

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
            RecipeComments.size();
        }
    }

    Button.OnClickListener postCommentListener = new Button.OnClickListener() {
        @Override
        public void onClick(View v) {
            if (ServiceHelper.PostComment(new Comment(AccountId, recipe.getId(), recipeCommentBox.getText().toString()))) {
                recipeCommentBox.setText("");
                CommentAdapter.clear();
                CommentAdapter.addAll(ServiceHelper.GetCommentsByRecipeId(recipe.getId()));
                CommentAdapter.notifyDataSetChanged();
                CommentsListView.setSelection(CommentsListView.getAdapter().getCount() - 1);
            } else {
                //TODO: Make an error
                Toast.makeText(getActivity(),"Fucking shit server", Toast.LENGTH_SHORT).show();
            }
        }
    };


}
