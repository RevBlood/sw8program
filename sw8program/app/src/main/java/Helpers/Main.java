package Helpers;

import Models.*;


public class Main {

	public static void main(String[] args) {
		
		putAccount();

		System.out.println("Program Ended");
	}
	
	public static void getAccount(){
		String response = null;
		try {
			//response = JSONHelper.HTTPGet("http://localhost:8000/RestService/Account/GetAllAccounts");
			response = HTTPHelper.HTTPGet("http://localhost:8000/RestService/Account/GetAccountByUsername?username=andrejs");
			System.out.println(response);
			
		} catch (Exception e) {
			e.printStackTrace();
		}
		Account acc = JSONHelper.Deserialize(response, Account.class);
		System.out.println(acc.getAlias());
	}
	
	public static void putAccount(){
		String response = null;
		Account newAcc = new Account("Peter Pedal1234523232326", "peterpedal", "peter@pedal.com", "some settings", "some prefs");
		JSONHelper jh = new JSONHelper();
		String serializedAcc = jh.Serializer(newAcc);
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
}
