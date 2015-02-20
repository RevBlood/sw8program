package program.sw8.sw8program;

import android.os.Bundle;
import android.support.v4.app.FragmentActivity;
import android.support.v4.view.ViewPager;
import android.view.View;
import android.widget.AdapterView;
import android.widget.GridView;

public class PagerActivity extends FragmentActivity {

    //Index of the page where the app should load up
    private final int StartPage = 2;

    private ViewPager Pager;
    private CustomPagerAdapter PagerAdapter;
    private GridView Tabs;
    private GridViewAdapter TabAdapter;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_pager);

        Pager = (ViewPager) findViewById(R.id.pager);
        Tabs = (GridView) findViewById(R.id.header);

        //Setup tabs with an adapter and a listener
        TabAdapter = new GridViewAdapter(this);
        Tabs.setAdapter(TabAdapter);
        Tabs.setOnItemClickListener(onTabClickListener);

        //Setup the pages with an adapter and a listener. Switch the display to show the recommender page
        Pager.setOnPageChangeListener(pagerChangeListener);
        PagerAdapter = new CustomPagerAdapter(getSupportFragmentManager(), TabAdapter);
        Pager.setAdapter(PagerAdapter);
        PagerAdapter.changePage(Pager, StartPage);
    }

    //ClickListener for the tabs will highlight a tab, remove highlight from previous tab and prompt the Pager to change page
    AdapterView.OnItemClickListener onTabClickListener = new AdapterView.OnItemClickListener() {
        @Override
        public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
            PagerAdapter.changePage(Pager, position);
        }
    };

    //The pager handles touch events automatically. onPageSelected sends a request to the GridViewAdapter to highlight the right tab
    ViewPager.OnPageChangeListener pagerChangeListener = new ViewPager.OnPageChangeListener() {
        @Override
        public void onPageScrolled(int i, float v, int i2) {

        }

        @Override
        public void onPageSelected(int i) {
            TabAdapter.requestActive(i);
        }

        @Override
        public void onPageScrollStateChanged(int i) {

        }
    };

    @Override
    public void onPause() {
        super.onPause();
    }
}
