package program.sw8.sw8program;

import java.util.List;
import java.util.Map;
import android.app.Activity;
import android.content.Context;
import android.graphics.Typeface;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseExpandableListAdapter;
import android.widget.SeekBar;
import android.widget.TextView;


public class ExpandableListAdapter extends BaseExpandableListAdapter {

    private Activity context;
    private Map<String, List<String>> childNodes;
    private List<String> parentNodes;

    private SeekBar priceSeekbar;
    private SeekBar magicSeekbar;

    private int pricepercent;
    private int magicpercent;

    private TextView priceSeekvalue;
    private TextView magicSeekvalue;

    public ExpandableListAdapter(Activity context, List<String> parentNodes,
                                 Map<String, List<String>> childNodes) {
        this.context = context;
        this.childNodes = childNodes;
        this.parentNodes = parentNodes;
    }

    public Object getChild(int groupPosition, int childPosition) {
        return childNodes.get(parentNodes.get(groupPosition)).get(childPosition);
    }

    public long getChildId(int groupPosition, int childPosition) {
        return childPosition;
    }


    public View getChildView(final int groupPosition, final int childPosition,
                             boolean isLastChild, View convertView, ViewGroup parent) {

        LayoutInflater inflater = context.getLayoutInflater();

        Log.e(Integer.toString(groupPosition),"yep");

        if (groupPosition == 0) {

                convertView = inflater.inflate(R.layout.explist_personal, null);

        }else if (groupPosition == 1) {

            convertView = inflater.inflate(R.layout.explist_preferences, null);

            priceSeekbar = (SeekBar) convertView.findViewById(R.id.price_seekbar);
            magicSeekbar = (SeekBar) convertView.findViewById(R.id.magic_seekbar);

            priceSeekvalue = (TextView) convertView.findViewById(R.id.price_int);
            magicSeekvalue = (TextView) convertView.findViewById(R.id.magic_int);

            priceSeekbar.setOnSeekBarChangeListener(new SeekBar.OnSeekBarChangeListener() {
                @Override
                public void onProgressChanged(SeekBar seekBar, int i, boolean b) {
                    pricepercent = i;
                    priceSeekvalue.setText(String.valueOf(i));
                }

                @Override
                public void onStartTrackingTouch(SeekBar seekBar) {
                    // Auto-generated onStartTracking method
                }

                @Override
                public void onStopTrackingTouch(SeekBar seekBar) {
                    // Auto-generated onStopTracking method
                }
            });
            magicSeekbar.setOnSeekBarChangeListener(new SeekBar.OnSeekBarChangeListener() {
                @Override
                public void onProgressChanged(SeekBar seekBar, int i, boolean b) {
                    magicpercent = i;
                    magicSeekvalue.setText(String.valueOf(i));
                }

                @Override
                public void onStartTrackingTouch(SeekBar seekBar) {
                    // Auto-generated onStartTracking method
                }

                @Override
                public void onStopTrackingTouch(SeekBar seekBar) {
                    // Auto-generated onStopTracking method
                }
            });

            priceSeekbar.setProgress(pricepercent);
            magicSeekbar.setProgress(magicpercent);
        }
        return convertView;
    }

    public int getChildrenCount(int groupPosition) {
        return childNodes.get(parentNodes.get(groupPosition)).size();
    }

    public Object getGroup(int groupPosition) {
        return parentNodes.get(groupPosition);
    }

    public int getGroupCount() {
        return parentNodes.size();
    }

    public long getGroupId(int groupPosition) {
        return groupPosition;
    }

    public View getGroupView(int groupPosition, boolean isExpanded,
                             View convertView, ViewGroup parent) {
        String dataheader = (String) getGroup(groupPosition);
        if (convertView == null) {
            LayoutInflater infalInflater = (LayoutInflater) context
                    .getSystemService(Context.LAYOUT_INFLATER_SERVICE);
            convertView = infalInflater.inflate(R.layout.expandable_list_group,
                    null);
        }
        TextView item = (TextView) convertView.findViewById(R.id.parent);
        item.setTypeface(null, Typeface.BOLD);
        item.setText(dataheader);
        return convertView;
    }

    public boolean hasStableIds() {
        return true;
    }

    public boolean isChildSelectable(int groupPosition, int childPosition) {
        return true;
    }
}