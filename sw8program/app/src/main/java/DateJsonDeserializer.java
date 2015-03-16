import java.io.IOException;
import java.util.Date;

import com.fasterxml.jackson.core.JsonParser;
import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.DeserializationContext;
import com.fasterxml.jackson.databind.JsonDeserializer;


public class DateJsonDeserializer extends JsonDeserializer<Date>{

	@Override
	public Date deserialize(JsonParser jp, DeserializationContext ctx) throws IOException, JsonProcessingException {
		
		//Isolate the conceiled Long in the DateTime from C#.
		String s = jp.getText();
		String[] out = s.split("\\(");
		out = out[1].split("\\+");
		
		//Use it as time since epoch
		Date d = new Date();
		d.setTime(Long.parseLong(out[0]));
		return d;
	}

}
