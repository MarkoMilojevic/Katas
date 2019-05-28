using System.Collections.Generic;
using System.Linq;

namespace ClockWiseTreeSearch
{
    public static class IntExtensions
    {
        public static IEnumerable<int> AlternateIndexes(this int n)
        {
            if (n < 0)
                return Enumerable.Empty<int>();

            return Enumerable
                    .Range(0, n)
                    .Select(i => i % 2 == 0 ? i / 2 : n - ((i + 1) / 2));
        }
    }
}
