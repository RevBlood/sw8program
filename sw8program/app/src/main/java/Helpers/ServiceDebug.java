import java.math.BigDecimal;
import java.util.Date;

import Models.*;
import Relationships.*;

public class ServiceDebug {
	
	public static boolean AccountTest(){
		try {
			Account newAcc = new Account("peter1235444@pedal.com", "peterpedal", "Peter Pedal1234523232326", "some settings", "some prefs");
			ServiceHelper.PutAccount(newAcc);
			ServiceHelper.GetAccountByEmail("andrejs@andrejs.com");
			ServiceHelper.GetAccountById(1);
			ServiceHelper.GetAllAccounts();
			return true;
		} catch(Exception e){
			return false;
		}
	}
	
	public static boolean CommentTest(){
		try {
			Comment newCom = new Comment(1,1,"a comment");
			ServiceHelper.PutComment(newCom);
			ServiceHelper.GetCommentById(1);
			ServiceHelper.GetCommentsByRecipeId(1);
			return true;
		} catch(Exception e){
			return false;
		}
	}
	
	public static boolean IngredientTest(){
		try {
			Ingredient newIng = new Ingredient("ingredient1", "gram", "500", new BigDecimal("5.90"), "tags");
			ServiceHelper.PutIngredient(newIng);
			ServiceHelper.GetIngredientById(1);
			ServiceHelper.GetIngredientByName("Kaffe");
			return true;
		} catch(Exception e){
			return false;
		}
	}
	
	public static boolean RecipeTest(){
		try {
			Recipe newRec = new Recipe(1, "name1", "description", 5, "tags", new BigDecimal("4.0"));
			ServiceHelper.PutRecipe(newRec);
			ServiceHelper.GetRecipeById(1);
			ServiceHelper.GetRecipesByAccountId(1);
			ServiceHelper.GetRecipeByIdWithIngredients(1);
			ServiceHelper.GetRecipesByIngredientId(1);
			return true;
		} catch(Exception e){
			return false;
		}
	}
	
	public static boolean RetailerTest(){
		try {
			Retailer newRet = new Retailer("lat", "long", "comp name", "description", "opening hours");
			ServiceHelper.PutRetailer(newRet);
			ServiceHelper.GetRetailerById(1);
			return true;
		} catch(Exception e){
			return false;
		}
	}
	
	public static boolean FavorisesTest(){
		try {
			Favorises newFav = new Favorises(1, 1);
			ServiceHelper.PutFavorises(newFav);
			ServiceHelper.GetFavorisesByAccountId(1);
			ServiceHelper.GetFavorisesByRecipeId(1);
			ServiceHelper.GetFavorisedRecipesByAccountId(1);
			return true;
		} catch(Exception e){
			return false;
		}
	}
	
	public static boolean HasEatenTest(){
		try {
			HasEaten newHas = new HasEaten(1,1, new BigDecimal("4.0"));
			ServiceHelper.PutHasEaten(newHas);
			return true;
		} catch(Exception e){
			return false;
		}
	}
	
	public static boolean IngredientInTest(){
		try {
			IngredientIn newIngIn = new IngredientIn(1, 1, 500);
			ServiceHelper.PutIngredientIn(newIngIn);
			ServiceHelper.GetIngredientInsByIngredientId(1);
			ServiceHelper.GetIngredientInsByRecipeId(1);
			return true;
		} catch(Exception e){
			return false;
		}
	}
	
	public static boolean OffersTest(){
		try {
			Offers newOff= new Offers(1, 1, new Date(), new Date(), new BigDecimal("10.00"), new BigDecimal("5.00"), 
					new BigDecimal("5.00"), new BigDecimal("50.00"), new BigDecimal("50.00"));
			ServiceHelper.PutOffers(newOff);
			ServiceHelper.GetOffersByIngredientId(1);
			ServiceHelper.GetOffersByRetailerId(1);
			return true;
		} catch(Exception e){
			return false;
		}
	}
	
	public static boolean PicturesTest(){
		try {
			Pictures newPic = new Pictures(1,1,"path to pic");
			ServiceHelper.PutPictures(newPic);
			ServiceHelper.GetPicturesByRecipeId(1);
			return true;
		} catch(Exception e){
			return false;
		}
	}
	
	public static boolean ServiceTest(){
		if(!AccountTest()){
			return false;
		}
		if(!CommentTest()){
			return false;
		}
		if(!IngredientTest()){
			return false;
		}
		if(!RecipeTest()){
			return false;
		}
		if(!RetailerTest()){
			return false;
		}
		if(!FavorisesTest()){
			return false;
		}
		if(!HasEatenTest()){
			return false;
		}
		if(!IngredientInTest()){
			return false;
		}
		if(!OffersTest()){
			return false;
		}
		if(!PicturesTest()){
			return false;
		}
		
		return false;
	}
}
