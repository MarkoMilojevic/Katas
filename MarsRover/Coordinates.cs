using System;
using System.Collections.Generic;
using FunctionalExtensions;

namespace MarsRover
{
    public sealed class Coordinates : ValueObject
    {
        public int X { get; }
        public int Y { get; }

        public Coordinates(int x, int y)
        {
            if (x < 0)
                throw new ArgumentOutOfRangeException(nameof(x));

            if (y < 0)
                throw new ArgumentOutOfRangeException(nameof(y));

            X = x;
            Y = y;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return X;
            yield return Y;
        }

        public override string ToString() =>
            $"X: {X}, Y: {Y}";
    }
}
