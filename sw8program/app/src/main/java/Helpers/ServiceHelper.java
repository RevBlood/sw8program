package Helpers;

import java.util.ArrayList;

import CommunicationModels.RecipeWithIngredients;
import Models.*;
import Relationships.*;

import program.sw8.sw8program.Ingredient;


public class ServiceHelper {
	private static String ip = "localhost";
	
	//Entities
	//Accounts
	
	public static boolean PostAccount(Account newAcc){
		String response = null;
		String serializedAcc = JSONHelper.Serializer(newAcc);
		System.out.println("Serialized account: " + serializedAcc);
		
		String addAccount = "http://" + ip + ":8000/RestService/Account/AddAccount";
		try {
			response = HTTPHelper.HTTPPost(addAccount, serializedAcc);
			System.out.println("Response: " + response);
			return true;
		} catch(Exception e) {
			e.printStackTrace();
			return false;
		}
	}
	
	public static Account GetAccountById(int id){
		String response = null;
		try {
			response = HTTPHelper.HTTPGet("http://" + ip + ":8000/RestService/Account/GetAccountById?accountId=" + id);
			System.out.println("Response: " + response);
		} catch (Exception e) {
			e.printStackTrace();
		}
		Account acc = JSONHelper.Deserialize(response, Account.class);
		return acc;
	}
	
	public static Account GetAccountByEmail(String email){
		String response = null;
		try {
			response = HTTPHelper.HTTPGet("http://" + ip + ":8000/RestService/Account/GetAccountByEmail?email=" + email);
			System.out.println("Response: " + response);
			
		} catch (Exception e) {
			e.printStackTrace();
		}
		Account acc = JSONHelper.Deserialize(response, Account.class);
		return acc;
	}
	
	public static ArrayList<Account> GetAllAccounts(){
		String response = null;
		try {
			response = HTTPHelper.HTTPGet("http://" + ip + ":8000/RestService/Account/GetAllAccounts");
			System.out.println("Response: " + response);
			
		} catch (Exception e) {
			e.printStackTrace();
		}
		ArrayList<Account> accounts = JSONHelper.DeserializeList(response, Account.class);
		return accounts;
	}
	
	//Comments
	
	public static boolean PostComment(Comment newCom){
		String response = null;
		String serializedCom = JSONHelper.Serializer(newCom);
		System.out.println("Serialized comment: " + serializedCom);
		
		String addComment = "http://" + ip + ":8000/RestService/Comment/AddComment";
		try {
			response = HTTPHelper.HTTPPost(addComment, serializedCom);
			System.out.println("Response: " + response);
			return true;
		} catch(Exception e) {
			e.printStackTrace();
			return false;
		}
	}
	
	public static Comment GetCommentById(int id){
		String response = null;
		try {
			response = HTTPHelper.HTTPGet("http://" + ip + ":8000/RestService/Comment/GetCommentById?commentId=" + id);
			System.out.println("Response: " + response);
			
		} catch (Exception e) {
			e.printStackTrace();
		}
		Comment com = JSONHelper.Deserialize(response, Comment.class);
		return com;
	}
	
	public static ArrayList<Comment> GetCommentsByRecipeId(int recipeId){
		String response = null;
		try {
			response = HTTPHelper.HTTPGet("http://" + ip + ":8000/RestService/Comment/GetCommentsByRecipeId?recipeId=" + recipeId);
			System.out.println(response);
			
		} catch (Exception e) {
			e.printStackTrace();
		}
		ArrayList<Comment> comments = JSONHelper.DeserializeList(response, Comment.class);
		return comments;
	}
	
	public static ArrayList<Comment> GetAllComments(){
		String response = null;
		try {
			response = HTTPHelper.HTTPGet("http://" + ip + ":8000/RestService/Comment/GetAllComments");
			System.out.println(response);
			
		} catch (Exception e) {
			e.printStackTrace();
		}
		ArrayList<Comment> comments = JSONHelper.DeserializeList(response, Comment.class);
		return comments;
	}

	//Ingredients
	
	public static boolean PostIngredient(Ingredient newIng){
		String response = null;
		String serializedIng = JSONHelper.Serializer(newIng);
		System.out.println("Serialized ingredient: " + serializedIng);
		
		String addIngredient = "http://" + ip + ":8000/RestService/Ingredient/AddIngredient";
		try {
			response = HTTPHelper.HTTPPost(addIngredient, serializedIng);
			System.out.println(response);
			return true;
		} catch(Exception e) {
			e.printStackTrace();
			return false;
		}
	}
	
