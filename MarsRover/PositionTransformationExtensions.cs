using System;

namespace MarsRover
{
    public static class PositionTransformationExtensions
    {
        public static Position Transform(this Position position, char transformation) =>
            transformation == 'f' || transformation == 'F'
                ? position.TranslateForwards()
            : transformation == 'b' || transformation == 'B'
                ? position.TranslateBackwards()
            : transformation == 'l' || transformation == 'L'
                ? position.FaceLeft()
            : transformation == 'r' || transformation == 'R'
                ? position.FaceRight()
            : throw new ArgumentException(nameof(transformation));

        private static Position TranslateForwards(this Position position) =>
            position.Translate(ForwardDelta(position.Direction));

        private static Position TranslateBackwards(this Position position) =>
            position.Translate(BackwardDelta(position.Direction));

        private static Position Translate(this Position position, (int x, int y) delta) =>
            position.Translate(delta.x, delta.y);

        private static (int dx, int dy) ForwardDelta(Direction direction) =>
            direction == Direction.North
                ? (0, 1)
            : direction == Direction.South
                ? (0, -1)
            : direction == Direction.East
                ? (1, 0)
            : direction == Direction.West
                ? (-1, 0)
            : throw new ArgumentException(nameof(direction));

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
