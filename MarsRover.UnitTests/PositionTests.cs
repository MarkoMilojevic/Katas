using Xunit;

namespace MarsRover.UnitTests
{
    public class PositionTests
    {
        private static PositionBuilder APosition() =>
            new PositionBuilder();

        [Theory]
        [InlineData(0, 0, 10, 1, 0, 1, 0)]
        [InlineData(0, 0, 10, 0, 1, 0, 1)]
        [InlineData(0, 0, 10, 1, 1, 1, 1)]
        [InlineData(0, 0, 10, 0, -1, 0, 9)]
        [InlineData(0, 0, 10, -1, 0, 9, 0)]
        [InlineData(0, 0, 10, -1, -1, 9, 9)]
        public void Translate(int x, int y, int gridSize, int dx, int dy, int expectedX, int expectedY)
        {
            Position position = APosition()
                                .WithCoordinates(x, y)
                                .WithGridSize(gridSize)
                                .Build();

            Position translated = position.Translate(dx, dy);

            Position expected = APosition()
                                .WithCoordinates(expectedX, expectedY)
                                .WithGridSize(gridSize)
                                .Build();

            Assert.Equal(expected, translated);
        }

        [Theory]
        [InlineData('N')]
        [InlineData('S')]
        [InlineData('E')]
        [InlineData('W')]
        public void Face(char direction)
        {
            Position position = APosition()
                                .Build();

            Position rotated = position.Face(PositionBuilder.DirectionsByChar[direction]);

            Position expected = APosition()
                                .Facing(direction)
                                .Build();

            Assert.Equal(expected, rotated);
        }
    }
}
