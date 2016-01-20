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


        public IEnumerable<Tuple<int, int>> GetNeighbors(Tuple<int, int> cell)
        {
            var x = cell.Item1;
            var y = cell.Item2;

            if (cell.Item1 > 1)
                yield return new Tuple<int, int>(x - 1, y);

            if (cell.Item1 < Hight)
                yield return new Tuple<int, int>(x + 1, y);
        }


        public void SetCellValue(Tuple<int, int> cell, bool value)
        {
            storege[cell.Item1, cell.Item2] = value;
        }

        public bool? GetCellValue(Tuple<int, int> cell)
        {
            return storege[cell.Item1, cell.Item2];
        }
    }
}
