using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLife
{
    public class MatrixGameOfLife
    {
        private Cell[][] Cells { get; }
        private GameOfLife Game { get; }

        public MatrixGameOfLife(int size, params (int x, int y)[] aliveAt)
        {
            var c = new List<Cell>();

            Cells = new Cell[size][];
            for (int i = 0; i < size; i++)
                Cells[i] = new Cell[size];

            HashSet<(int x, int y)> aliveAtSet = aliveAt.ToHashSet();

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Cells[i][j] = aliveAtSet.Contains((i, j))
                                      ? Cell.Alive()
                                      : Cell.Dead();

                    c.Add(Cells[i][j]);
                }
            }


            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Cell.Connect(Cells[i][j], Cells[i][(j + 1).Mod(size)]);
                    Cell.Connect(Cells[i][j], Cells[(i + 1).Mod(size)][j]);
                    Cell.Connect(Cells[i][j], Cells[(i + 1).Mod(size)][(j + 1).Mod(size)]);
                    Cell.Connect(Cells[i][j], Cells[(i + 1).Mod(size)][(j - 1).Mod(size)]);
                }
            }

            Game = new GameOfLife(c);
        }

        public void Next() =>
            Game.Next();

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (Cell[] row in Cells)
            {
                foreach (Cell cell in row)
                    sb.Append(cell.IsAlive ? "\u2588" : " ");

                sb.AppendLine();
            }

            return sb.ToString();
        }
    }

    public static class IntExtension
    {
        public static int Mod(this int n, int m) =>
            (n %= m) < 0 ? n + m : n;
    }
}
