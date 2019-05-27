using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ClockWiseTreeSearch.UnitTests
{
    public class TreeExtensionsTests
    {
        [Fact]
        public void ClockWiseTreeSearchTest()
        {
            Tree<int> tree = CreateTree();

            IEnumerable<int> actual = tree
                                        .ClockWiseSearch()
                                        .Select(node => node.Value);

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
            Tree<int> tree = CreateTree();

            IEnumerable<int> actual = tree
                                        .Levels()
                                        .SelectMany(level => level.Select(node => node.Value));

            IEnumerable<int> expected = new[]
            {
                1,
                2, 3,
                4, 5, 6, 7,
                8, 9, 10, 11, 12, 13, 14, 15
            };

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AlternateVerticallyTest()
        {
            Tree<int> tree = CreateTree();

            IEnumerable<int> actual = tree
                                        .Levels()
                                        .AlternateVertically()
                                        .SelectMany(level => level.Select(node => node.Value).ToList());

            IEnumerable<int> expected = new[]
            {
                1,
                8, 9, 10, 11, 12, 13, 14, 15,
                2, 3,
                4, 5, 6, 7
            };

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AlternateIndexesTest()
        {
            Tree<int> tree = CreateTree();

            IEnumerable<int> actual = 5.AlternateIndexes();
            IEnumerable<int> expected = new[] { 0, 4, 1, 3, 2 };

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void AlternateReverseTest()
        {
            Tree<int> tree = CreateTree();

            IEnumerable<int> actual = tree
                                        .Levels()
                                        .AlternateReverse()
                                        .SelectMany(level => level.Select(node => node.Value));

            IEnumerable<int> expected = new[]
            {
                1,
                3, 2,
                4, 5, 6, 7,
                15, 14, 13, 12, 11, 10, 9, 8
            };

            Assert.Equal(expected, actual);
        }

        private static Tree<int> CreateTree() => 
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
