using System.Collections.Generic;
using System.Linq;

namespace CoinChange
{
    public static class Coins
    {
        public static IReadOnlyList<Coin> HighestToLowest { get; } = new[]
        {
            Coin.OneDollar, Coin.FiftyCents, Coin.TwentyFiveCents, Coin.TenCents, Coin.FiveCents, Coin.OneCent
        };

        public static IReadOnlyList<Coin> LowestToHighest { get; } = HighestToLowest.Reverse().ToList();

        public static int Count => HighestToLowest.Count;
    }
}
