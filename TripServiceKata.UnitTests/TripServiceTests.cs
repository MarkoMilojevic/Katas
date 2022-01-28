using System.Collections.Generic;
using TripServiceKata.Exceptions;
using TripServiceKata.Trips;
using TripServiceKata.Users;
using Xunit;

namespace TripServiceKata.UnitTests;

public class TripServiceTests
{
    public TestTripService TripService { get; }
    public User? Guest { get; }
    public User LoggedInUser { get; }
    public User NotFriend { get; }
    public Trip TripToSpain { get; set; }

    public TripServiceTests()
    {
        this.Guest = null;
        this.LoggedInUser = AUser().Build();
        this.NotFriend = AUser().Build();
        this.TripToSpain = new();

        this.TripService = new()
        {
            LoggedInUser = this.Guest,
        };
    }

    [Fact]
    public void GetTripsByUser_Throws_When_UserNotLoggedIn()
    {
        Assert.Throws<UserNotLoggedInException>(
            () => this.TripService.GetTripsByUser(this.NotFriend));
    }

    [Fact]
    public void GetTripsByUser_ReturnsNoTrips_WhenNotFriends()
    {
        this.TripService.LoggedInUser = this.LoggedInUser;

        List<Trip> trips =
            this.TripService.GetTripsByUser(this.NotFriend);

        Assert.Empty(trips);
    }

    [Fact]
    public void GetTripsByUser_ReturnsUserTrips_WhenFriends()
    {
        this.TripService.LoggedInUser = this.LoggedInUser;

        User friend =
            AUser()
                .WithFriends(this.LoggedInUser)
                .WithTrips(this.TripToSpain)
                .Build();

        List<Trip> trips =
            this.TripService.GetTripsByUser(friend);

        Assert.Single(trips);
        Assert.Equal(this.TripToSpain, trips[0]);
    }

    public static UserBuilder AUser() => new();
}

public class TestTripService : TripService
{
    public User? LoggedInUser { get; set; }

    protected override List<Trip> GetTrips(User user) =>
        user.Trips();

    protected override User? GetLoggedInUser() =>
        this.LoggedInUser;
}
