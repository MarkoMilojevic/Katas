using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class GameOfLife
    {
        private IEnumerable<Cell> Cells { get; }

        public GameOfLife(IEnumerable<Cell> cells) =>
            Cells = cells?.ToList() ?? throw new ArgumentNullException(nameof(cells));

        public void Next()
        {
            foreach (Cell cell in Cells)
                cell.PrepareNextGen();

            foreach (Cell cell in Cells)
                cell.NextGen();
        }
    }
}
