package program.sw8.sw8program;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import java.util.List;

import Models.Ingredient;

/**
 * Created by Morten on 20-02-2015.
 */
public class RecipeIngredientAdapter extends ArrayAdapter<Ingredient> {
    private List<Ingredient> RecipeIngredients;
    private Context RecipeActivityContext;
    private int LayoutId;

    public RecipeIngredientAdapter(Context recipeActivityContextContext, int layoutId, List<Ingredient> ingredients) {
        super(recipeActivityContextContext, layoutId, ingredients);

        RecipeIngredients = ingredients;
        RecipeActivityContext = recipeActivityContextContext;
        LayoutId = layoutId;
    }

    @Override
    public int getCount() {
        return RecipeIngredients.size();
    }

    @Override
    public View getView(int position, View view, ViewGroup parent) {
        //Find relevant elements from the layout
        LayoutInflater inflater = (LayoutInflater) RecipeActivityContext.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        View row = inflater.inflate(LayoutId, parent, false);

        TextView amountView = (TextView) row.findViewById(R.id.ingredient_amount);
        TextView nameView = (TextView) row.findViewById(R.id.ingredient_name);

        amountView.setText(RecipeIngredients.get(position).getMeasure());
        nameView.setText(RecipeIngredients.get(position).getName());

        return row;
    }
}