package Relationships;

import java.util.Date;
import java.math.BigDecimal;

public class HasEaten {
	public HasEaten(){}
	
	public HasEaten(int hasEatenAccountId, int hasEatenRecipeId, Date hasEatenEatenAt, BigDecimal hasEatenRating){
		this.setAccountId(hasEatenAccountId);
		this.setRecipeId(hasEatenRecipeId);
		this.setEatenAt(hasEatenEatenAt);
		this.setRating(hasEatenRating);
	}
	
	//HasEaten AccountId
	public int getAccountId(){
		return _hasEatenAccountId;
	}
	public void setAccountId(int id){
		this._hasEatenAccountId = id;
	}
	private int _hasEatenAccountId;
	
	//HasEaten RecipeId
	public int getRecipeId(){
		return _hasEatenRecipeId;
	}
	public void setRecipeId(int id){
		this._hasEatenRecipeId = id;
	}
	private int _hasEatenRecipeId;
	
	//HasEaten EatenAt
	public Date getEatenAt(){
		return _hasEatenEatenAt;
	}
	public void setEatenAt(Date eatenAt){
		this._hasEatenEatenAt = eatenAt;
	}
	private Date _hasEatenEatenAt;
	
	//HasEaten Rating
	public BigDecimal getRating(){
		return _hasEatenRating;
	}
	public void setRating(BigDecimal rating){
		this._hasEatenRating = rating;
	}
	private BigDecimal _hasEatenRating;
}
