package program.sw8.sw8program;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.LinearLayout;
import android.widget.TextView;

import java.text.ParsePosition;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.List;

import Models.Comment;

/**
 * Created by Morten on 20-02-2015.
 */
public class RecipeCommentAdapter extends ArrayAdapter<Comment> {
    private List<Comment> _RecipeComments;
    private Context _context;
    private int _LayoutId;

    public RecipeCommentAdapter(Context context, int layoutId, List<Comment> comments) {
        super(context, layoutId, comments);

        _RecipeComments = comments;
        _context = context;
        _LayoutId = layoutId;
    }

    @Override
    public int getCount() {
        return _RecipeComments.size();
    }

    @Override
    public View getView(int position, View view, ViewGroup parent) {
        //Find relevant elements from the layout
        LayoutInflater inflater = (LayoutInflater) _context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        View row = inflater.inflate(_LayoutId, parent, false);

        TextView nameView = (TextView) row.findViewById(R.id.commenters_name);
        TextView timeView = (TextView) row.findViewById(R.id.time_of_comment);
        TextView commentView = (TextView) row.findViewById(R.id.comment_text);

        nameView.setText("name");
        timeView.setText(_RecipeComments.get(position).getCreationDate().toString());
        commentView.setText(_RecipeComments.get(position).getText());

        return row;
    }
}