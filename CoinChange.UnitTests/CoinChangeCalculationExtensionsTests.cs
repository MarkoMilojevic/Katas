using System;
using System.Collections.Generic;
using System.Linq;
using CoinChange.Functional;
using Xunit;

namespace CoinChange.UnitTests
{
    public class CoinChangeCalculationExtensionsTests
    {
        [Theory]
        [MemberData(nameof(ChangeParams))]
        public void ChangeTests(Coin[] availableCoins, int amount, Coin[] expectedChange)
        {
            Option<IEnumerable<Coin>> optionalChange = availableCoins.ChangeFor(amount);

            Coin[] change = optionalChange.Reduce(Enumerable.Empty<Coin>()).ToArray();
            Array.Sort(change);
            Array.Sort(expectedChange);

            Assert.Equal(expectedChange, change);
        }

        public static IEnumerable<object[]> ChangeParams()
        {
            yield return new object[]
            {
                new[] { Coin.OneDollar, Coin.FiftyCents, Coin.TwentyFiveCents, Coin.TenCents, Coin.FiveCents, Coin.OneCent },
                85,
                new[] { Coin.FiftyCents, Coin.TwentyFiveCents, Coin.TenCents }
            };

            yield return new object[]
            {
                new[] { Coin.OneDollar, Coin.FiftyCents, Coin.TwentyFiveCents, Coin.TenCents, Coin.FiveCents, Coin.OneCent },
                55,
                new[] { Coin.FiftyCents, Coin.FiveCents }
            };

            yield return new object[]
            {
                new[] { Coin.OneDollar, Coin.FiftyCents, Coin.TwentyFiveCents, Coin.TenCents, Coin.FiveCents, Coin.OneCent },
                25,
                new[] { Coin.TwentyFiveCents }
            };

            yield return new object[]
            {
                new[] { Coin.OneCent },
                100,
                new Coin[0]
            };

            yield return new object[]
            {
                new Coin[0],
                1,
                new Coin[0]
            };

            yield return new object[]
            {
                new[]
                {
                    Coin.FiftyCents, Coin.FiftyCents,
                    Coin.TwentyFiveCents,
                    Coin.TenCents, Coin.TenCents, Coin.TenCents, Coin.TenCents, Coin.TenCents,
                    Coin.OneCent, Coin.OneCent
                },
                80,
                new[] { Coin.FiftyCents, Coin.TenCents, Coin.TenCents, Coin.TenCents }
            };

            yield return new object[]
            {
                new[]
                {
                    Coin.FiftyCents, Coin.FiftyCents,
                    Coin.TwentyFiveCents, Coin.TwentyFiveCents, Coin.TwentyFiveCents,
                    Coin.TenCents, Coin.TenCents, Coin.TenCents, Coin.TenCents, Coin.TenCents,
                    Coin.FiveCents,
                    Coin.OneCent, Coin.OneCent, Coin.OneCent, Coin.OneCent, Coin.OneCent, Coin.OneCent, Coin.OneCent, Coin.OneCent
                },
                99,
                new[]
                {
                    Coin.FiftyCents,
                    Coin.TwentyFiveCents,
                    Coin.TenCents, Coin.TenCents,
                    Coin.OneCent, Coin.OneCent, Coin.OneCent, Coin.OneCent
                }
            };
        }
    }
}
