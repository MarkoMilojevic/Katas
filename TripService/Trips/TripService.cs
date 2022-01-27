﻿using TripService.Exceptions;
using TripService.Users;

namespace TripService.Trips;

public class TripService
{
    public List<Trip> GetTripsByUser(User user)
    {
        List<Trip> tripList = new();

        User loggedUser = UserSession.GetInstance().GetLoggedUser();
        bool isFriend = false;

        if (loggedUser != null)
        {
            foreach (User friend in user.GetFriends())
            {
                if (friend.Equals(loggedUser))
                {
                    isFriend = true;
                    break;
                }
            }

            if (isFriend)
            {
                tripList = TripDAO.FindTripsByUser(user);
            }

            return tripList;
        }
        else
        {
            throw new UserNotLoggedInException();
        }
    }
}