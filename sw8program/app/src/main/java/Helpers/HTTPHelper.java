package Helpers;

import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;
import java.io.BufferedReader;
import java.io.DataOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.io.OutputStreamWriter;

public class HTTPHelper {
	private final static String USER_AGENT = "sw8Client";
	
	public static String HTTPGet(String url) throws Exception {
		URL obj = new URL(url);
		HttpURLConnection con = (HttpURLConnection) obj.openConnection();
 
		// optional default is GET
		con.setRequestMethod("GET");
 
		//add request header
		con.setRequestProperty("User-Agent", USER_AGENT);
 
		int responseCode = con.getResponseCode();
		System.out.println("\nSending 'GET' request to URL : " + url);
		System.out.println("Response Code : " + responseCode);
 
		BufferedReader in = new BufferedReader(
		        new InputStreamReader(con.getInputStream()));
		String inputLine;
		StringBuffer response = new StringBuffer();
 
		while ((inputLine = in.readLine()) != null) {
			response.append(inputLine);
		}
		in.close();

		return response.toString(); 
	}
	
	public static String HTTPPut(String targetUrl, String jsonInput) throws IOException {
		String output = "";
			System.out.println("Starting url connection");
			URL url = new URL(targetUrl);
			HttpURLConnection conn = (HttpURLConnection) url.openConnection();
			conn.setDoOutput(true);
			conn.setRequestMethod("PUT");
			conn.setRequestProperty("Content-Type", "application/json; charset=utf-8");
	 
			OutputStream os = conn.getOutputStream();
			os.write(jsonInput.getBytes());
			os.flush();
			if (conn.getResponseCode() != HttpURLConnection.HTTP_CREATED) {
				if(conn.getResponseCode() != 200) {
					throw new RuntimeException("Failed : HTTP error code: "
						+ conn.getResponseCode() + ". HTTP error message: " + conn.getResponseMessage());
				}
			}
			BufferedReader br = new BufferedReader(new InputStreamReader(
					(conn.getInputStream())));
	 
			System.out.println("Output from Server .... \n");
			while ((output = br.readLine()) != null) {
				System.out.println(conn.getResponseMessage());
				System.out.println(output);
			}
	 
			conn.disconnect();
		
		return output;
	}
}
