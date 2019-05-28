using Xunit;

namespace GameOfLife.UnitTests
{
    public class GameOfLifeTests
    {
        [Fact]
        public void ALivingCellWithLessThanTwoNeighboursDies()
        {
            Cell cell = Cell.Alive();
            var game = new GameOfLife(new[] { cell });

            game.Next();

            Assert.True(cell.IsDead);
        }

        [Fact]
        public void ALivingCellWithTwoOrThreeNeighboursSurvives()
        {
            Cell c1 = Cell.Alive();
            Cell c2 = Cell.Alive();
            Cell c3 = Cell.Alive();
            Cell c4 = Cell.Alive();

            Cell.Connect(c1, c2);
            Cell.Connect(c1, c3);
            Cell.Connect(c1, c4);

            Cell.Connect(c2, c3);

            var game = new GameOfLife(new[] { c1, c2, c3, c4 });

            game.Next();

            Assert.True(c1.IsAlive);
            Assert.True(c2.IsAlive);
            Assert.True(c3.IsAlive);
        }

        [Fact]
        public void ALivingCellWithMoreThanThreeNeighboursDies()
        {
            Cell c1 = Cell.Alive();
            Cell c2 = Cell.Alive();
            Cell c3 = Cell.Alive();
            Cell c4 = Cell.Alive();
            Cell c5 = Cell.Alive();

            Cell.Connect(c1, c2);
            Cell.Connect(c1, c3);
            Cell.Connect(c1, c4);
            Cell.Connect(c1, c5);

            var game = new GameOfLife(new[] { c1, c2, c3, c4, c5 });

            game.Next();

            Assert.True(c1.IsDead);
        }

        [Fact]
        public void ADeadCellWithExactlyThreeNeighboursBecomesAlive()
        {
            Cell c1 = Cell.Dead();
            Cell c2 = Cell.Alive();
            Cell c3 = Cell.Alive();
            Cell c4 = Cell.Alive();

            Cell.Connect(c1, c2);
            Cell.Connect(c1, c3);
            Cell.Connect(c1, c4);

            var game = new GameOfLife(new[] { c1, c2, c3, c4 });

            game.Next();

            Assert.True(c1.IsAlive);
        }
    }
}
