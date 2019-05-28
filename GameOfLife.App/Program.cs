using System;
using System.Collections.Generic;
using System.Threading;

namespace GameOfLife.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var lightweightSpaceship = new (int x, int y)[]
            {
                (14, 0),
                (14, 3),
                (15, 4),
                (16, 0),
                (16, 4),
                (17, 1),
                (17, 2),
                (17, 3),
                (17, 4)
            };

            var acorn = new (int x, int y)[]
            {
                (14, 6),
                (15, 8),
                (16, 5),
                (16, 6),
                (16, 9),
                (16, 10),
                (16, 11)
            };

            var game = new MatrixGameOfLife(30, acorn);

            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write(game);
            Thread.Sleep(200);

            while (true)
            {
                Console.Clear();
                game.Next();
                Console.Write(game);
                Thread.Sleep(200);
            }
        }
    }
}
