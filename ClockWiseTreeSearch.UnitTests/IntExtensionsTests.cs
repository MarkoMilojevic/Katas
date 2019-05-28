using Xunit;

namespace ClockWiseTreeSearch.UnitTests
{
    public class IntExtensionsTests
    {
        [Theory]
        [InlineData(0, new int[] { })]
        [InlineData(1, new int[] { 0 })]
        [InlineData(2, new int[] { 0, 1 })]
        [InlineData(3, new int[] { 0, 2, 1 })]
        [InlineData(4, new int[] { 0, 3, 1, 2 })]
        [InlineData(5, new int[] { 0, 4, 1, 3, 2 })]
        [InlineData(6, new int[] { 0, 5, 1, 4, 2, 3 })]
        [InlineData(7, new int[] { 0, 6, 1, 5, 2, 4, 3 })]
        public void AlternateIndexesTest(int indexesCount, int[] expectedIndexes) => 
            Assert.Equal(expectedIndexes, indexesCount.AlternateIndexes());
    }
}
