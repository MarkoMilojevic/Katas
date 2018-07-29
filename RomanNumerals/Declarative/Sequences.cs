using System.Collections.Generic;

namespace RomanNumerals.Declarative
{
    public static class Sequences
    {
        public static IEnumerable<int> PowerOf10 { get; }

        static Sequences() =>
            PowerOf10 = new[] { 1, 10, 100, 1_000, 10_000, 100_000, 1_000_000, 10_000_000, 100_000_000, 1_000_000_000 };
    }
}
