package program.sw8.sw8program;

/**
 * Created by Morten on 23-02-2015.
 */
public class User {

    private int UserId;
    private int UserImageId = 0;
    private String Username;

    public User(int userId, String username, int userImageId) {
        UserId = userId;
        Username = username;
        UserImageId = userImageId;
    }

    public User(int userId, String username) {
        UserId = userId;
        Username = username;
    }

    public int getUserImageId() {
        return UserImageId;
    }

    public String getUsername() {
        return Username;
    }

    public void setUserImageId(int userImageId) {
        UserImageId = userImageId;
    }
}
