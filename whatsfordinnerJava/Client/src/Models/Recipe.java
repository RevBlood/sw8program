package Models;

import java.util.Date;
import java.math.BigDecimal;

public class Recipe {
	public Recipe(){}
	
	public Recipe(int recipeId, int recipeAccountId, String recipeName, String recipeDescription, 
			Date recipeCreationDate, int recipeNumberOfServings, String recipeTags, BigDecimal recipeRating) {
		this.setId(recipeId);
		this.setAccountId(recipeAccountId);
		this.setName(recipeName);
		this.setDescription(recipeDescription);
		this.setCreationDate(recipeCreationDate);
		this.setNumberOfServings(recipeNumberOfServings);
		this.setTags(recipeTags);
		this.setRating(recipeRating);
	}
	
	//Recipe Id
	public int getId(){
		return _recipeId;
	}
	public void setId(int id){
		this._recipeId = id;
	}
	private int _recipeId;
	
	//Recipe AccountId
	public int getAccountId(){
		return _recipeAccountId;
	}
	public void setAccountId(int accountId) {
		this._recipeAccountId = accountId;
	}
	private int _recipeAccountId;
	
	//Recipe Name
	public String getName(){
		return _recipeName;
	}
	public void setName(String name) {
		this._recipeName = name;
	}
	private String _recipeName;
	
	//Recipe Description
	public String getDescription() {
		return _recipeDescription;
	}
	public void setDescription(String description){
		this._recipeDescription = description;
	}
	private String _recipeDescription;
	
	//Recipe CreationDate
	public Date getCreationDate(){
		return _recipeCreationDate;
	}
	public void setCreationDate(Date creationDate){
		this._recipeCreationDate = creationDate;
	}
	private Date _recipeCreationDate;
	
	//Recipe NumberOfServings
	public int getNumberOfSercings(){
		return _recipeNumberOfServings;
	}
	public void setNumberOfServings(int numberOfServings){
		this._recipeNumberOfServings = numberOfServings;
	}
	private int _recipeNumberOfServings;
	
	//Recipe Tags
	public String getTags(){
		return _recipeTags;
	}
	public void setTags(String tags){
		this._recipeTags = tags;
	}
	private String _recipeTags;
	
	//Recipe Rating
	public BigDecimal getRating(){
		return _recipeRating;
	}
	public void setRating(BigDecimal rating){
		this._recipeRating = rating;
	}
	private BigDecimal _recipeRating;
}
