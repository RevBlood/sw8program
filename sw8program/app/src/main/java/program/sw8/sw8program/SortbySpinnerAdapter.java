package program.sw8.sw8program;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;


public class SortbySpinnerAdapter extends ArrayAdapter<String>{

    private Context _context;
    private String[] _objects;
    private int _layoutId;

        public SortbySpinnerAdapter(Context context, int textViewResourceId, String[] objects) {
            super(context, textViewResourceId, objects);
            this._context = context;
            this._objects = objects;
            this._layoutId = textViewResourceId;
        }

        @Override
        public View getDropDownView(int position, View convertView,ViewGroup parent) {
            return getCustomView(position, convertView, parent);
        }

        @Override
        public View getView(int position, View convertView, ViewGroup parent) {
            return getCustomView(position, convertView, parent);
        }

        public View getCustomView(int position, View convertView, ViewGroup parent) {

            if(convertView == null) {
                LayoutInflater inflater = (LayoutInflater) this._context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
                convertView = inflater.inflate(_layoutId, parent, false);
            }

            TextView label = (TextView)convertView.findViewById(R.id.sort_by_item_value);

            label.setText(this._objects[position]);

            TextView description = (TextView)convertView.findViewById(R.id.sort_by_item_description);

            if(position == 0 | position == 1) {
                description.setText("i Kroner");
            } else if (position == 2) {
                description.setText("i Procent");
            } else {
                description.setText("fra Brugere");
            }

            return convertView;
        }

}
