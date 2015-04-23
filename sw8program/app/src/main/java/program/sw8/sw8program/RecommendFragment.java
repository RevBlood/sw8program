package program.sw8.sw8program;

import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.TextView;

public class RecommendFragment extends Fragment {

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        ViewGroup rootView = (ViewGroup) inflater.inflate(R.layout.fragment_recommend, container, false);

        TextView linkToPreferences = (TextView) rootView.findViewById(R.id.link_preferences);
        Button buttonRecommend = (Button) rootView.findViewById(R.id.button_recommend);
        linkToPreferences.setOnClickListener(onLinkClickListener);


        return rootView;
    }

    View.OnClickListener onLinkClickListener = new View.OnClickListener() {
        @Override
        public void onClick(View v) {
            //Change the active page to the profile page
            ((PagerActivity)getActivity()).requestPageChange(0);
        }
    };

    Button.OnClickListener onRecommendClickListener = new Button.OnClickListener() {
        @Override
        public void onClick(View v) {
            //TODO: Get recommendation

        }
    };
}