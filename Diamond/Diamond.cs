using System;
using System.Linq;

namespace Diamond
{
    public class Diamond
    {
        public static string CreateFor(char letter) =>
            Enumerable
                .Range(0, DiamondSizeFor(letter))
                .Select(index => CreateRow(letter, index))
                .Join(Environment.NewLine);

        private static int DiamondSizeFor(char letter) =>
            2 * (letter - 'A' + 1) - 1;

        private static string CreateRow(char letter, int rowIndex)
        {
            int diamondSize = DiamondSizeFor(letter);

            char[] row = new string('-', diamondSize).ToCharArray();

            int charIndex = CharIndexGiven(rowIndex, diamondSize);
            char charForCurrentRow = CharFor(charIndex);
            int middleColumnIndex = MiddleColumnIndexFor(diamondSize);

            row[middleColumnIndex - charIndex] = charForCurrentRow;
            row[middleColumnIndex + charIndex] = charForCurrentRow;

            return new string(row);
        }

        private static int CharIndexGiven(int rowIndex, int diamondSize) =>
            rowIndex <= MiddleRowIndexFor(diamondSize)
                ? rowIndex
                : diamondSize - 1 - rowIndex;

        private static char CharFor(int charIndex) =>
            (char)('A' + charIndex);

        private static int MiddleRowIndexFor(int diamondSize) =>
            (diamondSize - 1) / 2;

        private static int MiddleColumnIndexFor(int diamondSize) =>
            MiddleRowIndexFor(diamondSize);
    }
}
