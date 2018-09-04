using System;

namespace MarsRover
{
    public class Position : IEquatable<Position>
    {
        public int X { get; }
        public int Y { get; }
        public Direction Direction { get; }
        public int GridSize { get; }

        public Position(int x, int y, Direction direction, int gridSize)
        {
            if (gridSize < 0)
                throw new ArgumentOutOfRangeException(nameof(gridSize));

            if (Math.Abs(x) >= gridSize || Math.Abs(y) >= gridSize)
                throw new ArgumentOutOfRangeException();

            X = x;
            Y = y;
            Direction = direction;
            GridSize = gridSize;
        }

        public Position Translate(int dx, int dy) =>
            new Position((X + dx + GridSize) % GridSize, (Y + dy + GridSize) % GridSize, Direction, GridSize);

        public Position Face(Direction direction) =>
            new Position(X, Y, direction, GridSize);

        public bool Equals(Position other)
        {
            if (other is null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return X == other.X
                && Y == other.Y
                && Direction == other.Direction;
        }

        public override bool Equals(object obj) =>
            Equals(obj as Position);

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = X;
                hashCode = (hashCode * 397) ^ Y;
                hashCode = (hashCode * 397) ^ Direction.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(Position left, Position right) =>
            !(left is null ^ right is null) && (left is null || left.Equals(right));

        public static bool operator !=(Position left, Position right) =>
            !(left == right);

        public override string ToString() =>
            $"X: {X}, Y: {Y}, {Direction}";
    }
}
