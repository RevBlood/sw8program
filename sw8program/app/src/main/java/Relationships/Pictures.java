package Relationships;

import java.util.Date;

public class Pictures {
	public Pictures(){
	}

	public Pictures(String test){
	}
	
	//Pictures AccountId
	public int getAccountId(){
		return _picturesAccountId;
	}
	public void setAccountId(int id){
		this._picturesAccountId = id;
	}
	private int _picturesAccountId;
	
	//Pictures RecipeId
	public int getRecipeId(){
		return _picturesRecipeId;
	}
	public void setRecipeId(int id){
		this._picturesRecipeId = id;	
	}
	private int _picturesRecipeId;
	
	//Pictures PicturePath
	public String getPicturePath(){
		return _picturesPicturePath;
	}
	public void setPicturePath(String picturePath){
		this._picturesPicturePath = picturePath;
	}
	private String _picturesPicturePath;
	
	//Pictures CreationDate
	public Date getCreationDate(){
		return _picturestCreationDate;
	}
	public void setCreationDate(Date creationDate) {
		this._picturestCreationDate = creationDate;
	}
	private Date _picturestCreationDate;
}
