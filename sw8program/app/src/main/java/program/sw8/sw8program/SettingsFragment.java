package program.sw8.sw8program;

import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.text.Editable;
import android.text.InputFilter;
import android.text.Spanned;
import android.text.TextWatcher;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.EditText;

public class SettingsFragment extends Fragment {
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        ViewGroup rootView = (ViewGroup) inflater.inflate(R.layout.fragment_settings, container, false);

        EditText amountOfRecommendationsEditable = (EditText) rootView.findViewById(R.id.number_of_recommendations_editable);
        EditText maxStoreRadiusEditable = (EditText) rootView.findViewById(R.id.setting_store_radius);
        Button logOutButton = (Button) rootView.findViewById(R.id.button_log_out);

        amountOfRecommendationsEditable.setFilters(new InputFilter[]{ new InputFilterMinMax("1", "10")});
        maxStoreRadiusEditable.setFilters(new InputFilter[]{new InputFilterMinMax("1", "30")});


        SharedPreferences session = getActivity().getSharedPreferences(getActivity().getString(R.string.app_name), 0);
        SharedPreferences preferences = getActivity().getSharedPreferences(getActivity().getString(R.string.app_name) + session.getInt("id", -1), 0);

        amountOfRecommendationsEditable.setText(String.valueOf(preferences.getInt("numberOfRecommendations", 5)));
        maxStoreRadiusEditable.setText(String.valueOf(preferences.getInt("radius", 10)));

        amountOfRecommendationsEditable.addTextChangedListener(onNumberOfRecommendationsChangedWatcher);
        maxStoreRadiusEditable.addTextChangedListener(onStoreRadiusChangedWatcher);

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

    TextWatcher onNumberOfRecommendationsChangedWatcher = new TextWatcher() {
        @Override
        public void beforeTextChanged(CharSequence s, int start, int count, int after) {

        }

        @Override
        public void onTextChanged(CharSequence s, int start, int before, int count) {

        }

        @Override
        public void afterTextChanged(Editable s) {
            if (!s.toString().isEmpty()) {
                SharedPreferences session = getActivity().getSharedPreferences(getActivity().getString(R.string.app_name), 0);
                SharedPreferences preferences = getActivity().getSharedPreferences(getActivity().getString(R.string.app_name) + session.getInt("id", -1), 0);
                SharedPreferences.Editor editor = preferences.edit();
                editor.putInt("numberOfRecommendations", Integer.parseInt(s.toString()));
                editor.apply();
            }
        }
    };

    TextWatcher onStoreRadiusChangedWatcher = new TextWatcher() {
        @Override
        public void beforeTextChanged(CharSequence s, int start, int count, int after) {

        }

        @Override
        public void onTextChanged(CharSequence s, int start, int before, int count) {

        }

        @Override
        public void afterTextChanged(Editable s) {
            if(!s.toString().isEmpty()) {
                SharedPreferences session = getActivity().getSharedPreferences(getActivity().getString(R.string.app_name), 0);
                SharedPreferences preferences = getActivity().getSharedPreferences(getActivity().getString(R.string.app_name) + session.getInt("id", -1), 0);
                SharedPreferences.Editor editor = preferences.edit();
                editor.putInt("radius", Integer.parseInt(s.toString()));
                editor.apply();
            }
        }
    };

    public class InputFilterMinMax implements InputFilter {

        private int min;
        private int max;

        public InputFilterMinMax(int min, int max) {
            this.min = min;
            this.max = max;
        }

        public InputFilterMinMax(String min, String max) {
            this.min = Integer.parseInt(min);
            this.max = Integer.parseInt(max);
        }

        @Override
        public CharSequence filter(CharSequence source, int start, int end, Spanned dest, int dstart, int dend) {
            try {
                int input = Integer.parseInt(dest.toString() + source.toString());
                if (isInRange(min, max, input))
                    return null;
            } catch (NumberFormatException nfe) {
                nfe.printStackTrace();
            }
            return "";
        }

        private boolean isInRange(int a, int b, int c) {
            return b > a ? c >= a && c <= b : c >= b && c <= a;
        }
    }
}