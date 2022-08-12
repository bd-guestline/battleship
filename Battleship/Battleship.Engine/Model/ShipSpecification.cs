using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Engine.Model
{
    public class ShipSpecification
    {
        public int Length { get; private set; }
        public int NumberOfShips { get; private set; }

        public ShipSpecification(int length, int numberOfShips)
        {
            Length = length;
            NumberOfShips = numberOfShips;
        }
    }
}
