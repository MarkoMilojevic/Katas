using System.Collections.Generic;
using System.Linq;
using TripServiceKata.Trips;
using TripServiceKata.Users;

namespace TripServiceKata.UnitTests;

public class UserBuilder
{
    public List<User> Friends { get; set; } = new();
    public List<Trip> Trips { get; set; } = new();

    public UserBuilder WithFriends(params User[] friends)
    {
        this.Friends = friends.ToList();
        return this;
    }

    public UserBuilder WithTrips(params Trip[] trips)
    {
        this.Trips = trips.ToList();
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
        foreach (User friend in this.Friends)
        {
            user.AddFriend(friend);
        }
    }

    private void AddTrips(User user)
    {
        foreach (Trip trip in this.Trips)
        {
            user.AddTrip(trip);
        }
    }
}
