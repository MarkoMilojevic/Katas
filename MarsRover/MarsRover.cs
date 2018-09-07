using System;

namespace MarsRover
{
    public class MarsRover
    {
        public Position Position { get; }

        public MarsRover(Position position) =>
            Position = position ?? throw new ArgumentNullException(nameof(position));

        public MarsRover Execute(string instructions)
        {
            Position currentPosition = Position;

            instructions = instructions.ToLower();
            foreach (char instruction in instructions)
            {
                Position newPosition = currentPosition.Transform(instruction);
                if (newPosition == currentPosition)
                    break;

                currentPosition = newPosition;
            }

            return new MarsRover(currentPosition);
        }
    }
}
