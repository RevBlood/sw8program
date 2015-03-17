package Models;

public class Retailer {
	public Retailer(){}
	
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
	public int getId(){
		return _retailerId;
	}
	public void setId(int id){
		this._retailerId = id;
	}
	private int _retailerId;
	
	//Retailer Latitude
	public String getLatitude(){
		return _retailerLatitude;
	}
	public void setLatitude(String latitude){
		this._retailerLatitude = latitude;
	}
	private String _retailerLatitude;
	
	//Retailer Longitude
	public String getLongitude(){
		return _retailerLongitude;
	}
	public void setLongitude(String longitude){
		this._retailerLongitude = longitude;
	}
	private String _retailerLongitude;
	
	//Retailer CompanyName
	public String getCompanyName(){
		return _retailerCompanyName;
	}
	public void setCompanyName(String companyName){
		this._retailerCompanyName = companyName;
	}
	private String _retailerCompanyName;
	
	//Retailer Description
	public String getDescription(){
		return _retailerDescription;
	}
	public void setDescription(String description){
		this._retailerDescription = description;
	}
	private String _retailerDescription;
	
	//Retailer OpeningHours
	public String getOpeningHours(){
		return _retailerOpeningHours;
	}
	public void setOpeningHours(String openingHours){
		this._retailerOpeningHours = openingHours;
	}
	private String _retailerOpeningHours;
}
