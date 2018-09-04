using System.Collections.Generic;

namespace MarsRover.UnitTests
{
    public class PositionBuilder
    {
        public static IReadOnlyDictionary<char, Direction> DirectionsByChar { get; } = new Dictionary<char, Direction>
        {
            { 'N', Direction.North },
            { 'S', Direction.South },
            { 'E', Direction.East },
            { 'W', Direction.West },
        };

        private int _x = 0;
        private int _y = 0;
        private Direction _direction = Direction.North;
        private int _gridSize = int.MaxValue;

        public PositionBuilder WithCoordinates(int x, int y, int gridSize)
        {
            _x = x;
            _y = y;
            _gridSize = gridSize;
            return this;
        }

        public PositionBuilder Facing(char direction)
        {
            _direction = DirectionsByChar[direction];
            return this;
        }

        public Position Build() =>
            new Position(_x, _y, _direction, _gridSize);                                                                           
    }
}
