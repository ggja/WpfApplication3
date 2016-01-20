using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication3
{
    public partial class ModelActor
    {
        private const int Hight = 100;
        private const int Width = 100;
        private bool?[,] storege = new bool?[Hight, Width];


        public IEnumerable<Cell> GetNeighbors(Cell cell)
        {
            var x = cell.X;
            var y = cell.Y;

            if (cell.X > 1)
                yield return Cell.Take(x - 1, y);

            if (cell.Y < Hight)
                yield return Cell.Take(x + 1, y);
        }


        public void SetCellValue(Cell cell, bool value)
        {
            storege[cell.X, cell.Y] = value;
        }

        public bool? GetCellValue(Cell cell)
        {
            return storege[cell.X, cell.Y];
        }
    }
}
