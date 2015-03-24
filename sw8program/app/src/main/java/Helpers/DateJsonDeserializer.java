package Helpers;

import java.io.IOException;
import java.util.Date;

import com.fasterxml.jackson.core.JsonParser;
import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.DeserializationContext;
import com.fasterxml.jackson.databind.JsonDeserializer;


public class DateJsonDeserializer extends JsonDeserializer<Date>{

	@Override
	public Date deserialize(JsonParser jp, DeserializationContext ctx) throws IOException, JsonProcessingException {
		Date d = new Date();
		String[] out = null;
		if(jp.getText().contains("/")){
		//Isolate the conceiled Long in the DateTime from C#.
		String s = jp.getText();
		out = s.split("\\(");
		out = out[1].split("\\+");
		} else {
			d.setTime(Long.parseLong(jp.getText()));
			return d;
		}
		
		//Use it as time since epoch
		
		d.setTime(Long.parseLong(out[0]));
		return d;
	}

}
