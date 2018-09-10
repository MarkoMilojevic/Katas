using Xunit;

namespace MarsRover.UnitTests
{
    public class MarsRoverTests
    {
        private static MarsRoverBuilder ARover() =>
            new MarsRoverBuilder();

        private static PositionBuilder APosition() =>
            new PositionBuilder();

        [Fact]
        public void RoverIsGivenStartingPosition()
        {
            Position position = APosition()
                                .Build();

            MarsRover rover = ARover()
                              .With(position)
                              .Build();

            Assert.Equal(position, rover.Position);
        }

        [Fact]
        public void RoverReceivesMoveInstructions() =>
            ARover().Build().Execute("fblrFBLR");

        [Theory]
        [InlineData(0, 0, 'N', 10, "f", 0, 1)]
        [InlineData(0, 0, 'S', 10, "f", 0, 9)]
        [InlineData(0, 0, 'E', 10, "f", 1, 0)]
        [InlineData(0, 0, 'W', 10, "f", 9, 0)]
        [InlineData(0, 0, 'N', 10, "b", 0, 9)]
        [InlineData(0, 0, 'S', 10, "b", 0, 1)]
        [InlineData(0, 0, 'E', 10, "b", 9, 0)]
        [InlineData(0, 0, 'W', 10, "b", 1, 0)]
        public void Move(int x, int y, char direction, int gridSize, string instruction, int expectedX, int expectedY)
        {
            Position position = APosition()
                                .WithCoordinates(x, y)
                                .WithGridSize(gridSize)
                                .Facing(direction)
                                .Build();

            MarsRover rover = ARover()
                              .With(position)
                              .Build();

            MarsRover moved = rover.Execute(instruction);

            Position expectedPosition = APosition()
                                        .WithCoordinates(expectedX, expectedY)
                                        .WithGridSize(gridSize)
                                        .Facing(direction)
                                        .Build();

            Assert.Equal(expectedPosition, moved.Position);
        }

        [Fact]
        public void MoveAgainstObstacle()
        {
            Position position = APosition()
                                .WithCoordinates(0, 0)
                                .WithGrid(10, (0, 1))
                                .Facing('N')
                                .Build();

            MarsRover rover = ARover()
                              .With(position)
                              .Build();

            MarsRover moved = rover.Execute("f");

            Position expectedPosition = position;

            Assert.Equal(expectedPosition, moved.Position);
        }

        [Theory]
        [InlineData('N', "l", 'W')]
        [InlineData('S', "l", 'E')]
        [InlineData('E', "l", 'N')]
        [InlineData('W', "l", 'S')]
        [InlineData('N', "r", 'E')]
        [InlineData('S', "r", 'W')]
        [InlineData('E', "r", 'S')]
        [InlineData('W', "r", 'N')]
        public void Rotate(char direction, string instruction, char expectedDirection)
        {
            Position position = APosition()
                                .Facing(direction)
                                .Build();

            MarsRover rover = ARover()
                              .With(position)
                              .Build();

            MarsRover moved = rover.Execute(instruction);

            Position expectedPosition = APosition()
                                        .Facing(expectedDirection)
                                        .Build();

            Assert.Equal(expectedPosition, moved.Position);
        }
    }
}
