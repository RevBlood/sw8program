package Relationships;

import java.text.Format;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.math.BigDecimal;

import com.fasterxml.jackson.annotation.JsonIgnore;
import com.fasterxml.jackson.annotation.JsonProperty;

public class HasEaten {
	public HasEaten(){}
	
	public HasEaten(int hasEatenAccountId, int hasEatenRecipeId, BigDecimal hasEatenRating){
		this.setAccountId(hasEatenAccountId);
		this.setRecipeId(hasEatenRecipeId);
		this.setRating(hasEatenRating);
	}
	
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
	@JsonIgnore
	public Date getEatenAt(){
		return _hasEatenEatenAt;
	}
	@JsonProperty
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
	
	@Override
	public String toString() {
		Format formatter = new SimpleDateFormat("dd-MM-yyyy HH:mm:ss");
		StringBuilder result = new StringBuilder();
		String space = " ";
		
		result.append(this.getAccountId() + space);
		result.append(this.getRecipeId() + space);
		result.append(formatter.format(this.getEatenAt()) + space);
		result.append(this.getRating() + space);

		return result.toString();		
	}
}
