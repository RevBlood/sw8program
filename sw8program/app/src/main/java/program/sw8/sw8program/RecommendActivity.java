package program.sw8.sw8program;

import android.content.Context;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentActivity;
import android.support.v4.view.PagerAdapter;
import android.support.v4.view.ViewPager;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.Vector;

import Models.Recipe;


public class RecommendActivity extends FragmentActivity {

    int Position = 0;
    ViewPager RecommendationPager;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_recommend);

        //TODO: Get the list of recommendations from Database
        List<Recipe> recipes = new ArrayList<>();
        recipes.add(new Recipe(-1, -1, "dillersnavs", "meget lækker", new Date(), -1, "tags", new BigDecimal(5)));
        recipes.add(new Recipe(-1, -1, "tis", "meget lækker", new Date(), -1, "tags", new BigDecimal(5)));
        recipes.add(new Recipe(-1, -1, "spaghetti", "meget lækker", new Date(), -1, "tags", new BigDecimal(5)));

        //Create list of fragments to be shown in the ViewPager
        List<Fragment> fragments = new Vector<>();

        //TODO: Pass the data from Database
        //For each recipe in the recommendations, create a fragment to display that recipe
        for(Recipe recipe : recipes) {
            Bundle bundle = new Bundle();
            bundle.putInt("RecipeId", recipe.getId());
            fragments.add(Fragment.instantiate(this, RecommendationFragment.class.getName(), bundle));
        }
        //Add a fragment in the end to display a message to the user
        fragments.add(Fragment.instantiate(this, RecommendationEndFragment.class.getName()));

        //Create a PagerAdapter with the fragments, and feed it to the ViewPager
        PagerAdapter pagerAdapter  = new RecipePagerAdapter(this.getSupportFragmentManager(), fragments);
        RecommendationPager = (ViewPager)super.findViewById(R.id.viewpager_recommendations);
        RecommendationPager.setAdapter(pagerAdapter);

        //Display the first recommendation
        RecommendationPager.setCurrentItem(Position);
    }

    public void getNextPage(){
        Position++;
        RecommendationPager.setCurrentItem(Position);
    }
}
