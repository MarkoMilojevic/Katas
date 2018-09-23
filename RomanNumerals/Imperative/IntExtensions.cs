using System;
using System.Collections.Generic;

namespace RomanNumerals.Imperative
{
    public static class IntExtensions
    {
        public static IEnumerable<int> GetWeightedDigits(this int number)
        {
            var weightedDigits = new List<int>();

            int n = number.GetNumberOfDigits();
            for (int i = 0; i < n; i++)
            {
                int weight = (int) Math.Pow(10, n - i - 1);
                int digit = number / weight % 10;

                if (digit != 0)
                    weightedDigits.Add(weight * digit);
            }

            return weightedDigits;
        }

        private static int GetNumberOfDigits(this int number)
        {
            int numberOfDigits = 0;

            do
            {
                numberOfDigits += 1;
                number /= 10;
            }
            while (number > 0);

            return numberOfDigits;
        }
    }
}
