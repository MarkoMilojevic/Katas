using System;
using System.Collections.Generic;
using FunctionalExtensions;

namespace MarsRover
{
    public sealed class MarsRover : ValueObject
    {
        public Position Position { get; }

        public MarsRover(Position position) =>
            Position = position ?? throw new ArgumentNullException(nameof(position));

        public MarsRover Execute(string instructions)
        {
            Position position = Position;

            foreach (char instruction in instructions)
            {
                Position newPosition = position.Transform(instruction);
                if (newPosition == position)
                    break;

                position = newPosition;
            }

            return new MarsRover(position);
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Position;
        }

        public override string ToString() => 
            $"Position [{Position}]";
    }
}
