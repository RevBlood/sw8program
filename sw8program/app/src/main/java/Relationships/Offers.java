package Relationships;

import java.util.Date;
import java.math.BigDecimal;

public class Offers {
	public Offers(){}
	
	public Offers(int offersRetailerId, int offersIngredientId, Date offersOfferFrom, Date offersOfferTo, BigDecimal offersNormalPrice, 
			BigDecimal offersOnSalePrice, BigDecimal offersKrSaving, BigDecimal offersPercentageSavingRetailer,
			BigDecimal offersPecentageSavingGeneral){
		this.setRetailerId(offersRetailerId);
		this.setIngredientId(offersIngredientId);
		this.setOfferFrom(offersOfferFrom);
		this.setOfferTo(offersOfferTo);
		this.setNormalPrice(offersNormalPrice);
		this.setOnSalePrice(offersOnSalePrice);
		this.setKrSaving(offersKrSaving);
		this.setPercentageSavingRetailer(offersPercentageSavingRetailer);
		this.setPercentageSavingGeneral(offersPecentageSavingGeneral);
	}

	//Offers RetailerId
	public int getRetailerId(){
		return _offersRetailerId;
	}
	public void setRetailerId(int id){
		this._offersRetailerId = id;
	}
	private int _offersRetailerId;
	
	//Offers IngredientId
	public int getIngredientId(){
		return _offersIngredientId;
	}
	public void setIngredientId(int id){
		this._offersIngredientId = id;
	}
	private int _offersIngredientId;
	
	//Offers OfferFrom
	public Date getOfferFrom(){
		return _offersOfferFrom;
	}
	public void setOfferFrom(Date offerFrom){
		this._offersOfferFrom = offerFrom;
	}
	private Date _offersOfferFrom;
	
	//Offers OfferTo
	public Date getOfferTo(){
		return _offersOfferTo;
	}
	public void setOfferTo(Date offerTo){
		this._offersOfferTo = offerTo;
	}
	private Date _offersOfferTo;
	
	//Offers NormalPrice
	public BigDecimal getNormalPrice(){
		return _offersNormalPrice;
	}
	public void setNormalPrice(BigDecimal normalPrice){
		this._offersNormalPrice = normalPrice;
	}
	private BigDecimal _offersNormalPrice;
	
	//Offers OnSalePrice
	public BigDecimal getOnSalePrice(){
		return _offersOnSalePrice;
	}
	public void setOnSalePrice(BigDecimal onSalePrice){
		this._offersOnSalePrice = onSalePrice;
	}
	private BigDecimal _offersOnSalePrice;
	
	//Offers KrSaving
	public BigDecimal getKrSaving(){
		return _offersKrSaving;
	}
	public void setKrSaving(BigDecimal krSaving){
		this._offersKrSaving = krSaving;
	}
	private BigDecimal _offersKrSaving;
	
	//Offers PercentageSavingRetailer
	public BigDecimal getPercentageSavingRetailer(){
		return _offersPercentageSavingRetailer;
	}
	public void setPercentageSavingRetailer(BigDecimal percentageSavingRetailer) {
		this._offersPercentageSavingRetailer = percentageSavingRetailer;
	}
	private BigDecimal _offersPercentageSavingRetailer;
	
	//Offers PercentageSavingStore
	public BigDecimal getPercentageSavingGeneral(){
		return _offersPercentageSavingGeneral;
	}
	public void setPercentageSavingGeneral(BigDecimal percentageSavingGeneral) {
		this._offersPercentageSavingGeneral = percentageSavingGeneral;
	}
	private BigDecimal _offersPercentageSavingGeneral;
	
}
