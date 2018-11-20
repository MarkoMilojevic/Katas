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

        private int _x;
        private int _y;
        private Direction _direction = Direction.North;
        private Grid _grid = new Grid(int.MaxValue / 2);

        public PositionBuilder WithCoordinates(int x, int y)
        {
            _x = x;
            _y = y;
            return this;
        }

        public PositionBuilder WithGridSize(int size)
        {
            _grid = new Grid(size);
            return this;
        }

        public PositionBuilder WithGrid(int size, params Coordinates[] obstacleCoordinates)
        {
            _grid = new Grid(size, obstacleCoordinates);
            return this;
        }

        public PositionBuilder Facing(char direction)
        {
            _direction = DirectionsByChar[direction];
            return this;
        }

        public Position Build() =>
            new Position(new Coordinates(_x, _y), _direction, _grid);
    }
}
