using TripServiceKata.Exceptions;
using TripServiceKata.Users;

namespace TripServiceKata.Trips;

public class TripDAO : ITripsRepository
{
    public static IReadOnlyList<Trip> FindTripsByUser(User user)
    {
        throw new DependendClassCallDuringUnitTestException(
            "TripDAO should not be invoked on an unit test.");
    }

    public IReadOnlyList<Trip> GetTrips(User user) =>
        TripDAO.FindTripsByUser(user);
}
