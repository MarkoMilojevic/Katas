using System.Collections.Generic;
using System.Linq;

namespace RomanNumerals.Declarative
{
    public static class IntExtensions
    {
        public static IEnumerable<int> GetWeightedDigits(this int number) =>
            number
                .GetDigits()
                .MultiplyWith(number.GetWeights())
                .Where(weightedDigit => weightedDigit != 0);

        public static IEnumerable<int> GetDigits(this int number) =>
            number
                .ToString()
                .Select(c => int.Parse(c.ToString()));

        private static IEnumerable<int> MultiplyWith(this IEnumerable<int> source, IEnumerable<int> factors) =>
            source.Zip(factors, (x, y) => x * y);

        private static IEnumerable<int> GetWeights(this int number) =>
            Sequences
                .PowerOf10
                .Take(number.GetNumberOfDigits())
                .Reverse();

        public static int GetNumberOfDigits(this int number) =>
            number
                .ToString()
                .Length;
    }
}
