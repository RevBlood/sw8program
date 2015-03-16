import java.util.ArrayList;
import java.util.List;

import Models.*;
import Relationships.*;


public class ServiceHelper {

	public static void putAccount(Account newAcc){
		String response = null;
		//Account newAcc = new Account("Peter Pedal1234523232326", "peterpedal", "peter@pedal.com", "some settings", "some prefs");
		String serializedAcc = JSONHelper.Serializer(newAcc);
		System.out.println("Serialized acc: " + serializedAcc);
		
		String addAccount = "http://localhost:8000/RestService/Account/AddAccount";
		try {
			response = HTTPHelper.HTTPPut(addAccount, serializedAcc);
			System.out.println(response);
		} catch(Exception e) {
			System.out.println(e.toString());
			e.printStackTrace();
		}
	}
	
	public static Account getAccountById(int id){
		String response = null;
		try {
			//response = JSONHelper.HTTPGet("http://localhost:8000/RestService/Account/GetAllAccounts");
			response = HTTPHelper.HTTPGet("http://localhost:8000/RestService/Account/GetAccountById?accId=" + id);
			System.out.println(response);
			
		} catch (Exception e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		Account acc = JSONHelper.Deserialize(response, Account.class);
		return acc;
	}
	
	public static Account getAccountByUsername(String username){
		String response = null;
		try {
			response = HTTPHelper.HTTPGet("http://localhost:8000/RestService/Account/GetAccountByUsername?username=" + username);
			System.out.println(response);
			
		} catch (Exception e) {
			e.printStackTrace();
		}
		Account acc = JSONHelper.Deserialize(response, Account.class);
		return acc;
	}
	
	public static ArrayList<Account> getAllAccount(){
		String response = null;
		try {
			response = HTTPHelper.HTTPGet("http://localhost:8000/RestService/Account/GetAllAccounts");
			System.out.println(response);
			
		} catch (Exception e) {
			e.printStackTrace();
		}
		ArrayList<Account> acc = JSONHelper.DeserializeList(response, Account.class);
		return acc;
	}
	
	public static Ingredient getIngredientById(int id){
		String response = null;
		try {
			response = HTTPHelper.HTTPGet("http://localhost:8000/RestService/Ingredient/GetIngredientById?ingId=" + id);
			System.out.println(response);
			
		} catch (Exception e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		Ingredient ing = JSONHelper.Deserialize(response, Ingredient.class);
		return ing;
	}
	
	public static Account Login(String email, String password) {
		String response = null;
		try {
			response = HTTPHelper.HTTPGet("http://localhost:8000/RestService/Login/Login?email=" + email + "&password=" + password);
			Account acc = JSONHelper.Deserialize(response, Account.class);
			return acc;

		} catch (Exception e) {
			e.printStackTrace();
		}

		return null;
	}

}
