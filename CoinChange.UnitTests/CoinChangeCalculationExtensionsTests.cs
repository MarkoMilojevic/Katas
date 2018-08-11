﻿using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CoinChange.UnitTests
{
    public class CoinChangeCalculationExtensionsTests
    {
        [Fact]
        public void A()
        {
            var coins = new[] { Coin.OneDollar, Coin.FiftyCents, Coin.TwentyFiveCents, Coin.TenCents, Coin.FiveCents, Coin.OneCent };

            Option<IEnumerable<Coin>> optionalChange = coins.ChangeFor(Coin.FiftyCents + Coin.TwentyFiveCents + Coin.TenCents);

            IEnumerable<Coin> change = ((Some<IEnumerable<Coin>>) optionalChange).Reduce(Enumerable.Empty<Coin>()).ToList();
            Assert.True(change.Count() == 3);
            Assert.True(change.Count(coin => coin == Coin.FiftyCents) == 1);
            Assert.True(change.Count(coin => coin == Coin.TwentyFiveCents) == 1);
            Assert.True(change.Count(coin => coin == Coin.TenCents) == 1);
        }

        [Fact]
        public void B()
        {
            var coins = new[] { Coin.OneDollar, Coin.FiftyCents, Coin.TwentyFiveCents, Coin.TenCents, Coin.FiveCents, Coin.OneCent };

            Option<IEnumerable<Coin>> optionalChange = coins.ChangeFor(Coin.FiftyCents + Coin.FiveCents);

            IEnumerable<Coin> change = ((Some<IEnumerable<Coin>>)optionalChange).Reduce(Enumerable.Empty<Coin>()).ToList();
            Assert.True(change.Count() == 2);
            Assert.True(change.Count(coin => coin == Coin.FiftyCents) == 1);
            Assert.True(change.Count(coin => coin == Coin.FiveCents) == 1);
        }

        [Fact]
        public void C()
        {
            var coins = new[] { Coin.OneDollar, Coin.FiftyCents, Coin.TwentyFiveCents, Coin.TenCents, Coin.FiveCents, Coin.OneCent };

            Option<IEnumerable<Coin>> optionalChange = coins.ChangeFor(Coin.TwentyFiveCents);

            IEnumerable<Coin> change = ((Some<IEnumerable<Coin>>)optionalChange).Reduce(Enumerable.Empty<Coin>()).ToList();
            Assert.True(change.Count() == 1);
            Assert.True(change.Count(coin => coin == Coin.TwentyFiveCents) == 1);
        }

        [Fact]
        public void D()
        {
            var coins = new[] { Coin.OneCent };

            Option<IEnumerable<Coin>> optionalChange = coins.ChangeFor(Coin.OneDollar);

            Assert.True(optionalChange is None<IEnumerable<Coin>>);
        }

        [Fact]
        public void E()
        {
            IEnumerable<Coin> coins = Enumerable.Empty<Coin>();

            Option<IEnumerable<Coin>> optionalChange = coins.ChangeFor(Coin.OneCent);

            Assert.True(optionalChange is None<IEnumerable<Coin>>);
        }
        
        [Fact]
        public void F()
        {
            var coins = new[] { Coin.FiftyCents, Coin.FiftyCents, Coin.TwentyFiveCents, Coin.TenCents, Coin.TenCents, Coin.TenCents, Coin.TenCents, Coin.TenCents, Coin.OneCent, Coin.OneCent};

            Option<IEnumerable<Coin>> optionalChange = coins.ChangeFor(80);

            IEnumerable<Coin> change = ((Some<IEnumerable<Coin>>)optionalChange).Reduce(Enumerable.Empty<Coin>()).ToList();
            Assert.True(change.Count() == 4);
            Assert.True(change.Count(coin => coin == Coin.FiftyCents) == 1);
            Assert.True(change.Count(coin => coin == Coin.TenCents) == 3);
        }
        
        [Fact]
        public void G()
        {
            var coins = new[]
            {
                Coin.FiftyCents, Coin.FiftyCents,
                Coin.TwentyFiveCents, Coin.TwentyFiveCents, Coin.TwentyFiveCents,
                Coin.TenCents, Coin.TenCents, Coin.TenCents, Coin.TenCents, Coin.TenCents,
                Coin.FiveCents,
                Coin.OneCent, Coin.OneCent, Coin.OneCent, Coin.OneCent, Coin.OneCent, Coin.OneCent, Coin.OneCent, Coin.OneCent
            };

            Option<IEnumerable<Coin>> optionalChange = coins.ChangeFor(99);

            IEnumerable<Coin> change = ((Some<IEnumerable<Coin>>)optionalChange).Reduce(Enumerable.Empty<Coin>()).ToList();
            Assert.True(change.Count() == 8);
            Assert.True(change.Count(coin => coin == Coin.FiftyCents) == 1);
            Assert.True(change.Count(coin => coin == Coin.TwentyFiveCents) == 1);
            Assert.True(change.Count(coin => coin == Coin.TenCents) == 2);
            Assert.True(change.Count(coin => coin == Coin.OneCent) == 4);
        }
    }
}