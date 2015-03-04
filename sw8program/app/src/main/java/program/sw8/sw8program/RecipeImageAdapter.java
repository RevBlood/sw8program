package program.sw8.sw8program;

import android.content.Context;
import android.graphics.Point;
import android.graphics.drawable.Drawable;
import android.support.v4.view.PagerAdapter;
import android.support.v4.view.ViewPager;
import android.util.AttributeSet;
import android.util.DisplayMetrics;
import android.view.Display;
import android.view.View;
import android.view.ViewGroup;
import android.view.WindowManager;
import android.widget.ImageView;
import android.widget.RelativeLayout;

import java.util.List;

/**
 * Created by Morten on 04-03-2015.
 */
public class RecipeImageAdapter extends PagerAdapter {
    private Context RecipeActivityContext;
    private List<Drawable> RecipeImages;

    public RecipeImageAdapter(Context recipeActivityContext, List<Drawable> recipeImages) {
        RecipeActivityContext = recipeActivityContext;
        RecipeImages = recipeImages;
    }

    @Override
    public int getCount() {
        return RecipeImages.size();
    }

    @Override
    public boolean isViewFromObject(View view, Object object) {
        return view == ((ImageView) object);
    }

    @Override
    public Object instantiateItem(ViewGroup container, int position) {
        WindowManager windowManager = (WindowManager) RecipeActivityContext.getSystemService(Context.WINDOW_SERVICE);
        Display display = windowManager.getDefaultDisplay();
        Point size = new Point();
        display.getSize(size);
        int width = size.x;
        int height = width;
        RelativeLayout.LayoutParams lp = new RelativeLayout.LayoutParams(width,height);
        container.setLayoutParams(lp);
        ImageView imageView = new ImageView(RecipeActivityContext);
        //imageView.setScaleType(ImageView.ScaleType.CENTER_INSIDE);
        imageView.setBackground(RecipeImages.get(position));
        ((ViewPager) container).addView(imageView, 0);
        return imageView;
    }

    @Override
    public void destroyItem(ViewGroup container, int position, Object object) {
        ((ViewPager) container).removeView((ImageView) object);
    }
}