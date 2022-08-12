using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Engine.Model
{
    public class BoardSize
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public BoardSize(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
