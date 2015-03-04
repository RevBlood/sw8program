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
    private int PreviousActivePosition;
    private final int PageCount = 5;
    private final int[] TabImages = {R.drawable.profile,
                                     R.drawable.favourites,
                                     R.drawable.recommend,
                                     R.drawable.discover,
                                     R.drawable.settings};

    public GridViewAdapter(Context pagerActivityContext, int DefaultPage) {
        PagerActivityContext = pagerActivityContext;
        PreviousActivePosition = DefaultPage;
    }

    @Override
    public int getCount() {
        return PageCount;
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
        //Find the drawable to show from TabImages based on position given from getView.
        Resources r = PagerActivityContext.getResources();
        Drawable d = r.getDrawable(TabImages[position]);

        //If the tab has been requested as active, add highlighting and remove it from the previous highighted view.
        if (RequestActive) {
            RequestActive = false;

            Drawable old = r.getDrawable(TabImages[PreviousActivePosition]);
            old.clearColorFilter();
            PreviousActivePosition = position;

            d.setColorFilter(Color.BLUE, PorterDuff.Mode.SRC_ATOP);
        }

        //If the view is not an existing one, initialize it
        if (view == null) {
            view = new ImageView(PagerActivityContext);
            view.setLayoutParams(new GridView.LayoutParams(100, 100));
        }

        //Set the image for the view, with or without highlighting.
        view.setBackground(d);
        return view;
    }

    //Used to request a tab as highlighted before running getView on a position (tab)
    public void requestActive(int position){
        RequestActive = true;
        getView(position, null, null);

    }

    //Goes through all the tabs and clears any highlight that might be
    public void requestNoHighlight() {
        Resources r = PagerActivityContext.getResources();
        for(int i = 0; i < PageCount; i++) {
            Drawable d = r.getDrawable(TabImages[i]);
            d.clearColorFilter();
        }
    }
}

