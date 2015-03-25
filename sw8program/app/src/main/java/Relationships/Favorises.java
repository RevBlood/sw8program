package Relationships;

import com.fasterxml.jackson.annotation.JsonProperty;

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
	@JsonProperty("accountid")
	public void setAccountId(int id){
		this._favorisesAccountId = id;
	}
	private int _favorisesAccountId;
	
	//Favorises RecipeId
	public int getRecipeId(){
		return _favorisesRecipeId;
	}
	@JsonProperty("recipeid")
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

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;

        Favorises favorises = (Favorises) o;

        if (_favorisesAccountId != favorises._favorisesAccountId) return false;
        if (_favorisesRecipeId != favorises._favorisesRecipeId) return false;

        return true;
    }
}
