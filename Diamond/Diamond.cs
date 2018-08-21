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

            char charForCurrentRow = CharAt(rowIndex, diamondSize);
            int charColumnIndex = CharColumnIndexGiven(rowIndex, diamondSize);

            row[charColumnIndex] = charForCurrentRow;
            row[row.Length - 1 - charColumnIndex] = charForCurrentRow;

            return new string(row);
        }

        private static char CharAt(int rowIndex, int diamondSize) =>
            (char)('A' + CharIndexGiven(rowIndex, diamondSize));

        private static int CharColumnIndexGiven(int rowIndex, int diamondSize) =>
            MiddleColumnIndexFor(diamondSize) - CharIndexGiven(rowIndex, diamondSize);

        private static int CharIndexGiven(int rowIndex, int diamondSize) =>
            rowIndex <= MiddleRowIndexFor(diamondSize)
                ? rowIndex
                : (diamondSize - 1) - rowIndex;

        private static int MiddleRowIndexFor(int diamondSize) =>
            (diamondSize - 1) / 2;

        private static int MiddleColumnIndexFor(int diamondSize) =>
            MiddleRowIndexFor(diamondSize);
    }
}
