package program.sw8.sw8program;

import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentPagerAdapter;
import android.os.Bundle;
import android.support.v4.app.FragmentPagerAdapter;

import java.util.List;

/**
 * Created by Johan 'Jizztærsker' on 23-03-2015.
 */
public class RecipePagerAdapter extends FragmentPagerAdapter {

    private List<Fragment> fragments;

    public RecipePagerAdapter(FragmentManager fm, List<Fragment> fragments) {
        super(fm);
        this.fragments = fragments;
    }

    @Override
    public Fragment getItem(int position) {
        return this.fragments.get(position);
    }

    @Override
    public int getCount() {
        return this.fragments.size();
    }
}