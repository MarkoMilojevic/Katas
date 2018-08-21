using System;
using System.Linq;

namespace Diamond
{
    public class Diamond
    {
        public static string Create(char letter) =>
            Create(DiamondSize(letter));

        private static string Create(int diamondSize) =>
            Enumerable
                .Range(0, diamondSize)
                .Select(index => CreateRow(index, diamondSize))
                .Join(Environment.NewLine);

        private static int DiamondSize(char letter) =>
            2 * (letter - 'A') + 1;

        private static string CreateRow(int rowIndex, int diamondSize)
        {
            char[] row = new string('-', diamondSize).ToCharArray();

            int middleColumnIndex = MiddleColumnIndex(diamondSize);
            int charIndex = CharIndex(rowIndex, diamondSize);
            char charForCurrentRow = CharAt(charIndex);

            row[middleColumnIndex - charIndex] = charForCurrentRow;
            row[middleColumnIndex + charIndex] = charForCurrentRow;

            return new string(row);
        }

        private static int CharIndex(int rowIndex, int diamondSize) =>
            rowIndex <= MiddleRowIndex(diamondSize)
                ? rowIndex
                : (diamondSize - 1) - rowIndex;

        private static char CharAt(int charIndex) =>
            (char)('A' + charIndex);

        private static int MiddleRowIndex(int diamondSize) =>
            (diamondSize - 1) / 2;

        private static int MiddleColumnIndex(int diamondSize) =>
            MiddleRowIndex(diamondSize);
    }
}
