package CommunicationModels;


import java.util.List;
import Models.*;
import Relationships.*;

public class RecipeWithIngredients {
	public RecipeWithIngredients(){};
	
	public RecipeWithIngredients(Recipe rec, List<Ingredient> ingredients, List<IngredientIn> ingredientIns) {
		this.setRecipe(rec);
		this.setIngredients(ingredients);
		this.setIngredientIns(ingredientIns);
	};
	
	//Recipe
	public Recipe getRecipe(){
		return _privateRecipe;
	}
	public void setRecipe(Recipe rec) {
		this._privateRecipe = rec;
	}
	private Recipe _privateRecipe;
	
	//Ingredients
	public List<Ingredient> getIngredients(){
		return _privateIngredients;
	}
	public void setIngredients(List<Ingredient> ingredients) {
		this._privateIngredients = ingredients;
	}
	private List<Ingredient> _privateIngredients;
	
	//IngredientIns
	public List<IngredientIn> getIngredientIns(){
		return _privateIngredientIns;
	}
	public void setIngredientIns(List<IngredientIn> ingredientIns) {
		this._privateIngredientIns = ingredientIns;
	}
	private List<IngredientIn> _privateIngredientIns;
}
