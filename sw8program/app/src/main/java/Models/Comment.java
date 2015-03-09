package Models;

import java.util.Date;

public class Comment {
	public Comment() {}
	
	public Comment(int commentId, int commentAccountId, int commentRecipeId, Date commentCreationDate, String commentText) {
		this.setId(commentId);
		this.setAccountId(commentAccountId);
		this.setRecipeId(commentRecipeId);
		this.setCreationDate(commentCreationDate);
		this.setText(commentText);
	}
	
	//Comment Id
	public int getId() {
		return _commentId;
	}
	public void setId(int id){
		this._commentId = id;
	}
	private int _commentId;
	
	//Comment AccountId
	public int getAccountId(){
		return _commentAccountId;
	}
	public void setAccountId(int accountId) {
		this._commentAccountId = accountId;
	}
	private int _commentAccountId;
	
	//Comment RecipeId
	public int getRecipeId(){
		return _commentRecipeId;
	}
	public void setRecipeId(int recipeId) {
		this._commentRecipeId = recipeId;
	}
	private int _commentRecipeId;
	
	//Comment CreationDate
	public Date getCreationDate(){
		return _commentCreationDate;
	}
	public void setCreationDate(Date creationDate) {
		this._commentCreationDate = creationDate;
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
}