	public static Ingredient GetIngredientById(int id){
		String response = null;
		try {
			response = HTTPHelper.HTTPGet("http://" + ip + ":8000/RestService/Ingredient/GetIngredientById?ingredientId=" + id);
			System.out.println(response);
			
		} catch (Exception e) {
			e.printStackTrace();
		}
		Ingredient ing = JSONHelper.Deserialize(response, Ingredient.class);
		return ing;
	}
	
	public static Ingredient GetIngredientByName(String name){
		String response = null;
		try {
			response = HTTPHelper.HTTPGet("http://" + ip + ":8000/RestService/Ingredient/GetIngredientByName?name=" + name);
			System.out.println(response);
			
		} catch (Exception e) {
			e.printStackTrace();
		}
		Ingredient ing = JSONHelper.Deserialize(response, Ingredient.class);
		return ing;
	}
	
	public static ArrayList<Ingredient> GetIngredientsByRecipeId(int recipeId){
		String response = null;
		try {
			response = HTTPHelper.HTTPGet("http://" + ip + ":8000/RestService/Ingredient/GetIngredientsByRecipeId?recipeId=" + recipeId);
			System.out.println(response);
			
		} catch (Exception e) {
			e.printStackTrace();
		}
		ArrayList<Ingredient> ingredients = JSONHelper.DeserializeList(response, Ingredient.class);
		return ingredients;
	}
	
	public static ArrayList<Ingredient> GetAllIngredients(){
		String response = null;
		try {
			response = HTTPHelper.HTTPGet("http://" + ip + ":8000/RestService/Ingredient/GetAllIngredients");
			System.out.println(response);
			
		} catch (Exception e) {
			e.printStackTrace();
		}
		ArrayList<Ingredient> ingredients = JSONHelper.DeserializeList(response, Ingredient.class);
		return ingredients;
	}

	//Recipes
	
	public static boolean PostRecipe(Recipe newRec){
		String response = null;
		String serializedRec = JSONHelper.Serializer(newRec);
		System.out.println("Serialized Recipe: " + serializedRec);
		
		String addRecipe = "http://" + ip + ":8000/RestService/Recipe/AddRecipe";
		try {
			response = HTTPHelper.HTTPPost(addRecipe, serializedRec);
			System.out.println(response);
			return true;
		} catch(Exception e) {
			e.printStackTrace();
			return false;
		}
	}
	
	public static Recipe GetRecipeById(int id){
		String response = null;
		try {
			response = HTTPHelper.HTTPGet("http://" + ip + ":8000/RestService/Recipe/GetRecipeById?recipeId=" + id);
			System.out.println(response);
		} catch (Exception e) {
			e.printStackTrace();
		}
		Recipe recipe = JSONHelper.Deserialize(response, Recipe.class);
		return recipe;
	}
	
	public static ArrayList<Recipe> GetRecipesByAccountId(int accountId){
		String response = null;
		try {
			response = HTTPHelper.HTTPGet("http://" + ip + ":8000/RestService/Recipe/GetRecipeByAccountId?accountId=" + accountId);
			System.out.println(response);
		} catch (Exception e) {
			e.printStackTrace();
		}
		ArrayList<Recipe> recipes = JSONHelper.DeserializeList(response, Recipe.class);
		return recipes;
	}
	
	public static ArrayList<Recipe> GetRecipesByIngredientId(int ingredientId){
		String response = null;
		try {
			response = HTTPHelper.HTTPGet("http://" + ip + ":8000/RestService/Recipe/GetRecipesByIngredientId?ingredientId=" + ingredientId);
			System.out.println(response);
		} catch (Exception e) {
			e.printStackTrace();
		}
		ArrayList<Recipe> recipes = JSONHelper.DeserializeList(response, Recipe.class);
		return recipes;
	}
	
	public static RecipeWithIngredients GetRecipeByIdWithIngredients(int id){
		String response = null;
		try {
			response = HTTPHelper.HTTPGet("http://" + ip + ":8000/RestService/Recipe/GetRecipesByIdWithIngredients?recipeId=" + id);
			System.out.println(response);
		} catch (Exception e) {
			e.printStackTrace();
		}
		RecipeWithIngredients recipes = JSONHelper.Deserialize(response, RecipeWithIngredients.class);
		return recipes;
	}
	
