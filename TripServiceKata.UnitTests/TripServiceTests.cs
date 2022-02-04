using Moq;
using System.Collections.Generic;
using TripServiceKata.Exceptions;
using TripServiceKata.Trips;
using TripServiceKata.Users;
using Xunit;
using static TripServiceKata.UnitTests.UserBuilder;

namespace TripServiceKata.UnitTests;

public class TripServiceTests
{
    private readonly TripService _tripService;

    private readonly Mock<IUserSession> _userSession;
    private readonly Mock<ITripsRepository> _tripsRepository;

    private readonly User _loggedInUser;
    private readonly User _notFriend;

    public TripServiceTests()
    {
        this._loggedInUser = AUser();
        this._notFriend = AUser();

        this._userSession = new();
        this._userSession
            .Setup(session => session.GetLoggedInUser())
            .Returns<User>(null);
        
        this._tripsRepository = new();
        this._tripsRepository
            .Setup(repo => repo.GetTrips(It.IsAny<User>()))
            .Returns((User user) => user.Trips());

        this._tripService = new(
            this._userSession.Object,
            this._tripsRepository.Object);
    }

    [Fact]
    public void GetTripsByUser_Throws_When_UserNotLoggedIn()
    {
        Assert.Throws<UserNotLoggedInException>(
            () => this._tripService.GetTripsByUser(this._notFriend));
    }

    [Fact]
    public void GetTripsByUser_ReturnsNoTrips_WhenNotFriends()
    {
        this._userSession
            .Setup(session => session.GetLoggedInUser())
            .Returns(this._loggedInUser);

        IReadOnlyList<Trip> trips =
            this._tripService.GetTripsByUser(this._notFriend);

        Assert.Empty(trips);
    }

    [Fact]
    public void GetTripsByUser_ReturnsUserTrips_WhenFriends()
    {
        this._userSession
            .Setup(session => session.GetLoggedInUser())
            .Returns(this._loggedInUser);

        Trip tripToSpain = new();

        User friend =
            AUser()
                .WithFriends(this._loggedInUser)
                .WithTrips(tripToSpain);

        IReadOnlyList<Trip> trips =
            this._tripService.GetTripsByUser(friend);

        Assert.Single(trips);
        Assert.Equal(tripToSpain, trips[0]);
    }
}
