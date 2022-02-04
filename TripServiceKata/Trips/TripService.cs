using TripServiceKata.Exceptions;
using TripServiceKata.Users;

namespace TripServiceKata.Trips;

public class TripService
{
    private readonly IUserSession _userSession;
    private readonly ITripsRepository _tripsRepository;

    public TripService(
        IUserSession userSession,
        ITripsRepository tripsRepository)
    {
        this._userSession = userSession;
        this._tripsRepository = tripsRepository;
    }

    public IReadOnlyList<Trip> GetTripsByUser(User user)
    {
        User? loggedInUser = this._userSession.GetLoggedInUser();
        if (loggedInUser is null)
        {
            throw new UserNotLoggedInException();
        }

        return user.IsFriendsWith(loggedInUser)
            ? this._tripsRepository.GetTrips(user)
            : new List<Trip>();
    }
}