	public static ArrayList<Recipe> GetAllRecipes(){
		String response = null;
		try {
			response = HTTPHelper.HTTPGet("http://" + ip + ":8000/RestService/Recipe/GetAllRecipes");
			System.out.println(response);
		} catch (Exception e) {
			e.printStackTrace();
		}
		ArrayList<Recipe> recipes = JSONHelper.DeserializeList(response, Recipe.class);
		return recipes;
	}
	
	//Retailers
	
	public static boolean PostRetailer(Retailer newRet){
		String response = null;
		String serializedRet = JSONHelper.Serializer(newRet);
		System.out.println("Serialized Retailer: " + serializedRet);
		
		String addRetailer = "http://" + ip + ":8000/RestService/Retailer/AddRetailer";
		try {
			response = HTTPHelper.HTTPPost(addRetailer, serializedRet);
			System.out.println(response);
			return true;
		} catch(Exception e) {
			e.printStackTrace();
			return false;
		}
	}
	
	public static Retailer GetRetailerById(int id){
		String response = null;
		try {
			response = HTTPHelper.HTTPGet("http://" + ip + ":8000/RestService/Retailer/GetRetailerById?retailerId=" + id);
			System.out.println(response);
		} catch (Exception e) {
			e.printStackTrace();
		}
		Retailer retailer = JSONHelper.Deserialize(response, Retailer.class);
		return retailer;
	}
	
	public static ArrayList<Retailer> GetAllRetailers(){
		String response = null;
		try {
			response = HTTPHelper.HTTPGet("http://" + ip + ":8000/RestService/Retailer/GetAllRetailers");
			System.out.println(response);
		} catch (Exception e) {
			e.printStackTrace();
		}
		ArrayList<Retailer> retailers = JSONHelper.DeserializeList(response, Retailer.class);
		return retailers;
	}
	
	//Relationships
	//Favorises
	
	public static boolean PostFavorises(Favorises newFav){
		String response = null;
		String serializedFav = JSONHelper.Serializer(newFav);
		System.out.println("Serialized Favorises: " + serializedFav);
		
		String addFavorises = "http://" + ip + ":8000/RestService/Favorises/AddFavorises";
		try {
			response = HTTPHelper.HTTPPost(addFavorises, serializedFav);
			System.out.println(response);
			return true;
		} catch(Exception e) {
			e.printStackTrace();
			return false;
		}
	}
	
	public static ArrayList<Favorises> GetFavorisesByAccountId(int accountId){
		String response = null;
		try {
			response = HTTPHelper.HTTPGet("http://" + ip + ":8000/RestService/Favorises/GetFavorisesByAccountId?accountId=" + accountId);
			System.out.println(response);
		} catch (Exception e) {
			e.printStackTrace();
		}
		ArrayList<Favorises> favorises = JSONHelper.DeserializeList(response, Favorises.class);
		return favorises;
	}
	
	public static ArrayList<Favorises> GetFavorisesByRecipeId(int recipeId){
		String response = null;
		try {
			response = HTTPHelper.HTTPGet("http://" + ip + ":8000/RestService/Favorises/GetFavorisesByRecipeId?recipeId=" + recipeId);
			System.out.println(response);
		} catch (Exception e) {
			e.printStackTrace();
		}
		ArrayList<Favorises> favorises = JSONHelper.DeserializeList(response, Favorises.class);
		return favorises;
	}
	
	public static ArrayList<Recipe> GetFavorisedRecipesByAccountId(int accountId){
		String response = null;
		try {
			response = HTTPHelper.HTTPGet("http://" + ip + ":8000/RestService/Favorises/GetFavorisedRecipesByAccountId?accountId=" + accountId);
			System.out.println(response);
		} catch (Exception e) {
			e.printStackTrace();
		}
		ArrayList<Recipe> recipes = JSONHelper.DeserializeList(response, Recipe.class);
		return recipes;
	}
	
	//HasEaten
	
	public static boolean PostHasEaten(HasEaten newHas){
		String response = null;
		String serializedHas = JSONHelper.Serializer(newHas);
		System.out.println("Serialized HasEaten: " + serializedHas);
		
		String addHasEaten = "http://" + ip + ":8000/RestService/HasEaten/AddHasEaten";
		try {
			response = HTTPHelper.HTTPPost(addHasEaten, serializedHas);
			System.out.println(response);
			return true;
		} catch(Exception e) {
			e.printStackTrace();
			return false;
		}
	}

	//IngredientIn
	
