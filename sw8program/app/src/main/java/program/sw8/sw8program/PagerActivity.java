package program.sw8.sw8program;

import android.os.Bundle;
import android.support.v4.app.FragmentActivity;
import android.support.v4.view.PagerAdapter;
import android.support.v4.view.ViewPager;
import android.view.View;
import android.widget.AdapterView;
import android.widget.Button;
import android.widget.GridView;

public class PagerActivity extends FragmentActivity {

    private ViewPager Pager;
    private PagerAdapter PageAdapter;
    private GridView Tabs;
    private GridViewAdapter TabAdapter;
    private Button TabUser;
    private Button TabFavourites;
    private Button TabRecommend;
    private Button TabDiscover;
    private Button TabSettings;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_pager);

        Pager = (ViewPager) findViewById(R.id.pager);
        Tabs = (GridView) findViewById(R.id.header);
       /* TabUser = (Button) findViewById(R.id.tab_user);
        TabFavourites = (Button) findViewById(R.id.tab_favourites);
        TabRecommend = (Button) findViewById(R.id.tab_recommend);
        TabDiscover = (Button) findViewById(R.id.tab_discover);
        TabSettings = (Button) findViewById(R.id.tab_settings);*/

        PageAdapter = new CustomPagerAdapter(getSupportFragmentManager());
        Pager.setAdapter(PageAdapter);
        Pager.setCurrentItem(2);

        Tabs.setAdapter(new GridViewAdapter(this));

        Tabs.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            public void onItemClick(AdapterView<?> parent, View v, int position, long id) {
            }
        });
    }


}
