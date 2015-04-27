package program.sw8.sw8program;

import android.app.Activity;
import android.content.Intent;
import android.content.SharedPreferences;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.net.Uri;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.ContextMenu;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ExpandableListView;
import android.widget.ImageView;
import android.widget.TextView;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

import Models.Account;

public class UserFragment extends Fragment {
    private final int ContextUserImageRemove = 1;
    private final int ContextUserImageChange = 2;
    private final int SelectImage = 1;

    private Account Profile;
    private ImageView UserImage;

    private int pricePreference;
    private int savingsPreference;

    ExpandableListPersonal listPersonalAdapter;
    ExpandableListView explistPersonal;
    List<String> listPersonalHeader;
    HashMap<String, List<String[]>> listPersonalChild;

    ExpandableListPreferences listPreferencesAdapter;
    ExpandableListView explistPreferences;
    List<String> listPreferencesHeader;
    HashMap<String, List<String[]>> listPreferencesChild;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        ViewGroup rootView = (ViewGroup) inflater.inflate(R.layout.fragment_user, container, false);

        UserImage = (ImageView) rootView.findViewById(R.id.user_image);
        TextView userName = (TextView) rootView.findViewById(R.id.user_name);
        TextView userEmail = (TextView) rootView.findViewById(R.id.user_email);
        registerForContextMenu(UserImage);

        SharedPreferences session = getActivity().getApplicationContext().getSharedPreferences(getString(R.string.app_name), 0);
        Profile = new Account(
                session.getString("email", null),
                session.getString("password", null),
                session.getString("alias", null),
                session.getString("settings", null),
                session.getString("preferences", null));


        SharedPreferences preferences = getActivity().getApplicationContext().getSharedPreferences("preferences", 0);
        pricePreference = preferences.getInt("price", 50);
        savingsPreference = preferences.getInt("savings", 50);

        if (Profile.hasImage()) {
            UserImage.setImageResource(Profile.getImageId());
        }
        userName.setText(Profile.getAlias());
        userEmail.setText(Profile.getEmail());

        // setting up data and adapter for Personal Information expandable list
        explistPersonal = (ExpandableListView) rootView.findViewById(R.id.explist_personal);
        preparePersonalData();
        listPersonalAdapter = new ExpandableListPersonal(getActivity(), listPersonalHeader, listPersonalChild);
        explistPersonal.setAdapter(listPersonalAdapter);

        // setting up data and adapter for Preferences expandable list
        explistPreferences = (ExpandableListView) rootView.findViewById(R.id.explist_preferences);
        preparePreferencesData();
        listPreferencesAdapter = new ExpandableListPreferences(getActivity(), listPreferencesHeader, listPreferencesChild);
        explistPreferences.setAdapter(listPreferencesAdapter);

        return rootView;
    }

    //Preparing the listdata
    private void preparePersonalData() {
        listPersonalHeader = new ArrayList<String>();
        listPersonalChild = new HashMap<String, List<String[]>>();

        // Adding group data
        listPersonalHeader.add("Personlig Information");

        String[] name = new String[]{Profile.getAlias(),"name"};
        String[] description = new String[]{"The Godfather","description"};

        // Adding child data
        List<String[]> PersonalInformation = new ArrayList<String[]>();
        PersonalInformation.add(0, name);
        PersonalInformation.add(1, description);

        listPersonalChild.put(listPersonalHeader.get(0), PersonalInformation); // Header, Child data
    }

    private void preparePreferencesData() {
        listPreferencesHeader = new ArrayList<String>();
        listPreferencesChild = new HashMap<String, List<String []>>();

        // Adding group data
        listPreferencesHeader.add("Præferencer");

        String[] price = new String[]{Integer.toString(pricePreference),"price"};
        String[] savings = new String[]{Integer.toString(savingsPreference),"savings"};

        // Adding child data
        List<String[]> preferences = new ArrayList<String[]>();
        preferences.add(price);
        preferences.add(savings);

        listPreferencesChild.put(listPreferencesHeader.get(0), preferences); // Header, Child data
    }

    @Override
    public void onCreateContextMenu(ContextMenu menu, View v, ContextMenu.ContextMenuInfo menuInfo) {
        super.onCreateContextMenu(menu, v, menuInfo);
        AdapterView.AdapterContextMenuInfo info = (AdapterView.AdapterContextMenuInfo) menuInfo;

        //Create menu entries to delete or change profile image
        menu.add(Menu.NONE, ContextUserImageChange, Menu.NONE, getString(R.string.user_image_change));
        menu.add(Menu.NONE, ContextUserImageRemove, Menu.NONE, getString(R.string.user_image_remove));
    }

    @Override
    public boolean onContextItemSelected(MenuItem item) {

        //Figure what menu entry was pressed and handle it
        switch (item.getItemId()) {
            case ContextUserImageChange:
                Intent intent = new Intent(Intent.ACTION_GET_CONTENT);
                intent.setType("image/*");
                startActivityForResult(Intent.createChooser(intent, getString(R.string.user_image_choose)), SelectImage);
                return true;
            case ContextUserImageRemove:
                Profile.setImageId(0);
                UserImage.setImageResource(R.drawable.profile);
                return true;
            default:
                return false;
        }
    }

    @Override
    public void onActivityResult(int requestCode, int resultCode, Intent data) {
        if (resultCode != Activity.RESULT_OK) {
            return;
        }

        //Perform actions based on result from whatever activity returned
        switch (requestCode) {
            case SelectImage:
                //If we selected an image from gallery, get the) URI and do some string manipulation because fuck KitKat.
                Uri uri = data.getData();
                //TODO: Target height and width is just random numbers. Figure out something proper.
                UserImage.setImageBitmap(getResizedBitmap(10, 10, ImageFilePath.getPath(getActivity(), uri)));
                break;
        }
    }

    public Bitmap getResizedBitmap(int targetW, int targetH,  String imagePath) {
        // Get the dimensions of the bitmap
        BitmapFactory.Options bmOptions = new BitmapFactory.Options();
        //inJustDecodeBounds = true <-- will not load the bitmap into memory
        bmOptions.inJustDecodeBounds = true;
        BitmapFactory.decodeFile(imagePath, bmOptions);
        int photoW = bmOptions.outWidth;
        int photoH = bmOptions.outHeight;

        // Determine how much to scale down the image
        int scaleFactor = Math.min(photoW/targetW, photoH/targetH);

        // Decode the image file into a Bitmap sized to fill the View
        bmOptions.inJustDecodeBounds = false;
        bmOptions.inSampleSize = 5;
        bmOptions.inPurgeable = true;

        Bitmap bitmap = BitmapFactory.decodeFile(imagePath, bmOptions);
        return(bitmap);
    }
}