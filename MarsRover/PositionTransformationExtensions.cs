using System;

namespace MarsRover
{
    public static class PositionTransformationExtensions
    {
        public static Position Transform(this Position position, char instruction)
        {
            switch (instruction)
            {
                case 'f':
                    return position.TranslateForwards();

                case 'b':
                    return position.TranslateBackwards();

                case 'l':
                    return position.FaceLeft();

                case 'r':
                    return position.FaceRight();

                default:
                    throw new ArgumentException(nameof(instruction));
            }
        }

        private static Position TranslateForwards(this Position position)
        {
            (int dx, int dy) = ForwardDelta(position.Direction);

            return position.Translate(dx, dy);
        }

        private static Position TranslateBackwards(this Position position)
        {
            (int dx, int dy) = BackwardDelta(position.Direction);

            return position.Translate(dx, dy);
        }

        private static (int dx, int dy) ForwardDelta(Direction direction)
        {
            if (direction == Direction.North)
                return (0, 1);

            if (direction == Direction.South)
                return (0, -1);

            if (direction == Direction.East)
                return (1, 0);

            if (direction == Direction.West)
                return (-1, 0);

            throw new ArgumentException();
        }

        private static (int dx, int dy) BackwardDelta(Direction direction)
        {
            (int dx, int dy) = ForwardDelta(direction);

            return (-dx, -dy);
        }
        private static Position FaceLeft(this Position position) =>
            position.Face(Direction.Left[position.Direction]);

        private static Position FaceRight(this Position position) =>
            position.Face(Direction.Right[position.Direction]);
    }
}
