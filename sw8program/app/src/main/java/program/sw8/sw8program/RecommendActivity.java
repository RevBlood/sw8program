package program.sw8.sw8program;

import android.content.SharedPreferences;
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

import Helpers.JSONHelper;
import Models.Recipe;

public class RecommendActivity extends FragmentActivity {

    int Position = 0;
    ViewPager RecommendationPager;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_recommend);

        List<Recipe> recipes = new ArrayList<>();

        //TODO: Get the list of recommendations from Database

        SharedPreferences session = getSharedPreferences(getString(R.string.app_name), 0);
        SharedPreferences preferences = getSharedPreferences(getString(R.string.app_name) + session.getInt("id", -1), 0);
        preferences.getInt("price", 50);
        preferences.getInt("savings", 50);
        preferences.getInt("numberOfRecommendations", 5);

        if (getString(R.string.debug).equals("off")) {

        } else {
            recipes.add(new Recipe(-1, -1, "dillersnavs", "meget lækker", new Date(), -1, "tags", new BigDecimal(5)));
            recipes.add(new Recipe(-1, -1, "tis", "meget lækker", new Date(), -1, "tags", new BigDecimal(5)));
            recipes.add(new Recipe(-1, -1, "spaghetti", "meget lækker", new Date(), -1, "tags", new BigDecimal(5)));
        }

        //Create list of fragments to be shown in the ViewPager
        List<Fragment> fragments = new Vector<>();

        //For each recipe in the recommendations, create a fragment to display that recipe
        for(Recipe recipe : recipes) {
            Bundle bundle = new Bundle();
            bundle.putString("recipe", JSONHelper.Serializer(recipe));
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
