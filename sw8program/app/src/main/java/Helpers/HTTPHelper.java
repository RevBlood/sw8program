package Helpers;

import android.os.AsyncTask;

import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.util.concurrent.ExecutionException;

public class HTTPHelper {
    private final static String USER_AGENT = "sw8Client";

    public static String HTTPGet(String url) {
        HTTPGetTask getTask = new HTTPGetTask();
        getTask.executeOnExecutor(AsyncTask.THREAD_POOL_EXECUTOR, url);
        try {
            return getTask.get();
        } catch (InterruptedException e) {
            e.printStackTrace();
            return null;
        } catch (ExecutionException e) {
            e.printStackTrace();
            return null;
        }
    }

    public static String HTTPPost(String targetUrl, String jsonInput) throws IOException {
        String output = "";
        System.out.println("Starting url connection");
        URL url = new URL(targetUrl);
        HttpURLConnection conn = (HttpURLConnection) url.openConnection();
        conn.setDoOutput(true);
        conn.setRequestMethod("POST");
        conn.setRequestProperty("Content-Type", "application/json; charset=utf-8");

        OutputStream os = conn.getOutputStream();
        os.write(jsonInput.getBytes());
        os.flush();
        if (conn.getResponseCode() != HttpURLConnection.HTTP_CREATED) {
            if (conn.getResponseCode() != 200) {
                throw new RuntimeException("Failed : HTTP error code: "
                        + conn.getResponseCode() + ". HTTP error message: " + conn.getResponseMessage());
            }
        }
        BufferedReader br = new BufferedReader(new InputStreamReader(
                (conn.getInputStream())));

        System.out.println("Output from Server:");
        while ((output = br.readLine()) != null) {
            System.out.println(conn.getResponseMessage());
            System.out.println(output);
        }
		System.out.println("End of Output from Server");
		
        conn.disconnect();

        return output;
    }

    public static class HTTPGetTask extends AsyncTask<String, Void, String> {

        @Override
        protected String doInBackground(String... url) {
            try {
                URL obj = new URL(url[0]);
                HttpURLConnection con = (HttpURLConnection) obj.openConnection();

                // optional default is GET
                con.setRequestMethod("GET");

                //add request header
                con.setRequestProperty("User-Agent", USER_AGENT);

                int responseCode = con.getResponseCode();
                System.out.println("Sending 'GET' request to URL : " + obj);
                System.out.println("Response Code : " + responseCode);

                BufferedReader in = new BufferedReader(new InputStreamReader(con.getInputStream()));
                String inputLine;
                StringBuilder response = new StringBuilder();

                while ((inputLine = in.readLine()) != null) {
                    response.append(inputLine);
                }

                in.close();

                return response.toString();

            } catch (MalformedURLException e) {
                e.printStackTrace();
                return null;
            } catch (IOException e) {
                e.printStackTrace();
                return null;
            }
        }

        @Override
        protected void onPostExecute(String result) {

        }
    }
}
