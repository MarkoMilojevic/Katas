namespace MarsRover
{
    public static class IntExtensions
    {
        public static int Mod(this int n, int m) =>
            (n %= m) < 0 ? n + m : n;
    }
}
