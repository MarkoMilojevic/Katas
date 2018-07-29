using RomanNumerals.Declarative;
using Xunit;

namespace RomanNumerals.UnitTests.Declarative
{
    public class RomanNumeralsExtensionsTests
    {
        [Theory]
        [InlineData(1, "I")]
        [InlineData(5, "V")]
        [InlineData(10, "X")]
        [InlineData(50, "L")]
        [InlineData(100, "C")]
        [InlineData(500, "D")]
        [InlineData(1000, "M")]
        [InlineData(2, "II")]
        [InlineData(12, "XII")]
        [InlineData(1058, "MLVIII")]
        [InlineData(3999, "MMMCMXCIX")]
        [InlineData(4000, "MMMM")]
        [InlineData(5000, "MMMMM")]
        [InlineData(5999, "MMMMMCMXCIX")]
        [InlineData(11999, "MMMMMMMMMMMCMXCIX")]
        public void ToRoman(int number, string expectedRomanNumeral) =>
            Assert.Equal(expectedRomanNumeral, number.ToRoman());
    }
}
