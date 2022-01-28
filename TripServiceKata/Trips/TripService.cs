using TripServiceKata.Exceptions;
using TripServiceKata.Users;

namespace TripServiceKata.Trips;

public class TripService
{
    public List<Trip> GetTripsByUser(User? user)
    {
        List<Trip> tripList = new();
        User? loggedUser = this.GetLoggedInUser();
        bool isFriend = false;

        if (loggedUser != null)
        {
            foreach (User friend in user.GetFriends())
            {
                if (friend.Equals(loggedUser))
                {
                    isFriend = true;
                    break;
                }
            }

            if (isFriend)
            {
                tripList = GetTrips(user);
            }

            return tripList;
        }
        else
        {
            throw new UserNotLoggedInException();
        }
    }

    protected virtual List<Trip> GetTrips(User user) =>
        TripDAO.FindTripsByUser(user);

    protected virtual User? GetLoggedInUser() =>
        UserSession.Instance.GetLoggedUser();
}
