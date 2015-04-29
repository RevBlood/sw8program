package program.sw8.sw8program;

import android.content.SharedPreferences;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentActivity;
import android.support.v4.view.PagerAdapter;
import android.support.v4.view.ViewPager;

import com.google.android.gms.maps.model.LatLng;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Vector;

import CommunicationModels.RecipeWithExtraData;
import CommunicationModels.ExtraData;
import Helpers.JSONHelper;
import Helpers.ServiceHelper;
import Models.Recipe;

public class RecommendActivity extends FragmentActivity {

    int Position = 0;
    ViewPager RecommendationPager;

    // TODO: Default coordinates?
    LatLng position = new LatLng(57.0131248, 9.9904191);

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_recommend);

        // Get data needed to retrieve recommendations
        OneTimeLocationProvider.requestUpdate(this, new OneTimeLocationProvider.LocationCallback() {
            @Override
            public void onNewLocationAvailable(LatLng location) {
                position = location;
            }
        });

        SharedPreferences session = getSharedPreferences(getString(R.string.app_name), 0);
        SharedPreferences preferences = getSharedPreferences(getString(R.string.app_name) + session.getInt("id", -1), 0);

        RecipeWithExtraData recipes;

        if (getString(R.string.debug).equals("off")) {
            recipes = (ServiceHelper.GetRecipesFromRecommendations(
                    preferences.getInt("numberOfRecommendations", 5),
                    preferences.getInt("price", 50),
                    preferences.getInt("savings", 50),
                    preferences.getInt("radius", 5),
                    position.latitude,
                    position.longitude));
        } else {
            Map<Recipe, ExtraData> map = new HashMap<>();
                map.put(new Recipe(-1, -1, "dillersnavs", "meget lækker", new Date(), -1, "tags", new BigDecimal(5)), new ExtraData(new BigDecimal(37), new BigDecimal(12)));
                map.put(new Recipe(-1, -1, "tis", "meget lækker", new Date(), -1, "tags", new BigDecimal(5)), new ExtraData(new BigDecimal(42), new BigDecimal(5)));
                map.put(new Recipe(-1, -1, "spaghetti", "meget lækker", new Date(), -1, "tags", new BigDecimal(5)), new ExtraData(new BigDecimal(13), new BigDecimal(2)));
            recipes = new RecipeWithExtraData(map);
        }

        //Create list of fragments to be shown in the ViewPager
        List<Fragment> fragments = new Vector<>();

        //For each recipe in the recommendations, create a fragment to display that recipe
        for (Map.Entry<Recipe, ExtraData> entry : recipes.ListOfRecipes.entrySet()) {
            Bundle bundle = new Bundle();
            bundle.putString("recipe", JSONHelper.Serializer(entry.getKey()));
            bundle.putString("price", entry.getValue().Price.toString());
            bundle.putString("savingsStorePrice", entry.getValue().SavingsStorePrice.toString());
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
