package Models;

import java.text.Format;
import java.text.SimpleDateFormat;
import java.util.Date;

import com.fasterxml.jackson.annotation.JsonIgnore;
import com.fasterxml.jackson.annotation.JsonProperty;

public class Account {
	public Account() {}
	
	public Account(int accountId, String accountEmail, String accountPassword, String accountAlias, Date accountCreationDate, 
			String accountSettings, String accountPreferences) {
		setId(accountId);
		setAlias(accountAlias);
		setPassword(accountPassword);
		setEmail(accountEmail);
		setCreationDate(accountCreationDate);
		setSettings(accountSettings);
		setPreferences(accountPreferences);
	}
	/*
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
	*/
	// Test for dbInsertion
	public Account(String accountEmail, String accountPassword, String accountAlias, String accountSettings, 
			String accountPreferences) {
		setAlias(accountAlias);
		setPassword(accountPassword);
		setEmail(accountEmail);
		setSettings(accountSettings);
		setPreferences(accountPreferences);
	}
	

	//Account Id
    @JsonIgnore
	public int getId(){
		return _accountId;
	}
    @JsonProperty
	public void setId(int id){
		this._accountId = id;
	}
	private int _accountId;
	
	//Account Email
	public String getEmail(){
		return _accountEmail;
	}
	public void setEmail(String email) {
		this._accountEmail = email;
	}
	private String _accountEmail;
	
	//Account Password
	public String getPassword() {
		return _accountPassword;
	}
	public void setPassword(String password) {
		this._accountPassword = password;
	}
	private String _accountPassword;
	
	//Account Alias
	public String getAlias() {
		return _accountAlias;
	}
	public void setAlias(String alias) {
		this._accountAlias = alias;
	}
	private String _accountAlias;

    //Account CreationDate
    @JsonIgnore
	public Date getCreationDate(){
		return _accountCreationDate;
	}
    @JsonProperty
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

    //TODO: Finish the image stuff
    public boolean hasImage() {
        return false;
    }

    public Integer getImageId() {
        return 0;
    }

    public void setImageId(Integer id) {

    }

    @Override
	public String toString() {
		Format formatter = new SimpleDateFormat("dd-MM-yyyy HH:mm:ss");
		StringBuilder result = new StringBuilder();
		String space = " ";
		
		result.append(this.getId() + space);
		result.append(this.getAlias() + space);
		result.append(this.getPassword() + space);
		result.append(this.getEmail() + space);
		result.append(formatter.format(this.getCreationDate()) + space);
		result.append(this.getSettings() + space);
		result.append(this.getPreferences() + space);

		return result.toString();		
	}
}
