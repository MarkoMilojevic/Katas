using TripServiceKata.Exceptions;

namespace TripServiceKata.Users;

public class UserSession : IUserSession
{
    public static readonly UserSession Instance = new();

    private UserSession()
    {
    }

    public bool IsUserLoggedIn(User user) =>
        throw new DependendClassCallDuringUnitTestException(
            "UserSession.IsUserLoggedIn() should not be called in an unit test");

    public User GetLoggedInUser() =>
        throw new DependendClassCallDuringUnitTestException(
            "UserSession.GetLoggedUser() should not be called in an unit test");
}
