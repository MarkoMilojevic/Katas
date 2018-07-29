﻿using System.Collections.Generic;
using System.Linq;

namespace RomanNumerals.Declarative
{
    public static class NumeralMappingsExtensions
    {
        private static IDictionary<int, string> Roman { get; } = new Dictionary<int, string>
        {
            { 1, "I" },
            { 2, "II" },
            { 3, "III" },
            { 4, "IV" },
            { 5, "V" },
            { 6, "VI" },
            { 7, "VII" },
            { 8, "VIII" },
            { 9, "IX" },

            { 10, "X" },
            { 20, "XX" },
            { 30, "XXX" },
            { 40, "XL" },
            { 50, "L" },
            { 60, "LX" },
            { 70, "LXX" },
            { 80, "LXXX" },
            { 90, "XC" },

            { 100, "C" },
            { 200, "CC" },
            { 300, "CCC" },
            { 400, "CD" },
            { 500, "D" },
            { 600, "DC" },
            { 700, "DCC" },
            { 800, "DCCC" },
            { 900, "CM" },

            { 1000, "M" }
        };

        public static string ToRoman(this int number) =>
            number
                .GetWeightedDigits()
                .SelectMany(weightedDigit => weightedDigit >= 1000
                                                 ? Enumerable.Repeat(1000, weightedDigit / 1000)
                                                 : new[] { weightedDigit })
                .Select(weightedDigit => Roman[weightedDigit])
                .Join(string.Empty);
    }
}
