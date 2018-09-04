using System;

namespace MarsRover
{
    public class MarsRover
    {
        public Position Position { get; }

        public MarsRover(Position position) =>
            Position = position ?? throw new ArgumentNullException(nameof(position));

        public MarsRover Execute(string instructions) =>
            new MarsRover(Position.Transform(instructions));
    }
}
