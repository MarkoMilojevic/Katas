using System;
using System.Collections.Generic;
using FunctionalExtensions;

namespace CoinChange
{
    public sealed class Coin : ValueObject, IComparable<Coin>
    {
        public static Coin OneDollar { get; } = new Coin(100);
        public static Coin FiftyCents { get; } = new Coin(50);
        public static Coin TwentyFiveCents { get; } = new Coin(25);
        public static Coin TenCents { get; } = new Coin(10);
        public static Coin FiveCents { get; } = new Coin(5);
        public static Coin OneCent { get; } = new Coin(1);

        private int Value { get; }

        private Coin(int value) =>
            Value = value;

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }

        public int CompareTo(Coin other) =>
            Value.CompareTo(other?.Value);

        public static implicit operator int(Coin coin) =>
            coin.Value;

        public override string ToString() =>
            Value.ToString();
    }
}
