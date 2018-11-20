using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover
{
    public class Grid
    {
        private ISet<Coordinates> ObstacleCoordinates { get; }

        public int Size { get; }

        public Grid(int size) : this(size, new Coordinates[0])
        {
        }

        public Grid(int size, params Coordinates[] obstacleCoordinates)
        {
            if (size < 0)
                throw new ArgumentOutOfRangeException(nameof(size));

            if (obstacleCoordinates == null)
                throw new ArgumentNullException(nameof(obstacleCoordinates));

            if (obstacleCoordinates.Any(coord => coord.X < 0 || coord.X >= size || coord.Y < 0 || coord.Y >= size))
                throw new ArgumentException();

            Size = size;
            ObstacleCoordinates = obstacleCoordinates.ToHashSet();
        }

        public Coordinates Translate(Coordinates coordinates, int dx, int dy)
        {
            int newX = Translate(coordinates.X, dx);
            int newY = Translate(coordinates.Y, dy);
            var newCoordinates = new Coordinates(newX, newY);

            return ObstacleAt(newCoordinates)
                       ? coordinates
                       : newCoordinates;
        }

        private int Translate(int coordinate, int delta) =>
            (coordinate + delta).Mod(Size);

        private bool ObstacleAt(Coordinates newCoordinates) =>
            ObstacleCoordinates.Contains(newCoordinates);
    }
}
