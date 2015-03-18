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
import android.net.Uri;
import android.os.AsyncTask;

import android.os.Bundle;
import android.provider.ContactsContract;
import android.text.TextUtils;
import android.view.KeyEvent;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.inputmethod.EditorInfo;
import android.widget.ArrayAdapter;
import android.widget.AutoCompleteTextView;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;

import java.util.ArrayList;
import java.util.List;

import Helpers.ServiceHelper;
import Models.Account;

public class SignUpActivity extends Activity implements LoaderCallbacks<Cursor> {
    private UserSignUpTask AuthTask = null;
    private AutoCompleteTextView EmailView;
    private EditText AliasView;
    private EditText PasswordView;
    private EditText ConfirmPasswordView;
    private View ProgressView;
    private View LoginFormView;
    Account UserAccount;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_sign_up);

        // Set up the signup form.
        EmailView = (AutoCompleteTextView) findViewById(R.id.email);
        AliasView = (EditText) findViewById(R.id.alias);
        PasswordView = (EditText) findViewById(R.id.password);
        ConfirmPasswordView = (EditText) findViewById(R.id.password_confirmation);
        LoginFormView = findViewById(R.id.sign_up_layout);
        ProgressView = findViewById(R.id.sign_up_progress);
        Button SignUpButton = (Button) findViewById(R.id.email_sign_up_button);

        PasswordView.setOnEditorActionListener(onKeyboardActionListener);
        SignUpButton.setOnClickListener(signUpListener);

        //Auto-complete email if possible
        getLoaderManager().initLoader(0, null, this);
    }

    //Check if there are errors in the form. Otherwise attempt to sign up
    public void attemptSignUp() {
        // If login in progress, don't try on top of that
        if (AuthTask != null) {
            return;
        }

        // Reset errors from earlier attempts
        EmailView.setError(null);
        AliasView.setError(null);
        PasswordView.setError(null);
        ConfirmPasswordView.setError(null);

        // Store values at the time of the login attempt
        String email = EmailView.getText().toString();
        String alias = AliasView.getText().toString();
        String password = PasswordView.getText().toString();
        String passwordConfirmation = ConfirmPasswordView.getText().toString();

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

        // Check for a valid alias
        if (!isAliasValid(alias)) {
            AliasView.setError(getString(R.string.error_field_required));
            focusView = AliasView;
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

        // Check that passwords match
        if (!TextUtils.equals(password, passwordConfirmation)) {
            ConfirmPasswordView.setError(getString(R.string.error_password_mismatch));
            focusView = ConfirmPasswordView;
            cancel = true;
        }

        if (cancel) {
            // There was an error; don't attempt login and focus the first form field with an error.
            focusView.requestFocus();
        } else {
            // Show a progress spinner, and kick off a background task to perform the user login attempt.
            showProgress(true);
            AuthTask = new UserSignUpTask(this, email, alias, password);
            AuthTask.execute((Void) null);
        }
    }

    private boolean isEmailValid(String email) {
        return email.contains("@");
    }

    private boolean isAliasValid(String alias) {
        return !TextUtils.isEmpty(alias);
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
        ArrayAdapter<String> adapter = new ArrayAdapter<String>(SignUpActivity.this, android.R.layout.simple_dropdown_item_1line, emailAddressCollection);
        EmailView.setAdapter(adapter);
    }

    //Represents an asynchronous login/registration task used to authenticate the user
    public class UserSignUpTask extends AsyncTask<Void, Void, Boolean> {
        private final String Email;
        private final String Alias;
        private final String Password;
        private final Activity Activity;

        UserSignUpTask(Activity activity, String email, String alias, String password) {
            Email = email;
            Alias = alias;
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
                    UserAccount = new Account(Alias, Password, Email, "settings", "preferences");
                    return true;
                } catch (InterruptedException e) {
                    return false;
                }
            } else {
                // Try to create the account - returns true or false
                return ServiceHelper.PutAccount(new Account(Email, Password, Alias, "settings", "preferences"));
            }
        }

        @Override
        protected void onPostExecute(final Boolean success) {
            AuthTask = null;
            showProgress(false);

            if (success) {
                UserAccount = ServiceHelper.GetAccountByEmail(Email);

                if (UserAccount == null) {
                    throw new Error("Failed retrieving account");
                }

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
                EmailView.setError(getString(R.string.error_email_taken));
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
                attemptSignUp();
                return true;
            }
            return false;
        }
    };

    OnClickListener signUpListener = new OnClickListener() {
        @Override
        public void onClick(View v) {
            attemptSignUp();
        }
    };
}