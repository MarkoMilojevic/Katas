using System.Collections.Generic;
using Xunit;
using static ClockWiseTreeSearch.UnitTests.Asserts;

namespace ClockWiseTreeSearch.UnitTests
{
    public class TreeExtensionsTests
    {
        [Fact]
        public void ClockWiseTreeSearchTest()
        {
            IEnumerable<int> actual = CreateTreeWithFourLevels().ClockWiseSearch();

            IEnumerable<int> expected = new[] 
            {
                1,
                15, 14, 13, 12, 11, 10, 9, 8,
                2, 3,
                7, 6, 5, 4
            };

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LevelsTest()
        {
            int[][] actual = CreateTreeWithFourLevels().Levels();

            int[][] expected = new[]
            {
                new[] { 1 },
                new[] { 2, 3 },
                new[] { 4, 5, 6, 7 },
                new[] { 8, 9, 10, 11, 12, 13, 14, 15 }
            };

            AssertMatrix(actual, expected);
        }

        private static Tree<int> CreateTreeWithFourLevels() => 
            new Tree<int>(
                new Node<int>(1)
                {
                    Left = new Node<int>(2)
                    {
                        Left = new Node<int>(4)
                        {
                            Left = new Node<int>(8),
                            Right = new Node<int>(9)
                        },
                        Right = new Node<int>(5)
                        {
                            Left = new Node<int>(10),
                            Right = new Node<int>(11)
                        }
                    },
                    Right = new Node<int>(3)
                    {
                        Left = new Node<int>(6)
                        {
                            Left = new Node<int>(12),
                            Right = new Node<int>(13)
                        },
                        Right = new Node<int>(7)
                        {
                            Left = new Node<int>(14),
                            Right = new Node<int>(15)
                        }
                    }
                }
            );
    }
}
