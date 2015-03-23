package program.sw8.sw8program;

import android.app.Activity;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentActivity;
import android.support.v4.view.PagerAdapter;
import android.support.v4.view.ViewPager;
import android.widget.TabHost;

import java.util.HashMap;
import java.util.List;
import java.util.Vector;

/**
 * Created by Johan 'Jizztærsker' on 23-03-2015.
 */
public class RecipeActivity extends FragmentActivity implements TabHost.OnTabChangeListener, ViewPager.OnPageChangeListener {

    private TabHost mTabHost;
    private ViewPager mViewPager;
    private PagerAdapter mPagerAdapter;


    protected void onCreate(Bundle savedInstanceState){
        super.onCreate(savedInstanceState);
        // Inflate the layout
        setContentView(R.layout.recipe_view_pager);
        // Initialise the TabHost
        this.initialiseTabHost(savedInstanceState);
        if (savedInstanceState != null) {
            mTabHost.setCurrentTabByTag(savedInstanceState.getString("tab")); //set the tab as per the saved state
        }
        // Initialise ViewPager
        this.initialiseViewPager();
    }

    private void initialiseTabHost(Bundle args) {
        mTabHost = (TabHost)findViewById(android.R.id.tabhost);
        mTabHost.setup();
        this.AddTab(this, this.mTabHost, this.mTabHost.newTabSpec("Tab1").setIndicator("Opskrift"));
        this.AddTab(this, this.mTabHost, this.mTabHost.newTabSpec("Tab2").setIndicator("Kommentarer"));

        mTabHost.setOnTabChangedListener(this);
    }

    private void initialiseViewPager() {

        List<Fragment> fragments = new Vector<>();
        fragments.add(Fragment.instantiate(this, RecipeFragment.class.getName()));
        fragments.add(Fragment.instantiate(this, RecipeCommentFragment.class.getName()));
        this.mPagerAdapter  = new RecipePagerAdapter(super.getSupportFragmentManager(), fragments);
        this.mViewPager = (ViewPager)super.findViewById(R.id.viewpager);
        this.mViewPager.setAdapter(this.mPagerAdapter);
        this.mViewPager.setOnPageChangeListener(this);
    }

    private void AddTab(RecipeActivity activity, TabHost tabHost, TabHost.TabSpec tabSpec) {
        // Attach a Tab view factory to the spec
        tabSpec.setContent(new TabFactory(activity));
        tabHost.addTab(tabSpec);
    }

    public void onTabChanged(String tag) {
        //TabInfo newTab = this.mapTabInfo.get(tag);
        int pos = this.mTabHost.getCurrentTab();
        this.mViewPager.setCurrentItem(pos);
    }

    @Override
    public void onPageScrolled(int position, float positionOffset,
                               int positionOffsetPixels) {
        // TODO Auto-generated method stub

    }
    @Override
    public void onPageSelected(int position) {
        // TODO Auto-generated method stub
        this.mTabHost.setCurrentTab(position);
    }
    @Override
    public void onPageScrollStateChanged(int state) {
        // TODO Auto-generated method stub

    }
}
