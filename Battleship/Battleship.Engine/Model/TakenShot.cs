using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Engine.Model
{
    public class TakenShot
    {
        public Position? Position { get; set; }
        public bool IsHit { get; set; }

        public TakenShot(Position position, bool isHit)
        {
            Position = position;
            IsHit = isHit;
        }
    }
}
