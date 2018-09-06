using System;

namespace MarsRover
{
    public class Position : IEquatable<Position>
    {
        public int X { get; }
        public int Y { get; }
        public Direction Direction { get; }
        public Grid Grid { get; }

        public Position(int x, int y, Direction direction, Grid grid)
        {
            if (grid == null)
                throw new ArgumentNullException(nameof(grid));

            if (x < 0 || x >= grid.Size || y < 0 || y >= grid.Size)
                throw new ArgumentOutOfRangeException();

            X = x;
            Y = y;
            Direction = direction ?? throw new ArgumentNullException(nameof(direction));
            Grid = grid;
        }

        public Position Translate(int dx, int dy)
        {
            var newPosition = new Position((X + dx + Grid.Size) % Grid.Size, (Y + dy + Grid.Size) % Grid.Size, Direction, Grid);

            return newPosition.ContainsObstacle()
                       ? this
                       : newPosition;
        }

        public Position Face(Direction direction) =>
            new Position(X, Y, direction, Grid);

        public bool ContainsObstacle() =>
            Grid.ContainsObstacle(X, Y);

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
