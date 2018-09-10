using System.Collections.Generic;
using FunctionalExtensions;

namespace MarsRover
{
    public sealed class Direction : ValueObject
    {
        public static Direction North { get; } = new Direction(nameof(North));
        public static Direction South { get; } = new Direction(nameof(South));
        public static Direction East { get; } = new Direction(nameof(East));
        public static Direction West { get; } = new Direction(nameof(West));

        public static IReadOnlyDictionary<Direction, Direction> Left = new Dictionary<Direction, Direction>
        {
            { North, West },
            { South, East },
            { East, North },
            { West, South }
        };

        public static IReadOnlyDictionary<Direction, Direction> Right = new Dictionary<Direction, Direction>
        {
            { North, East },
            { South, West },
            { East, South },
            { West, North }
        };

        private string Name { get; }

        private Direction(string name) =>
            Name = name;

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Name;
        }

        public override string ToString() =>
            $"{Name}";
    }
}
