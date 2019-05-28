using Xunit;
using static ClockWiseTreeSearch.UnitTests.Asserts;

namespace ClockWiseTreeSearch.UnitTests
{
    public class MatrixExtensionsTests
    {
        [Fact]
        public void ReverseRowsInBottomHalfTest()
        {
            int[][] matrix = new[]
            {
                new[] { 1 },
                new[] { 2, 3 },
                new[] { 4, 5, 6, 7 },
                new[] { 8, 9, 10, 11, 12, 13, 14, 15 }
            };

            int[][] actual = matrix.ReverseRowsInBottomHalf();

            int[][] expected = new[]
            {
                new[] { 1 },
                new[] { 2, 3 },
                new[] { 7, 6, 5, 4 },
                new[] { 15, 14, 13, 12, 11, 10, 9, 8 }
            };

            AssertMatrix(actual, expected);
        }

        [Fact]
        public void AlternateRowsVerticallyTest()
        {
            int[][] matrix = new[]
            {
                new[] { 1 },
                new[] { 2, 3 },
                new[] { 4, 5, 6, 7 },
                new[] { 8, 9, 10, 11, 12, 13, 14, 15 }
            };

            int[][] actual = matrix.AlternateRowsVertically();

            int[][] expected = new[]
            {
                new[] { 1 },
                new[] { 8, 9, 10, 11, 12, 13, 14, 15 },
                new[] { 2, 3 },
                new[] { 4, 5, 6, 7 }
            };

            AssertMatrix(actual, expected);
        }
    }
}
