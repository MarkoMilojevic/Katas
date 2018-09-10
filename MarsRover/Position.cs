using System;
using System.Collections.Generic;
using FunctionalExtensions;

namespace MarsRover
{
    public sealed class Position : ValueObject
    {
        private Grid Grid { get; }

        public int X { get; }
        public int Y { get; }
        public Direction Direction { get; }

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
            int x = (X + dx).Mod(Grid.Size);
            int y = (Y + dy).Mod(Grid.Size);

            return Grid.ContainsObstacleAt(x, y)
                       ? this
                       : new Position(x, y, Direction, Grid);
        }

        public Position Face(Direction direction) =>
            new Position(X, Y, direction, Grid);

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return X;
            yield return Y;
            yield return Direction;
        }

        public override string ToString() =>
            $"X: {X}, Y: {Y}, Direction: {Direction}";
    }
}
