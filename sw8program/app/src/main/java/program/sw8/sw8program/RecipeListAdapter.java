package program.sw8.sw8program;

import android.content.ClipData;
import android.content.Context;
import android.content.Intent;
import android.os.Parcel;
import android.os.Parcelable;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.BaseAdapter;
import android.widget.ImageView;
import android.widget.TextView;

import java.util.List;

import Models.Recipe;


public class RecipeListAdapter extends ArrayAdapter<Recipe>  {

    private Context _context;
    private int _layoutId;
    private List<Recipe> _listofRecipes;

    public RecipeListAdapter(Context context, int textViewResourceId, List<Recipe> listofRecipes) {
        super(context, textViewResourceId, listofRecipes);
        this._context = context;
        this._layoutId = textViewResourceId;
        this._listofRecipes = listofRecipes;

    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {

        if (convertView == null) {
            LayoutInflater inflater = (LayoutInflater) this._context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
            convertView = inflater.inflate(_layoutId, parent, false);
        }

        TextView RecipeName = (TextView) convertView.findViewById(R.id.recipe_name);
        TextView RecipePrice = (TextView) convertView.findViewById(R.id.recipe_price);
        TextView RecipeSavings = (TextView) convertView.findViewById(R.id.recipe_savings);
        ImageView RecipePicture = (ImageView) convertView.findViewById(R.id.recipe_picture);

        RecipeName.setText(_listofRecipes.get(position).getName());
        RecipePrice.setText("50 kr");
        RecipeSavings.setText("%%%");

        convertView.setOnClickListener(onRecipeClickListener);

        return convertView;

    }

    View.OnClickListener onRecipeClickListener = new View.OnClickListener() {
        @Override
        public void onClick(View v) {
            Intent intent = new Intent(_context, RecipeActivity.class);
            _context.startActivity(intent);
        }
    };
}
