using System;
using System.Collections.Generic;

namespace RomanNumerals.Imperative
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

        private static IDictionary<string, int> Arabic { get; } = new Dictionary<string, int>
        {
            {"I", 1 },
            {"II", 2 },
            {"III", 3 },
            {"IV", 4 },
            {"V", 5 },
            {"VI", 6 },
            {"VII", 7 },
            {"VIII", 8 },
            {"IX", 9 },

            {"X", 10 },
            {"XX", 20 },
            {"XXX", 30 },
            {"XL", 40 },
            {"L", 50 },
            {"LX", 60 },
            {"LXX", 70 },
            {"LXXX", 80 },
            {"XC", 90 },

            { "C", 100 },
            { "CC", 200 },
            { "CCC", 300 },
            { "CD", 400 },
            { "D", 500 },
            { "DC", 600 },
            { "DCC", 700 },
            { "DCCC", 800 },
            { "CM", 900 },

            { "M", 1000 }
        };

        public static string ToRoman(this int number)
        {
            string romanNumeral = string.Empty;

            IEnumerable<int> weightedDigits = number.GetWeightedDigits();
            foreach (int weightedDigit in weightedDigits)
            {
                if (weightedDigit >= 1000)
                {
                    char romanThousand = Convert.ToChar(Roman[1000]);
                    romanNumeral += new string(romanThousand, weightedDigit / 1000);
                }
                else
                {
                    romanNumeral += Roman[weightedDigit];
                }
            }

            return romanNumeral;
        }

        public static int ToArabic(this string romanNumeral)
        {
            if (romanNumeral == string.Empty)
                return 0;

            int index = 0;
            string left;
            string right;

            do
            {
                left = romanNumeral.Substring(0, romanNumeral.Length - index);
                right = romanNumeral.Substring(romanNumeral.Length - index, index);

                index += 1;
            }
            while (!Arabic.ContainsKey(left) && index < romanNumeral.Length);

            if (!Arabic.ContainsKey(left))
                throw new ArgumentException($"Provided Roman numeral '{romanNumeral}' is invalid.", nameof(romanNumeral));

            return Arabic[left] + ToArabic(right);
        }
    }
}
