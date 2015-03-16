package Relationships;

public class Favorises {
	public Favorises(){}
	
	public Favorises(int favorisesAccountId, int favorisesRecipeId){
		this.setAccountId(favorisesAccountId);
		this.setRecipeId(favorisesRecipeId);
	}
	
	//Favorises AccountId
	public int getAccountId(){
		return _favorisesAccountId;
	}
	public void setAccountId(int id){
		this._favorisesAccountId = id;
	}
	private int _favorisesAccountId;
	
	//Favorises RecipeId
	public int getRecipeId(){
		return _favorisesRecipeId;
	}
	public void setRecipeId(int id){
		this._favorisesRecipeId = id;
	}
	private int _favorisesRecipeId;
	
	@Override
	public String toString() {
		StringBuilder result = new StringBuilder();
		String space = " ";
		
		result.append(this.getAccountId() + space);
		result.append(this.getRecipeId() + space);
		
		return result.toString();	
	}
}
