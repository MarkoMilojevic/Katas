using System;
using System.Collections.Generic;
using FunctionalExtensions;

namespace MarsRover
{
    public sealed class Position : ValueObject
    {
        private Grid Grid { get; }

        public Coordinates Coordinates { get; }
        public Direction Direction { get; }

        public Position(Coordinates coordinates, Direction direction, Grid grid)
        {
            if (coordinates == null)
                throw new ArgumentNullException(nameof(coordinates));

            if (grid == null)
                throw new ArgumentNullException(nameof(grid));

            if (coordinates.X >= grid.Size || coordinates.Y >= grid.Size)
                throw new ArgumentOutOfRangeException(nameof(coordinates));

            Coordinates = coordinates;
            Direction = direction ?? throw new ArgumentNullException(nameof(direction));
            Grid = grid;
        }

        public Position Translate(int dx, int dy) =>
            new Position(Grid.Translate(Coordinates, dx, dy), Direction, Grid);

        public Position Face(Direction direction) =>
            new Position(Coordinates, direction, Grid);

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Coordinates;
            yield return Direction;
        }

        public override string ToString() =>
            $"Coordinates: [{Coordinates}], Direction: {Direction}";
    }
}
