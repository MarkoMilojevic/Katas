using TripServiceKata.Users;
using Xunit;
using static TripServiceKata.UnitTests.UserBuilder;

namespace TripServiceKata.UnitTests;

public class UserTests
{
    [Fact]
    public void IsFriendsWith_ReturnsTrue_WhenFriends()
    {
        User bob = AUser();
        User tom = AUser().WithFriends(bob);

        Assert.True(tom.IsFriendsWith(bob));
        Assert.False(bob.IsFriendsWith(tom));
    }

    [Fact]
    public void IsFriend_ReturnsFalse_WhenNotFriends()
    {
        User bob = AUser();
        User tom = AUser();

        Assert.False(bob.IsFriendsWith(tom));
        Assert.False(tom.IsFriendsWith(bob));
    }
}
