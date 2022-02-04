using TripServiceKata.Users;

namespace TripServiceKata.Trips;

public interface ITripsRepository
{
    IReadOnlyList<Trip> GetTrips(User user);
}
