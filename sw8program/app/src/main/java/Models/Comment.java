package Models;

import java.text.Format;
import java.text.SimpleDateFormat;
import java.util.Date;

import com.fasterxml.jackson.annotation.JsonIgnore;
import com.fasterxml.jackson.annotation.JsonProperty;

public class Comment {
	public Comment() {}
	
	public Comment(int commentAccountId, int commentRecipeId, String commentText) {
		this.setAccountId(commentAccountId);
		this.setRecipeId(commentRecipeId);
		this.setText(commentText);
	}
	
	public Comment(int commentId, int commentAccountId, int commentRecipeId, Date commentCreationDate, String commentText) {
		this.setId(commentId);
		this.setAccountId(commentAccountId);
		this.setRecipeId(commentRecipeId);
		this.setCreationDate(commentCreationDate);
		this.setText(commentText);
	}
	
	//Comment Id
	@JsonIgnore
	public int getId() {
		return _commentId;
	}
	@JsonProperty
	public void setId(int id){
		this._commentId = id;
	}
	private int _commentId;
	
	//Comment AccountId
	public int getAccountId(){
		return _commentAccountId;
	}
	@JsonProperty("accountid")
	public void setAccountId(int accountId) {
		this._commentAccountId = accountId;
	}
	private int _commentAccountId;
	
	//Comment RecipeId
	@JsonProperty("recipeid")
	public int getRecipeId(){
		return _commentRecipeId;
	}
	public void setRecipeId(int recipeId) {
		this._commentRecipeId = recipeId;
	}
	private int _commentRecipeId;
	
	//Comment CreationDate
	@JsonIgnore
	public Date getCreationDate(){
		return _commentCreationDate;
	}
	@JsonProperty("creationdate")
	public void setCreationDate(Date creationdate) {
		this._commentCreationDate = creationdate;
	}
	private Date _commentCreationDate;
	
	//Comment Text
	public String getText(){
		return _commentText;
	}
	public void setText(String text) {
		this._commentText = text;
	}
	private String _commentText;
	
	@Override
	public String toString() {
		Format formatter = new SimpleDateFormat("dd-MM-yyyy HH:mm:ss");
		StringBuilder result = new StringBuilder();
		String space = " ";
		
		result.append(this.getId() + space);
		result.append(this.getAccountId() + space);
		result.append(this.getRecipeId() + space);
		result.append(formatter.format(this.getCreationDate()) + space);
		result.append(this.getText() + space);
		
		return result.toString();		
	}
}
