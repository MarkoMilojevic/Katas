using TripServiceKata.Trips;

namespace TripServiceKata.Users;

public class User
{
    private readonly List<Trip> _trips = new();
    private readonly List<User> _friends = new();

    public IReadOnlyList<User> GetFriends() =>
        this._friends;

    public void AddFriend(User user) =>
        this._friends.Add(user);

    public void AddTrip(Trip trip) =>
        this._trips.Add(trip);

    public IReadOnlyList<Trip> Trips() =>
        this._trips;

    public bool IsFriendsWith(User user) =>
        this._friends.Contains(user);
}
