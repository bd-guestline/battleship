using Battleship.Engine.Enums;
using Battleship.Engine.Extensions;
using Battleship.Engine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Engine.Services
{
    public class ShotService : IShotService
    {
        public ShotResult CheckShot(List<Ship> ships, Position shotPosition, List<TakenShot> _takenShots)
        {
            ShotResult shootResult = ShotResult.MISS;

            foreach (var ship in ships)
            {
                if (ship.Contains(shotPosition))
                {
                    _takenShots.Add(new TakenShot(shotPosition, true));

                    if (IsShipSunk(ship, _takenShots))
                    {
                        ship.IsSunk = true;

                        return IsGameOver(ships) ? ShotResult.HIT_AND_GAME_OVER : ShotResult.SUNK;
                    }

                    return ShotResult.HIT;
                }
            }

            _takenShots.Add(new TakenShot(shotPosition, false));
            return shootResult;
        }

        private bool IsShipSunk(Ship ship, List<TakenShot> _takenShots)
        {
            var shipPositons = ship.GetAllPositions();
            return shipPositons.TrueForAll(x => _takenShots.ContainsAsHit(x));
        }

        private bool IsGameOver(List<Ship> ships)
        {
            foreach (var ship in ships)
            {
                if (!ship.IsSunk)
                    return false;
            }
            return true;
        }
    }
}
