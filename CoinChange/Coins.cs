using System.Collections.Generic;
using System.Linq;

namespace CoinChange
{
    public static class Coins
    {
        public static IReadOnlyList<Coin> AllCoinsHighestToLowest { get; } = new[]
        {
            Coin.OneDollar, Coin.FiftyCents, Coin.TwentyFiveCents, Coin.TenCents, Coin.FiveCents, Coin.OneCent
        };

        public static IReadOnlyList<Coin> AllCoinsLowestToHighest { get; } = AllCoinsHighestToLowest.Reverse().ToList();

        public static int Count => AllCoinsHighestToLowest.Count;
    }
}
