using System;

namespace CoinChange
{
    public sealed class Coin : IEquatable<Coin>, IComparable<Coin>
    {
        public static Coin OneCent { get; } = new Coin(1);
        public static Coin FiveCents { get; } = new Coin(5);
        public static Coin TenCents { get; } = new Coin(10);
        public static Coin TwentyFiveCents { get; } = new Coin(25);
        public static Coin FiftyCents { get; } = new Coin(50);
        public static Coin OneDollar { get; } = new Coin(100);

        private int Value { get; }

        private Coin(int value) =>
            Value = value;

        public bool Equals(Coin other)
        {
            if (other is null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return Value == other.Value;
        }

        public static bool operator ==(Coin left, Coin right) =>
            !(left is null ^ right is null) && (left is null || left.Equals(right));

        public static bool operator !=(Coin left, Coin right) =>
            !(left == right);

        public static implicit operator int(Coin coin) =>
            coin.Value;

        public override bool Equals(object obj) =>
            Equals(obj as Coin);

        public override int GetHashCode() =>
            Value.GetHashCode();

        public int CompareTo(Coin other) =>
            Value.CompareTo(other?.Value);

        public override string ToString() =>
            Value.ToString();
    }
}
