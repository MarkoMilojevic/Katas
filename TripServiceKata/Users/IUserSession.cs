namespace TripServiceKata.Users;

public interface IUserSession
{
    bool IsUserLoggedIn(User user);

    User? GetLoggedInUser();
}
