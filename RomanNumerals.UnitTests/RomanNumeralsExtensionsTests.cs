using System.Collections.Generic;
using RomanNumerals.Declarative;
using Xunit;

namespace RomanNumerals.UnitTests
{
    public class RomanNumeralsExtensionsTests
    {
        [Theory]
        [MemberData(nameof(ToRomanParams))]
        public void ToRoman(int number, string expectedRomanNumeral) =>
            Assert.Equal(expectedRomanNumeral, number.ToRoman());

        public static IEnumerable<object[]> ToRomanParams()
        {
            yield return new object[] { 1, "I" };
            yield return new object[] { 5, "V" };
            yield return new object[] { 10, "X" };
            yield return new object[] { 50, "L" };
            yield return new object[] { 100, "C" };
            yield return new object[] { 500, "D" };
            yield return new object[] { 1000, "M" };
            yield return new object[] { 2, "II" };
            yield return new object[] { 12, "XII" };
            yield return new object[] { 1058, "MLVIII" };
            yield return new object[] { 3999, "MMMCMXCIX" };
            yield return new object[] { 4000, "MMMM" };
            yield return new object[] { 5000, "MMMMM" };
            yield return new object[] { 5999, "MMMMMCMXCIX" };
            yield return new object[] { 11999, "MMMMMMMMMMMCMXCIX" };
        }
    }
}
