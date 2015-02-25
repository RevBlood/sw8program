package program.sw8.sw8program;

import android.app.Activity;
import android.content.Intent;
import android.database.Cursor;
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
                //TODO: Test on pre-KitKat phone
                Uri uri = data.getData();
                String pathsegment[] = uri.getLastPathSegment().split(":");
                String id = pathsegment[1];
                String[] imageColumns = {MediaStore.Images.Media.DATA};
                uri = getUri();
                Cursor imageCursor = getActivity().getContentResolver().query(uri, imageColumns, MediaStore.Images.Media._ID + "=" + id, null, null);

                if (imageCursor.moveToFirst()) {
                    uri = uri.parse(imageCursor.getString(imageCursor.getColumnIndex(MediaStore.Images.Media.DATA)));
                }
                //Finally set the image based on the URI we derived
                UserImage.setImageURI(uri);
                break;
        }
    }

    //Figure out where to look for images (Internal/External storage)
    private Uri getUri() {
        String state = Environment.getExternalStorageState();
        if (state.equalsIgnoreCase(Environment.MEDIA_MOUNTED)) {
            return MediaStore.Images.Media.EXTERNAL_CONTENT_URI;
        } else {
            return MediaStore.Images.Media.INTERNAL_CONTENT_URI;
        }
    }
}