package Models;

import java.math.BigDecimal;

public class Ingredient {
	public Ingredient(){}
	
	public Ingredient(int ingredientId, String ingredientName, String ingredientMeasurementType, String ingredientMeasure, 
			BigDecimal ingredientPrice, String ingredientTags) {
		this.setId(ingredientId);
		this.setName(ingredientName);
		this.setMeasurementType(ingredientMeasurementType);
		this.setMeasure(ingredientMeasure);
		this.setPrice(ingredientPrice);
		this.setTags(ingredientTags);
	}
	
	//Ingredient Id
	public int getId(){
		return _ingredientId;
	}
	public void setId(int id){
		this._ingredientId = id;
	}
	private int _ingredientId;
	
	//Ingredient Name
	public String getName() {
		return _ingredientName;
	}
	public void setName(String name){
		this._ingredientName = name;
	}
	private String _ingredientName;
	
	//Ingredient MeasurementType
	public String getMeasurementType() {
		return _ingredientMeasurementType;
	}
	public void setMeasurementType(String measurementType) {
		this._ingredientMeasurementType = measurementType;
	}
	private String _ingredientMeasurementType;
	
	//Ingredient Measure
	public String getMeasure(){
		return _ingredientMeasure;
	}
	public void setMeasure(String measure){
		this._ingredientMeasure = measure;
	}
	private String _ingredientMeasure;
	
	//Ingredient Price
	public BigDecimal getPrice(){
		return _ingredientPrice;
	}
	public void setPrice(BigDecimal price){
		this._ingredientPrice = price;
	}
	private BigDecimal _ingredientPrice;
	
	//Ingredient Tags
	public String getTags(){
		return _ingredientTags;
	}
	public void setTags(String tags) {
		this._ingredientTags = tags;
	}
	private String _ingredientTags;
}
