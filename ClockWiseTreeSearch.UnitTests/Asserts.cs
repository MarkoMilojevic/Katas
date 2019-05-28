using Xunit;

namespace ClockWiseTreeSearch.UnitTests
{
    public static class Asserts
    {
        public static void AssertMatrix(int[][] actual, int[][] expected)
        {
            Assert.Equal(expected.Length, actual.Length);

            for (int i = 0; i < actual.Length; i++)
            {
                Assert.Equal(expected[i].Length, actual[i].Length);

                Assert.Equal(expected[i], actual[i]);
            }
        }
    }
}
