package program.sw8.sw8program;

import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentStatePagerAdapter;
import android.support.v4.view.ViewPager;

/**
 * Created by Johan 'Jizztærsker' on 16-02-2015.
 */
public class CustomPagerAdapter extends FragmentStatePagerAdapter {
    private final int PageCount = 5;
    private GridViewAdapter TabAdapter;
    private FragmentManager Manager;

    public CustomPagerAdapter(FragmentManager fragmentManager, GridViewAdapter tabAdapter) {
        super(fragmentManager);
        TabAdapter = tabAdapter;
        Manager = fragmentManager;
    }

    @Override
    //Returns the needed fragment. 0->4 is the pages left->right
    public Fragment getItem(int position) {
        switch (position) {
            case 0: return new UserFragment();
            case 1: return new FavouritesFragment();
            case 2: return new RecommendFragment();
            case 3: return new DiscoverFragment();
            case 4: return new SettingsFragment();
            default: throw new IllegalArgumentException("Error in Page handling");
        }
    }

    @Override
    public int getCount(){
        return PageCount;
    }

    //Changes current page and requests the GridViewAdapter to update highlights. Called when tabs are used rather than touch gestures
    public void changePage(ViewPager pager, int position) {
        pager.setCurrentItem(position);
        TabAdapter.requestActive(position);
    }

    //Removes highlight from all tabs
    public void removeHighlights() {
        TabAdapter.requestNoHighlight();
    }
}
