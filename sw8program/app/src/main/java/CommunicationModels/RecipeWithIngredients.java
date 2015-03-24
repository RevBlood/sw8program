package CommunicationModels;

import java.util.*;

import com.fasterxml.jackson.annotation.JsonProperty;

import Models.*;
import Relationships.*;

public class RecipeWithIngredients {
	public RecipeWithIngredients(){};
	
	public RecipeWithIngredients(Recipe rec, ArrayList<Ingredient> ingredients, ArrayList<IngredientIn> ingredientIns) {
		this.setRecipe(rec);
		this.setIngredients(ingredients);
		this.setIngredientIns(ingredientIns);
	};
	
	//Recipe
	public Recipe getRecipe(){
		return _privateRecipe;
	}
	@JsonProperty("recipe")
	public void setRecipe(Recipe rec) {
		this._privateRecipe = rec;
	}
	private Recipe _privateRecipe;
	
	//Ingredients
	public ArrayList<Ingredient> getIngredients(){
		return _privateIngredients;
	}
	@JsonProperty("ingredients")
	public void setIngredients(ArrayList<Ingredient> ingredients) {
		this._privateIngredients = ingredients;
	}
	private ArrayList<Ingredient> _privateIngredients;
	
	//IngredientIns
	public ArrayList<IngredientIn> getIngredientIns(){
		return _privateIngredientIns;
	}
	@JsonProperty("amounts")
	public void setIngredientIns(ArrayList<IngredientIn> ingredientIns) {
		this._privateIngredientIns = ingredientIns;
	}
	private ArrayList<IngredientIn> _privateIngredientIns;
}
