using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover
{
    public class Grid
    {
        private ISet<(int x, int y)> ObstacleCoordinates { get; }

        public int Size { get; }

        public Grid(int size) : this(size, new (int x, int y)[0])
        {
        }

        public Grid(int size, params (int x, int y)[] obstacleCoordinates)
        {
            if (size < 0)
                throw new ArgumentOutOfRangeException(nameof(size));

            if (obstacleCoordinates == null)
                throw new ArgumentNullException(nameof(obstacleCoordinates));

            if (obstacleCoordinates.Any(coord => coord.x < 0 || coord.x >= size || coord.y < 0 || coord.y >= size))
                throw new ArgumentException();

            Size = size;
            ObstacleCoordinates = obstacleCoordinates.ToHashSet() ?? throw new ArgumentNullException(nameof(obstacleCoordinates));
        }

        public bool ContainsObstacle(int x, int y) =>
            ObstacleCoordinates.Contains((x, y));
    }
}
