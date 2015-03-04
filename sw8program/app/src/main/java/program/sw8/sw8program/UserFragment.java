package program.sw8.sw8program;

import android.app.Activity;
import android.content.Intent;
import android.database.Cursor;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.net.Uri;
import android.os.Bundle;
import android.os.Environment;
import android.provider.MediaStore;
import android.support.v4.app.Fragment;
import android.view.ContextMenu;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ImageView;
import android.widget.TextView;

public class UserFragment extends Fragment {
    private final int ContextUserImageRemove = 1;
    private final int ContextUserImageChange = 2;
    private final int SelectImage = 1;
    private User Profile;
    private ImageView UserImage;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        ViewGroup rootView = (ViewGroup) inflater.inflate(R.layout.fragment_user, container, false);

        UserImage = (ImageView) rootView.findViewById(R.id.user_image);
        TextView userName = (TextView) rootView.findViewById(R.id.user_name);
        registerForContextMenu(UserImage);

        //TODO: Remove testdata
        Profile = new User(0, "Carsten Holst");

        if (Profile.getUserImageId() != 0) {
            UserImage.setImageResource(Profile.getUserImageId());
        }
        userName.setText(Profile.getUsername());

        return rootView;
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
                Profile.setUserImageId(0);
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