package program.sw8.sw8program;

import android.os.Bundle;
import android.support.v4.app.FragmentActivity;
import android.support.v4.view.ViewPager;
import android.view.View;
import android.widget.AdapterView;
import android.widget.GridView;

public class PagerActivity extends FragmentActivity {

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

        TabAdapter = new GridViewAdapter(this);
        Tabs.setAdapter(TabAdapter);
        Tabs.setOnItemClickListener(onTabClickListener);


        Pager.setOnPageChangeListener(pagerChangeListener);
        PagerAdapter = new CustomPagerAdapter(getSupportFragmentManager(), TabAdapter);
        Pager.setAdapter(PagerAdapter);
        PagerAdapter.choosePage(Pager, 2);
    }

    AdapterView.OnItemClickListener onTabClickListener = new AdapterView.OnItemClickListener() {
        @Override
        public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
            PagerAdapter.choosePage(Pager, position);
        }
    };

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
}
