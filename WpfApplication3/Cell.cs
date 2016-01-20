using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication3
{
    public struct Cell
    {
        public int X;
        public int Y;
        public static Cell Take(int x, int y)
        {
            Cell cell;
            cell.X = x;
            cell.Y = y;
            return cell;
        }
    }


}
