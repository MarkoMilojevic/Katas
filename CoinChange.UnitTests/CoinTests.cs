using Xunit;

namespace CoinChange.UnitTests
{
    public class CoinTests
    {
        [Fact]
        public void EqualsTest()
        {
            Coin first = Coin.OneCent;
            Coin second = Coin.OneCent;

            Assert.True(first.Equals((object) second));
            Assert.True(first.Equals(second));
            Assert.True(first == second);

            Assert.False(first != second);

            first = null;
            second = null;

            Assert.True(first == second);

            Assert.False(first != second);
        }

        [Fact]
        public void NotEqualsTest()
        {
            Coin first = Coin.OneCent;
            Coin second = Coin.FiveCents;

            Assert.True(first != second);

            Assert.False(first.Equals((object)second));
            Assert.False(first.Equals(second));
            Assert.False(first == second);

            Assert.True(first != null);
            Assert.True(null != second);

            Assert.False(first.Equals(null));
            Assert.False(first.Equals((Coin) null));
            Assert.False(first == null);
            Assert.False(null == second);
        }
    }
}
