package Relationships;

import java.text.Format;
import java.text.SimpleDateFormat;
import java.util.Date;

public class Pictures {
	public Pictures(){}
	
	public Pictures(int picturesAccountId, int picturesRecipeId, String picturePicturePath, Date picturesCreationDate){
		this.setAccountId(picturesAccountId);
		this.setRecipeId(picturesRecipeId);
		this.setPicturePath(picturePicturePath);
		this.setCreationDate(picturesCreationDate);
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
	
	@Override
	public String toString() {
		Format formatter = new SimpleDateFormat("dd-MM-yyyy HH:mm:ss");
		StringBuilder result = new StringBuilder();
		String space = " ";
		
		result.append(this.getAccountId() + space);
		result.append(this.getRecipeId() + space);
		result.append(this.getPicturePath() + space);
		result.append(formatter.format(this.getCreationDate()) + space);


		return result.toString();		
	}
}
