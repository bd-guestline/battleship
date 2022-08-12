using Battleship.Engine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Engine.Services
{
    public interface IBoardDrawer
    {
        void Draw(BoardSize boardSize, List<TakenShot> takenShots);
        void Draw(BoardSize boardSize, List<Ship> ships);
    }
}
