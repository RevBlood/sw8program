package Models;

import com.fasterxml.jackson.annotation.JsonIgnore;
import com.fasterxml.jackson.annotation.JsonProperty;

public class Retailer {
	public Retailer(){}
	
	public Retailer(String retailerLatitude, String retailerLongitude, String retailerCompanyName, 
			String retailerDescription, String retailerOpeningHours) {
		this.setLatitude(retailerLatitude);
		this.setLongitude(retailerLongitude);
		this.setCompanyName(retailerCompanyName);
		this.setDescription(retailerDescription);
		this.setOpeningHours(retailerOpeningHours);
	}
	
	public Retailer(int retailerId, String retailerLatitude, String retailerLongitude, String retailerCompanyName, 
			String retailerDescription, String retailerOpeningHours) {
		this.setId(retailerId);
		this.setLatitude(retailerLatitude);
		this.setLongitude(retailerLongitude);
		this.setCompanyName(retailerCompanyName);
		this.setDescription(retailerDescription);
		this.setOpeningHours(retailerOpeningHours);
	}
	
	//Retailer Id
	@JsonIgnore
	public int getId(){
		return _retailerId;
	}
	@JsonProperty
	public void setId(int id){
		this._retailerId = id;
	}
	private int _retailerId;
	
	//Retailer Latitude
	public String getLatitude(){
		return _retailerLatitude;
	}
	@JsonProperty("latitude")
	public void setLatitude(String latitude){
		this._retailerLatitude = latitude;
	}
	private String _retailerLatitude;
	
	//Retailer Longitude
	public String getLongitude(){
		return _retailerLongitude;
	}
	@JsonProperty("longitude")
	public void setLongitude(String longitude){
		this._retailerLongitude = longitude;
	}
	private String _retailerLongitude;
	
	//Retailer CompanyName
	public String getCompanyName(){
		return _retailerCompanyName;
	}
	@JsonProperty("companyname")
	public void setCompanyName(String companyName){
		this._retailerCompanyName = companyName;
	}
	private String _retailerCompanyName;
	
	//Retailer Description
	public String getDescription(){
		return _retailerDescription;
	}
	@JsonProperty("description")
	public void setDescription(String description){
		this._retailerDescription = description;
	}
	private String _retailerDescription;
	
	//Retailer OpeningHours
	public String getOpeningHours(){
		return _retailerOpeningHours;
	}
	@JsonProperty("openinghours")
	public void setOpeningHours(String openingHours){
		this._retailerOpeningHours = openingHours;
	}
	private String _retailerOpeningHours;
	
	@Override
	public String toString() {
		StringBuilder result = new StringBuilder();
		String space = " ";
		
		result.append(this.getId() + space);
		result.append(this.getLatitude() + space);
		result.append(this.getLongitude() + space);
		result.append(this.getCompanyName() + space);
		result.append(this.getDescription() + space);
		result.append(this.getOpeningHours() + space);

		return result.toString();	
	}
}
