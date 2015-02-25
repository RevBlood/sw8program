package program.sw8.sw8program;

import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

public class RecommendFragment extends Fragment {
    TextView LinkToPreferences;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        ViewGroup rootView = (ViewGroup) inflater.inflate(R.layout.fragment_recommend, container, false);

        LinkToPreferences = (TextView) rootView.findViewById(R.id.link_preferences);

        LinkToPreferences.setOnClickListener(onLinkClickListener);


        return rootView;
    }

    View.OnClickListener onLinkClickListener = new View.OnClickListener() {
        @Override
        public void onClick(View v) {
            ((PagerActivity)getActivity()).requestPageChange(0);
        }
    };
}