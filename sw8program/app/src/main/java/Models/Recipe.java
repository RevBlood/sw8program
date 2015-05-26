package Models;

import java.text.Format;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.math.BigDecimal;

import com.fasterxml.jackson.annotation.JsonIgnore;
import com.fasterxml.jackson.annotation.JsonProperty;

public class Recipe {
	public Recipe(){}
	
	public Recipe(int recipeAccountId, String recipeName, String recipeDescription,	int recipeNumberOfServings, 
			String recipeTags, BigDecimal recipeRating) {
		this.setAccountId(recipeAccountId);
		this.setName(recipeName);
		this.setDescription(recipeDescription);
		this.setNumberOfServings(recipeNumberOfServings);
		this.setTags(recipeTags);
		this.setRating(recipeRating);
	}
	
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
	@JsonIgnore
	public int getId(){
		return _recipeId;
	}
	@JsonProperty
	public void setId(int id){
		this._recipeId = id;
	}
	private int _recipeId;
	
	//Recipe AccountId
	public int getAccountId(){
		return _recipeAccountId;
	}
	@JsonProperty("accountid")
	public void setAccountId(int accountId) {
		this._recipeAccountId = accountId;
	}
	private int _recipeAccountId;
	
	//Recipe Name
	public String getName(){
		return _recipeName;
	}
	@JsonProperty("name")
	public void setName(String name) {
		this._recipeName = name;
	}
	private String _recipeName;
	
	//Recipe Description
	public String getDescription() {
		return _recipeDescription;
	}
	@JsonProperty("description")
	public void setDescription(String description){
		this._recipeDescription = description;
	}
	private String _recipeDescription;
	
	//Recipe CreationDate
	@JsonIgnore
	public Date getCreationDate(){
		return _recipeCreationDate;
	}
	@JsonProperty("creationdate")
	public void setCreationDate(Date creationDate){
		this._recipeCreationDate = creationDate;
	}
	private Date _recipeCreationDate;
	
	//Recipe NumberOfServings
	public int getNumberOfServings(){
		return _recipeNumberOfServings;
	}
	@JsonProperty("numberofservings")
	public void setNumberOfServings(int numberOfServings){
		this._recipeNumberOfServings = numberOfServings;
	}
	private int _recipeNumberOfServings;
	
	//Recipe Tags
	public String getTags(){
		return _recipeTags;
	}
	@JsonProperty("tags")
	public void setTags(String tags){
		this._recipeTags = tags;
	}
	private String _recipeTags;
	
	//Recipe Rating
	public BigDecimal getRating(){
		return _recipeRating;
	}
	@JsonProperty("rating")
	public void setRating(BigDecimal rating){
		this._recipeRating = rating;
	}
	private BigDecimal _recipeRating;
	
	@Override
	public String toString() {
		Format formatter = new SimpleDateFormat("dd-MM-yyyy HH:mm:ss");
		String result = "";
		String space = " ";
		
		result += (this.getId() + space);
		result += (this.getAccountId() + space);
		result += (this.getName() + space);
		result += (this.getDescription() + space);
		result += (formatter.format(this.getCreationDate()) + space);
		result += (this.getNumberOfServings() + space);
		result += (this.getTags() + space);
		result += (this.getRating() + space);

		return result;
	}
}
