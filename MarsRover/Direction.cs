using System;
using System.Collections.Generic;

namespace MarsRover
{
    public sealed class Direction : IEquatable<Direction>
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

        public bool Equals(Direction other)
        {
            if (other is null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return Name == other.Name;
        }

        public override bool Equals(object obj) =>
            Equals(obj as Direction);

        public override int GetHashCode() =>
            Name.GetHashCode();

        public static bool operator ==(Direction left, Direction right) =>
            !(left is null ^ right is null) && (left is null || left.Equals(right));

        public static bool operator !=(Direction left, Direction right) =>
            !(left == right);

        public override string ToString() =>
            $"Direction: {Name}";
    }
}
