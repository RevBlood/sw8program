package Models;

import java.util.Date;

import com.fasterxml.jackson.annotation.JsonIgnore;

public class Account {
	public Account() {

	}
	// Test for dbInsertion
	public Account(String accountUsername, String accountPassword, String accountEmail, String accountSettings, 
			String accountPreferences) {
		setUsername(accountUsername);
		setPassword(accountPassword);
		setEmail(accountEmail);
		setSettings(accountSettings);
		setPreferences(accountPreferences);
	}
	
	// Test without creationDate
	public Account(int accountId, String accountUsername, String accountPassword, String accountEmail, 
			String accountSettings, String accountPreferences) {
		setId(accountId);
		setUsername(accountUsername);
		setPassword(accountPassword);
		setEmail(accountEmail);
		setSettings(accountSettings);
		setPreferences(accountPreferences);
	}
	
	public Account(int accountId, String accountUsername, String accountPassword, String accountEmail, Date accountCreationDate, 
			String accountSettings, String accountPreferences) {
		setId(accountId);
		setUsername(accountUsername);
		setPassword(accountPassword);
		setEmail(accountEmail);
		setCreationDate(accountCreationDate);
		setSettings(accountSettings);
		setPreferences(accountPreferences);
	}
	
	//Account Id
	@JsonIgnore
	public int getId(){
		return _accountId;
	}
	public void setId(int id){
		this._accountId = id;
	}
	private int _accountId;
	
	//Account Username
	public String getUsername() {
		return _accountUsername;
	}
	public void setUsername(String username) {
		this._accountUsername = username;
	}
	private String _accountUsername;
	
	//Account Password
	public String getPassword() {
		return _accountPassword;
	}
	public void setPassword(String password) {
		this._accountPassword = password;
	}
	private String _accountPassword;
	
	//Account Email
	public String getEmail(){
		return _accountEmail;
	}
	public void setEmail(String email) {
		this._accountEmail = email;
	}
	private String _accountEmail;
	
	//Account CreationDate
	@JsonIgnore
	public Date getCreationDate(){
		return _accountCreationDate;
	}
	public void setCreationDate(Date creationDate) {
		this._accountCreationDate = creationDate;
	}
	private Date _accountCreationDate;
	
	//Account settings
	public String getSettings() {
		return _accountSettings;
	}
	public void setSettings(String settings){
		this._accountSettings = settings;
	}
	private String _accountSettings;
	
	//Account Preferences
	public String getPreferences(){
		return _accountPreferences;
	}
	public void setPreferences(String preferences) {
		this._accountPreferences = preferences;
	}
	private String _accountPreferences;
}
