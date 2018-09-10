using System;
using System.Collections.Generic;
using FunctionalExtensions;

namespace MarsRover
{
    public class MarsRover : ValueObject
    {
        public Position Position { get; }

        public MarsRover(Position position) =>
            Position = position ?? throw new ArgumentNullException(nameof(position));

        public MarsRover Execute(string instructions)
        {
            Position currentPosition = Position;

            foreach (char instruction in instructions)
            {
                Position newPosition = currentPosition.Transform(instruction);
                if (newPosition == currentPosition)
                    break;

                currentPosition = newPosition;
            }

            return new MarsRover(currentPosition);
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Position;
        }

        public override string ToString() => 
            $"Position [{Position}]";
    }
}
