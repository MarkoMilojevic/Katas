using System;
using System.Linq;

namespace ClockWiseTreeSearch
{
    public static class MatrixExtensions
    {
        public static T[][] AlternateVertically<T>(this T[][] levels)
        {
            if (levels == null)
                return new T[0][];

            return levels
                    .Length
                    .AlternateIndexes()
                    .Select(i => levels[i])
                    .ToArray();
        }

        public static T[][] AlternateReverse<T>(this T[][] levels)
        {
            if (levels == null)
                return new T[0][];

            return Enumerable
                    .Range(0, levels.Length)
                    .Select(i => i % 2 == 0 ? levels[i] : levels[i].AsEnumerable().Reverse().ToArray())
                    .ToArray();
        }
    }
}
