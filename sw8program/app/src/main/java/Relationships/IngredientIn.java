package Relationships;

public class IngredientIn {
	
	public IngredientIn(){}
	
	public IngredientIn(int ingredientInIngredientId, int ingredientInRecipeId, int ingredientInAmount){
		this.setIngredientId(ingredientInIngredientId);
		this.setRecipeId(ingredientInRecipeId);
		this.setAmount(ingredientInAmount);
	}
	
	//IngredientIn IngredientId
	public int getIngredientId(){
		return _ingredientInIngredientId;
	}
	public void setIngredientId(int id){
		this._ingredientInIngredientId = id;
	}
	private int _ingredientInIngredientId;
	
	//IngredientIn RecipeId
	public int getRecipeId(){
		return _ingredientInRecipeId;
	}
	public void setRecipeId(int id){
		this._ingredientInRecipeId = id;	
	}
	private int _ingredientInRecipeId;
	
	//IngredientIn amount
	public int getAmount(){
		return _ingredientInAmount;
	}
	public void setAmount(int amount){
		this._ingredientInAmount = amount;
	}
	private int _ingredientInAmount;
	
	@Override
	public String toString() {
		StringBuilder result = new StringBuilder();
		String space = " ";
		
		result.append(this.getIngredientId() + space);
		result.append(this.getRecipeId() + space);
		result.append(this.getAmount() + space);
		
		return result.toString();	
	}
}
