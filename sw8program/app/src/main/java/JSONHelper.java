import Models.*;

import com.fasterxml.jackson.core.JsonGenerationException;
import com.fasterxml.jackson.core.JsonParseException;
import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.JsonMappingException;
import com.fasterxml.jackson.databind.ObjectMapper;


public class JSONHelper<T> {
	
	public static <T> T Deserialize(String json, Class<T> targetClass) {
		ObjectMapper objM = new ObjectMapper();
		T jsonObj = null;
		try {
			jsonObj = objM.readValue(json, targetClass);
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
			e.printStackTrace();
		}
		return resultString;
	}

}
