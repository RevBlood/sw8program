package program.sw8.sw8program;

import android.content.Context;
import android.content.res.Resources;
import android.graphics.Color;
import android.graphics.PorterDuff;
import android.graphics.drawable.Drawable;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.GridView;
import android.widget.ImageView;

/**
 * Created by Johan 'Jizztærsker' on 16-02-2015.
 */
public class GridViewAdapter extends BaseAdapter {
    private Context PagerActivityContext;
    private Boolean RequestActive = false;
    private int PreviousActivePosition = 2;
    private final int[] TabImages = {R.drawable.profile,
                                     R.drawable.favourites,
                                     R.drawable.recommend,
                                     R.drawable.discover,
                                     R.drawable.settings};

    public GridViewAdapter(Context pagerActivityContext) {
        PagerActivityContext = pagerActivityContext;
    }

    @Override
    public int getCount() {
        return 5;
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
    public View getView(int position, View view, ViewGroup viewGroup) {
        Resources r = PagerActivityContext.getResources();
        Drawable d = r.getDrawable(TabImages[position]);

        if (RequestActive) {
            RequestActive = false;

            Drawable old = r.getDrawable(TabImages[PreviousActivePosition]);
            old.clearColorFilter();
            PreviousActivePosition = position;

            d.setColorFilter(Color.BLUE, PorterDuff.Mode.SRC_ATOP);
        }

        if (view == null) {
            view = new ImageView(PagerActivityContext);
            view.setLayoutParams(new GridView.LayoutParams(100, 100));
        }

        view.setBackground(d);
        return view;
    }

    public void requestActive(int position){
        RequestActive = true;
        getView(position, null, null);

    }
}

