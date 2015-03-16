package Helpers;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import Models.*;

import com.fasterxml.jackson.core.JsonGenerationException;
import com.fasterxml.jackson.core.JsonParseException;
import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.core.Version;
import com.fasterxml.jackson.core.type.TypeReference;
import com.fasterxml.jackson.databind.JsonMappingException;
import com.fasterxml.jackson.databind.ObjectMapper;
import com.fasterxml.jackson.databind.deser.std.DateDeserializers;
import com.fasterxml.jackson.databind.module.*;


public class JSONHelper<T> {
	
	public static <T> T Deserialize(String json, Class<T> targetClass) {
		ObjectMapper objM = new ObjectMapper();
		
		SimpleModule testModule = new SimpleModule("DateJsonDeserializerModule", 
				new Version(1,0,0,null));
		testModule.addDeserializer(Date.class,  new DateJsonDeserializer());
		objM.registerModule(testModule);
		
		T jsonObj = null;
		try {
			jsonObj = objM.readValue(json, targetClass);
		} catch (Exception e) {
			e.printStackTrace();
		}
		return jsonObj;
	}
	
	public static <T> ArrayList<T> DeserializeList(String json, Class<T> targetClass) {
		ObjectMapper objM = new ObjectMapper();
		
		SimpleModule testModule = new SimpleModule("DateJsonDeserializerModule", 
				new Version(1,0,0,null));
		testModule.addDeserializer(Date.class,  new DateJsonDeserializer());
		objM.registerModule(testModule);
		
		ArrayList<T> jsonObj = null;
		try {
			jsonObj = objM.readValue(json, objM.getTypeFactory().constructCollectionType(ArrayList.class, targetClass));
		} catch (Exception e) {
			e.printStackTrace();
		}
		return jsonObj;
	}
	
	public static String Serializer(Object obj){
		ObjectMapper mapper = new ObjectMapper();

		String resultString = "";
		try {
			resultString = mapper.writeValueAsString(obj);
		} catch (JsonProcessingException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		return resultString;
	}

}
