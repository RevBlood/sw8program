package program.sw8.sw8program;

import android.animation.Animator;
import android.animation.AnimatorListenerAdapter;
import android.app.Activity;
import android.app.LoaderManager.LoaderCallbacks;
import android.content.CursorLoader;
import android.content.Intent;
import android.content.Loader;
import android.content.SharedPreferences;
import android.database.Cursor;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.net.Uri;
import android.os.AsyncTask;

import android.os.Bundle;
import android.provider.ContactsContract;
import android.text.TextUtils;
import android.util.Base64;
import android.view.KeyEvent;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.inputmethod.EditorInfo;
import android.widget.ArrayAdapter;
import android.widget.AutoCompleteTextView;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

import java.io.ByteArrayOutputStream;
import java.util.ArrayList;
import java.util.List;

import Models.Account;
import Helpers.ServiceHelper;

public class LoginActivity extends Activity implements LoaderCallbacks<Cursor> {
    private UserLoginTask AuthTask = null;
    private AutoCompleteTextView EmailView;
    private EditText PasswordView;
    private View ProgressView;
    private View LoginFormView;
    private Account UserAccount;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);

        if(getString(R.string.debug).equals("off")) {
            // Check if a session is available for reload
            SharedPreferences session = getApplicationContext().getSharedPreferences(getString(R.string.app_name), 0);
            if (session.contains("alias")) {
                Intent intent = new Intent(LoginActivity.this, PagerActivity.class);
                startActivity(intent);
                finish();
            }
        }

        EmailView = (AutoCompleteTextView) findViewById(R.id.email);
        PasswordView = (EditText) findViewById(R.id.password);
        LoginFormView = findViewById(R.id.login_form);
        ProgressView = findViewById(R.id.login_progress);
        Button EmailSignInButton = (Button) findViewById(R.id.email_sign_in_button);
        TextView SignUpLinkView = (TextView) findViewById(R.id.link_sign_up);

        PasswordView.setOnEditorActionListener(onKeyboardActionListener);
        EmailSignInButton.setOnClickListener(signInListener);
        SignUpLinkView.setOnClickListener(signUpListener);

        //Auto-complete email if possible
        getLoaderManager().initLoader(0, null, this);
    }

    //Check if field contents are valid; Then try to sign in
    public void attemptLogin() {
        // If login is in progress, don't try on top of that
        if (AuthTask != null) {
            return;
        }

        // Reset errors from earlier attempts
        EmailView.setError(null);
        PasswordView.setError(null);

        // Store values at the time of the login attempt
        String email = EmailView.getText().toString();
        String password = PasswordView.getText().toString();

        boolean cancel = false;
        View focusView = null;

        // Check for a valid email address.
        if (TextUtils.isEmpty(email)) {
            EmailView.setError(getString(R.string.error_field_required));
            focusView = EmailView;
            cancel = true;
        } else if (!isEmailValid(email)) {
            EmailView.setError(getString(R.string.error_invalid_email));
            focusView = EmailView;
            cancel = true;
        }

        // Check for a valid password
        if (TextUtils.isEmpty(password)) {
            PasswordView.setError(getString(R.string.error_field_required));
            focusView = PasswordView;
            cancel = true;
        } else if (!isPasswordValid(password)) {
            PasswordView.setError(getString(R.string.error_invalid_password));
            focusView = PasswordView;
            cancel = true;
        }

        if (cancel) {
            // There was an error; don't attempt login and focus the first form field with an error.
            focusView.requestFocus();
        } else {
            // Show a progress spinner, and kick off a background task to perform the user login attempt.
            showProgress(true);
            AuthTask = new UserLoginTask(this, email, password);
            AuthTask.execute((Void) null);
        }
    }

    private boolean isEmailValid(String email) {
        return email.contains("@");
    }

    private boolean isPasswordValid(String password) {
        return password.length() >= 6;
    }

    //Shows the progress UI and hides the login form.
    public void showProgress(final boolean show) {

        //fade in the progress spinner.
        int shortAnimTime = getResources().getInteger(android.R.integer.config_shortAnimTime);

        LoginFormView.setVisibility(show ? View.GONE : View.VISIBLE);
        LoginFormView.animate().setDuration(shortAnimTime).alpha(show ? 0 : 1).setListener(new AnimatorListenerAdapter() {
            @Override
            public void onAnimationEnd(Animator animation) {
                LoginFormView.setVisibility(show ? View.GONE : View.VISIBLE);
            }
        });

        ProgressView.setVisibility(show ? View.VISIBLE : View.GONE);
        ProgressView.animate().setDuration(shortAnimTime).alpha(show ? 1 : 0).setListener(new AnimatorListenerAdapter() {
            @Override
            public void onAnimationEnd(Animator animation) {
                ProgressView.setVisibility(show ? View.VISIBLE : View.GONE);
            }
        });
    }

    @Override
    public Loader<Cursor> onCreateLoader(int i, Bundle bundle) {
        return new CursorLoader(this,
                // Retrieve data rows for the device user's 'profile' contact.
                Uri.withAppendedPath(ContactsContract.Profile.CONTENT_URI,
                        ContactsContract.Contacts.Data.CONTENT_DIRECTORY), ProfileQuery.PROJECTION,

                // Select only email addresses.
                ContactsContract.Contacts.Data.MIMETYPE + " = ?", new String[]{ContactsContract.CommonDataKinds.Email.CONTENT_ITEM_TYPE},

                // Show primary email addresses first. Note that there won't be a primary email address if the user hasn't specified one.
                ContactsContract.Contacts.Data.IS_PRIMARY + " DESC");
    }

    @Override
    public void onLoadFinished(Loader<Cursor> cursorLoader, Cursor cursor) {
        List<String> emails = new ArrayList<String>();
        cursor.moveToFirst();
        while (!cursor.isAfterLast()) {
            emails.add(cursor.getString(ProfileQuery.ADDRESS));
            cursor.moveToNext();
        }

        addEmailsToAutoComplete(emails);
    }

    @Override
    public void onLoaderReset(Loader<Cursor> cursorLoader) {
    }

    private interface ProfileQuery {
        String[] PROJECTION = {ContactsContract.CommonDataKinds.Email.ADDRESS, ContactsContract.CommonDataKinds.Email.IS_PRIMARY,};

        int ADDRESS = 0;
        int IS_PRIMARY = 1;
    }

    private void addEmailsToAutoComplete(List<String> emailAddressCollection) {
        //Create adapter to tell the AutoCompleteTextView what to show in its dropdown list.
        ArrayAdapter<String> adapter = new ArrayAdapter<String>(LoginActivity.this, android.R.layout.simple_dropdown_item_1line, emailAddressCollection);
        EmailView.setAdapter(adapter);
    }


    //Represents an asynchronous login/registration task used to authenticate the user
    public class UserLoginTask extends AsyncTask<Void, Void, Boolean> {
        private final String Email;
        private final String Password;
        private final Activity Activity;

        UserLoginTask(Activity activity, String email, String password) {
            Email = email;
            Password = password;
            Activity = activity;
        }

        //Returns true when login is handled, and false if not possible to handle, fx wrong password
        @Override
        protected Boolean doInBackground(Void... params) {
            // TODO: Remove Debug
            if (getString(R.string.debug).equals("on")) {
                try {
                    // Simulate network access.
                    Thread.sleep(2000);
                    UserAccount = new Account(Email, Password, "hardcoded alias", "settings", "preferences");
                    return true;
                } catch (InterruptedException e) {
                    return false;
                }

            } else {
                //  If UserAccount is not null, then login was success - Return true
                UserAccount = ServiceHelper.Login(Email, Password);
                if (UserAccount != null) {
                    return true;
                } else {
                    // Wrong username/password combination - Return false
                    return false;
                }
            }
        }

        @Override
        protected void onPostExecute(final Boolean success) {
            AuthTask = null;
            showProgress(false);

            if (success) {
                SharedPreferences session = getApplicationContext().getSharedPreferences(getString(R.string.app_name), 0);
                SharedPreferences.Editor editor = session.edit();
                editor.putString("alias", UserAccount.getAlias());
                editor.putString("email", UserAccount.getEmail());
                editor.putString("password", UserAccount.getPassword());
                editor.putString("preferences", UserAccount.getPreferences());
                editor.putString("settings", UserAccount.getSettings());
                editor.putInt("id", UserAccount.getId());
                editor.apply();

                Intent intent = new Intent(Activity, PagerActivity.class);
                startActivity(intent);
                finish();
            } else {
                EmailView.setError(getString(R.string.error_bad_account));
                EmailView.requestFocus();
            }
        }

        @Override
        protected void onCancelled() {
            AuthTask = null;
            showProgress(false);
        }
    }

    TextView.OnEditorActionListener onKeyboardActionListener = new TextView.OnEditorActionListener() {
        @Override
        public boolean onEditorAction(TextView textView, int id, KeyEvent keyEvent) {
            if (id == R.id.login || id == EditorInfo.IME_NULL) {
                attemptLogin();
                return true;
            }
            return false;
        }
    };

    OnClickListener signInListener = new OnClickListener() {
        @Override
        public void onClick(View v) {
            attemptLogin();
        }
    };

    OnClickListener signUpListener = new OnClickListener() {
        @Override
        public void onClick(View v) {
            Intent intent = new Intent(LoginActivity.this, SignUpActivity.class);
            startActivity(intent);
            finish();
        }
    };

    private String bitmapToBase64(Bitmap image) {
        ByteArrayOutputStream byteArrayOutputStream = new ByteArrayOutputStream();
        image.compress(Bitmap.CompressFormat.PNG, 100, byteArrayOutputStream);
        byte[] byteArray = byteArrayOutputStream .toByteArray();
        return Base64.encodeToString(byteArray, Base64.DEFAULT);
    }

    private Bitmap base64ToBitmap(String base64) {
        byte[] byteArray = Base64.decode(base64, Base64.DEFAULT);
        return BitmapFactory.decodeByteArray(byteArray, 0, byteArray.length);
    }
}



