package program.sw8.sw8program;

import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.TextView;

public class RecommendationEndFragment extends Fragment {

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        ViewGroup rootView = (ViewGroup) inflater.inflate(R.layout.fragment_recommendation_end, container, false);

        Button returnButton = (Button) rootView.findViewById(R.id.button_recommendation_finish);
        returnButton.setOnClickListener(onReturnClickListener);

        return rootView;
    }

    Button.OnClickListener onReturnClickListener = new Button.OnClickListener() {
        @Override
        public void onClick(View v) {
            getActivity().finish();
        }
    };
}