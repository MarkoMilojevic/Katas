using TripService.Exceptions;
using TripService.Users;

namespace TripService.Trips;

public class TripDAO
{
    public static List<Trip> FindTripsByUser(User user)
    {
        throw new DependendClassCallDuringUnitTestException(
            "TripDAO should not be invoked on an unit test.");
    }
}
