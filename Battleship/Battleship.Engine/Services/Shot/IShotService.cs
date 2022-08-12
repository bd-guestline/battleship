using Battleship.Engine.Enums;
using Battleship.Engine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Engine.Services
{
    public interface IShotService
    {
        ShotResult CheckShot(List<Ship> ships, Position shotPosition, List<TakenShot> _takenShots);
    }
}
