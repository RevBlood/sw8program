package program.sw8.sw8program;

import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;

public class SettingsFragment extends Fragment {
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        ViewGroup rootView = (ViewGroup) inflater.inflate(R.layout.fragment_settings, container, false);

        Button logOutButton = (Button) rootView.findViewById(R.id.button_log_out);
        logOutButton.setOnClickListener(logOutListener);

        return rootView;
    }

    Button.OnClickListener logOutListener = new Button.OnClickListener() {
        @Override
        public void onClick(View v) {
            SharedPreferences session = getActivity().getApplicationContext().getSharedPreferences(getString(R.string.app_name), 0);
            SharedPreferences.Editor editor = session.edit();
            editor.clear();
            editor.apply();

            Intent intent = new Intent(getActivity(), LoginActivity.class);
            startActivity(intent);
            getActivity().finish();
        }
    };
}