using TripServiceKata.Trips;

namespace TripServiceKata.Users;

public class User
{
    private List<Trip> trips = new();
    private List<User> friends = new();

    public List<User> GetFriends()
    {
        return friends;
    }

    public void AddFriend(User user)
    {
        friends.Add(user);
    }

    public void AddTrip(Trip trip)
    {
        trips.Add(trip);
    }

    public List<Trip> Trips()
    {
        return trips;
    }
}
