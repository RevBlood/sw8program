package program.sw8.sw8program;

import android.app.Fragment;
import android.os.Bundle;

/**
 * Created by Johan 'Jizztærsker' on 23-03-2015.
 */
public class RecipeTabInfo {
        private String tag;
        private Class<?> clss;
        private Bundle args;
        private Fragment fragment;

    public RecipeTabInfo(String tag, Class<?> clazz, Bundle args) {
            this.tag = tag;
            this.clss = clazz;
            this.args = args;
        }


}
