using System;
using System.IO;
using Xunit;

namespace Diamond.UnitTests
{
    public class DiamondTests
    {
        [Theory]
        [InlineData('A', 1)]
        [InlineData('B', 3)]
        [InlineData('C', 5)]
        [InlineData('D', 7)]
        [InlineData('Z', 51)]
        public void NumberOfRows(char diamondLetter, int expectedNumberOfRows)
        {
            string diamond = Diamond.CreateFor(diamondLetter);

            int numberOfRows = diamond.Split(new[] { Environment.NewLine }, StringSplitOptions.None).Length;

            Assert.Equal(expectedNumberOfRows, numberOfRows);
        }

        [Theory]
        [InlineData('A', 1)]
        [InlineData('B', 3)]
        [InlineData('C', 5)]
        [InlineData('D', 7)]
        [InlineData('Z', 51)]
        public void NumberOfColumns(char diamondLetter, int expectedNumberOfColumns)
        {
            string diamond = Diamond.CreateFor(diamondLetter);

            string[] rows = diamond.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            foreach (string row in rows)
            {
                int numberOfColumns = row.Length;

                Assert.Equal(expectedNumberOfColumns, numberOfColumns);
            }
        }

        [Theory]
        [InlineData('A', 0, 'A')]
        [InlineData('B', 0, 'A')]
        [InlineData('B', 1, 'B')]
        [InlineData('B', 2, 'A')]
        [InlineData('C', 0, 'A')]
        [InlineData('C', 1, 'B')]
        [InlineData('C', 2, 'C')]
        [InlineData('C', 3, 'B')]
        [InlineData('C', 4, 'A')]
        public void RowContainsCorrectLetter(char diamondLetter, int rowIndex, char letter)
        {
            string diamond = Diamond.CreateFor(diamondLetter);

            string[] rows = diamond.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            string row = rows[rowIndex];

            Assert.True(row.Contains(letter));
        }

        [Theory]
        [InlineData('A', 0, 'A', 0, 0)]
        [InlineData('B', 0, 'A', 1, 1)]
        [InlineData('B', 1, 'B', 0, 2)]
        [InlineData('B', 2, 'A', 1, 1)]
        [InlineData('C', 0, 'A', 2, 2)]
        [InlineData('C', 1, 'B', 1, 3)]
        [InlineData('C', 2, 'C', 0, 4)]
        [InlineData('C', 3, 'B', 1, 3)]
        [InlineData('C', 4, 'A', 2, 2)]
        public void LetterIsInCorrectColumns(char diamondLetter, int rowIndex, char letter, int firstColumnIndex, int secondColumnIndex)
        {
            string diamond = Diamond.CreateFor(diamondLetter);

            string[] rows = diamond.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            char[] row = rows[rowIndex].ToCharArray();

            for (int i = 0; i < row.Length; i++)
            {
                if (i == firstColumnIndex || i == secondColumnIndex)
                    Assert.Equal(letter, row[i]);
                else
                    Assert.Equal('-', row[i]);
            }
        }

        [Fact]
        public void Z_DiamondIsCorrect()
        {
            string expectedDiamond = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "z_diamond.txt"));

            Assert.Equal(expectedDiamond, Diamond.CreateFor('Z'));
        }
    }
}
