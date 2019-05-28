using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class Cell
    {
        private bool? _isNextGenAlive;
        private List<Cell> Neighbours { get; }

        public bool IsAlive { get; private set; }
        public bool IsDead => !IsAlive;

        private Cell(bool isAlive)
        {
            IsAlive = isAlive;
            Neighbours = new List<Cell>();
        }

        public static Cell Alive() =>
            new Cell(true);

        public static Cell Dead() =>
            new Cell(false);

        public static void Connect(Cell c1, Cell c2)
        {
            if (c1 == null)
                throw new ArgumentNullException(nameof(c1));

            if (c2 == null)
                throw new ArgumentNullException(nameof(c2));

            c1.Neighbours.Add(c2);
            c2.Neighbours.Add(c1);
        }

        internal void PrepareNextGen()
        {
            int numberOfAliveNeighbours = Neighbours.Count(cell => cell.IsAlive);

            _isNextGenAlive = IsAlive
                                  ? numberOfAliveNeighbours == 3 || numberOfAliveNeighbours == 2
                                  : numberOfAliveNeighbours == 3;
        }

        internal void NextGen()
        {
            IsAlive = _isNextGenAlive ?? false;

            _isNextGenAlive = null;
        }
    }
}
