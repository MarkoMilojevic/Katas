﻿using System.Collections.Generic;
using RomanNumerals.Declarative;
using Xunit;

namespace RomanNumerals.UnitTests.Declarative
{
    public class IntExtensionsTests
    {
        [Theory]
        [MemberData(nameof(GetWeightedDigitsParams))]
        public void GetWeightedDigits(int number, int[] expectedWeightedDigits) =>
            Assert.Equal(expectedWeightedDigits, number.GetWeightedDigits());

        public static IEnumerable<object[]> GetWeightedDigitsParams()
        {
            yield return new object[] { 1, new[] { 1 } };
            yield return new object[] { 10, new[] { 10 } };
            yield return new object[] { 12, new[] { 10, 2 } };
            yield return new object[] { 100, new[] { 100 } };
            yield return new object[] { 102, new[] { 100, 2 } };
            yield return new object[] { 120, new[] { 100, 20 } };
            yield return new object[] { 123, new[] { 100, 20, 3 } };
            yield return new object[] { 1000, new[] { 1000 } };
            yield return new object[] { 1002, new[] { 1000, 2 } };
            yield return new object[] { 1020, new[] { 1000, 20 } };
            yield return new object[] { 1023, new[] { 1000, 20, 3 } };
            yield return new object[] { 1200, new[] { 1000, 200 } };
            yield return new object[] { 1203, new[] { 1000, 200, 3 } };
            yield return new object[] { 1230, new[] { 1000, 200, 30 } };
            yield return new object[] { 1234, new[] { 1000, 200, 30, 4 } };
        }
    }
}
