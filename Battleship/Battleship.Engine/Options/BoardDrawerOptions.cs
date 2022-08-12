using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Engine.Options
{
    public class BoardDrawerOptions
    {
        public bool DrawTakenShots { get; set; } = true;
        public bool DrawShipPositions { get; set; } = false;
    }
}
