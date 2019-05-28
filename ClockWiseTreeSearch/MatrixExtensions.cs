using System;
using System.Linq;

namespace ClockWiseTreeSearch
{
    public static class MatrixExtensions
    {
        public static T[][] ReverseRowsInBottomHalf<T>(this T[][] levels)
        {
            if (levels == null)
                return new T[0][];

            return Enumerable
                    .Range(0, levels.Length)
                    .Select(i => i < (levels.Length + 1) / 2 ? levels[i] : levels[i].AsEnumerable().Reverse().ToArray())
                    .ToArray();
        }

        public static T[][] AlternateRowsVertically<T>(this T[][] levels)
        {
            if (levels == null)
                return new T[0][];

            return levels
                    .Length
                    .AlternateIndexes()
                    .Select(i => levels[i])
                    .ToArray();
        }
    }
}
