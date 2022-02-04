using TripServiceKata.Trips;

namespace TripServiceKata.Users;

public class User
{
    private readonly List<Trip> _trips = new();
    private readonly List<User> _friends = new();

    public IReadOnlyList<User> GetFriends()
    {
        return _friends;
    }

    public void AddFriend(User user)
    {
        _friends.Add(user);
    }

    public void AddTrip(Trip trip)
    {
        _trips.Add(trip);
    }

    public IReadOnlyList<Trip> Trips()
    {
        return _trips;
    }

    public bool IsFriendsWith(User user)
    {
        return _friends.Contains(user);
    }
}
