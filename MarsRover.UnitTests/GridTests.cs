using Xunit;

namespace MarsRover.UnitTests
{
    public class GridTests
    {
        [Fact]
        public void GridHasObsticles()
        {
            var grid = new Grid(10, (5, 5));

            Assert.True(grid.ContainsObstacleAt(5, 5));
        }
    }
}