	public static boolean PostIngredientIn(IngredientIn newIngIn){
		String response = null;
		String serializedIngIn = JSONHelper.Serializer(newIngIn);
		System.out.println("Serialized IngredientIn: " + serializedIngIn);
		
		String addIngredientIn = "http://" + ip + ":8000/RestService/IngredientIn/AddIngredientIn";
		try {
			response = HTTPHelper.HTTPPost(addIngredientIn, serializedIngIn);
			System.out.println(response);
			return true;
		} catch(Exception e) {
			e.printStackTrace();
			return false;
		}
	}
	public static ArrayList<IngredientIn> GetIngredientInsByIngredientId(int ingredientId){
		String response = null;
		try {
			response = HTTPHelper.HTTPGet("http://" + ip + ":8000/RestService/IngredientIn/GetIngredientInsByIngredientId?ingredientId=" + ingredientId);
			System.out.println(response);
		} catch (Exception e) {
			e.printStackTrace();
		}
		ArrayList<IngredientIn> ingredientIn = JSONHelper.DeserializeList(response, IngredientIn.class);
		return ingredientIn;
	}
	
	public static ArrayList<IngredientIn> GetIngredientInsByRecipeId(int recipeId){
		String response = null;
		try {
			response = HTTPHelper.HTTPGet("http://" + ip + ":8000/RestService/IngredientIn/GetIngredientInsByRecipeId?recipeId=" + recipeId);
			System.out.println(response);
		} catch (Exception e) {
			e.printStackTrace();
		}
		ArrayList<IngredientIn> ingredientIn = JSONHelper.DeserializeList(response, IngredientIn.class);
		return ingredientIn;
	}
	
	//Offers
	
	public static boolean PostOffers(Offers newOff){
		String response = null;
		String serializedOff = JSONHelper.Serializer(newOff);
		System.out.println("Serialized Offers: " + serializedOff);
		
		String addOffers = "http://" + ip + ":8000/RestService/Offers/AddOffers";
		try {
			response = HTTPHelper.HTTPPost(addOffers, serializedOff);
			System.out.println(response);
			return true;
		} catch(Exception e) {
			e.printStackTrace();
			return false;
		}
	}
	
	public static ArrayList<Offers> GetOffersByRetailerId(int retailerId){
		String response = null;
		try {
			response = HTTPHelper.HTTPGet("http://" + ip + ":8000/RestService/Offers/GetOffersByRetailerId?retailerId=" + retailerId);
			System.out.println(response);
		} catch (Exception e) {
			e.printStackTrace();
		}
		ArrayList<Offers> offers = JSONHelper.DeserializeList(response, Offers.class);
		return offers;
	}
	
	public static ArrayList<Offers> GetOffersByIngredientId(int ingredientId){
		String response = null;
		try {
			response = HTTPHelper.HTTPGet("http://" + ip + ":8000/RestService/Offers/GetOffersByIngredientId?ingredientId=" + ingredientId);
			System.out.println(response);
		} catch (Exception e) {
			e.printStackTrace();
		}
		ArrayList<Offers> offers = JSONHelper.DeserializeList(response, Offers.class);
		return offers;
	}
	
	//Pictures
	
	public static boolean PostPictures(Pictures newPic){
		String response = null;
		String serializedPic = JSONHelper.Serializer(newPic);
		System.out.println("Serialized Pictures: " + serializedPic);
		
		String addPictures = "http://" + ip + ":8000/RestService/Pictures/AddPictures";
		try {
			response = HTTPHelper.HTTPPost(addPictures, serializedPic);
			System.out.println(response);
			return true;
		} catch(Exception e) {
			e.printStackTrace();
			return false;
		}
	}
	
	public static ArrayList<Pictures> GetPicturesByRecipeId(int recipeId){
		String response = null;
		try {
			response = HTTPHelper.HTTPGet("http://" + ip + ":8000/RestService/Pictures/GetPicturesByRecipeId?recipeId=" + recipeId);
			System.out.println(response);
		} catch (Exception e) {
			e.printStackTrace();
		}
		ArrayList<Pictures> pictures = JSONHelper.DeserializeList(response, Pictures.class);
		return pictures;
	}
	
	//Specials
	
	public static Account Login(String email, String password) {
		String response = null;
		try {
			response = HTTPHelper.HTTPGet("http://" + ip + ":8000/RestService/Login/Login?email=" + email + "&password=" + password);
			Account acc = JSONHelper.Deserialize(response, Account.class);
			return acc;

		} catch (Exception e) {
			e.printStackTrace();
		}

		return null;
	}

}
