using Battleship.Engine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Engine.Extensions
{
    public static class TakenShotsExtension
    {
        public static bool ContainsAsHit(this List<TakenShot> takenShots, Position position)
        {
            return takenShots.Any(x => x.Position == position && x.IsHit);
        }
    }
}
