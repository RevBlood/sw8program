package program.sw8.sw8program;

import android.content.Context;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;

/**
 * Created by Johan 'Jizztærsker' on 16-02-2015.
 */
public class GridViewAdapter extends BaseAdapter {
    private Context PagerActivityContext;

    public GridViewAdapter(Context pagerActivityContext) {
        PagerActivityContext = pagerActivityContext;
    }
    @Override
    public int getCount() {
        return 0;
    }

    @Override
    public Object getItem(int i) {
        return null;
    }

    @Override
    public long getItemId(int i) {
        return 0;
    }

    @Override
    public View getView(int i, View view, ViewGroup viewGroup) {
        return null;
    }
}
