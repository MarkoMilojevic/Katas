using System.Collections.Generic;
using System.Linq;

namespace RomanNumerals.Declarative
{
    public static class IntExtensions
    {
        public static IEnumerable<int> GetWeightedDigits(this int number) =>
            number
                .GetDigits()
                .Zip(number.GetWeights(), (digit, weight) => digit * weight)
                .Where(weightedDigit => weightedDigit != 0);

        public static IEnumerable<int> GetDigits(this int number) =>
            number
                .ToString()
                .Select(c => int.Parse(c.ToString()));

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
