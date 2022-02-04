using System.Collections.Generic;
using System.Linq;
using TripServiceKata.Trips;
using TripServiceKata.Users;

namespace TripServiceKata.UnitTests;

public class UserBuilder
{
    private List<User> _friends = new();
    private List<Trip> _trips = new();

    public UserBuilder WithFriends(params User[] friends)
    {
        this._friends = friends.ToList();
        return this;
    }

    public UserBuilder WithTrips(params Trip[] trips)
    {
        this._trips = trips.ToList();
        return this;
    }

    public User Build()
    {
        User user = new();

        this.AddTrips(user);
        this.AddFriends(user);

        return user;
    }

    private void AddFriends(User user)
    {
        foreach (User friend in this._friends)
        {
            user.AddFriend(friend);
        }
    }

    private void AddTrips(User user)
    {
        foreach (Trip trip in this._trips)
        {
            user.AddTrip(trip);
        }
    }

    public static UserBuilder AUser() =>
        new();

    public static implicit operator User(UserBuilder builder) =>
        builder.Build();
}
