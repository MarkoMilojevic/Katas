namespace MarsRover.UnitTests
{
    public class MarsRoverBuilder
    {
        private Position _position = new PositionBuilder().Build();

        public MarsRoverBuilder With(Position position)
        {
            _position = position;
            return this;
        }

        public MarsRover Build() =>
            new MarsRover(_position);                                                                           
    }
}
