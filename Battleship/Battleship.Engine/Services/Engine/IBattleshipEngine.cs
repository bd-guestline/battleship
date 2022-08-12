using Battleship.Engine.Enums;
using Battleship.Engine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Engine.Services
{
    public interface IBattleshipEngine
    {
        ShotResult? Shoot(string? shotPosition);
        BoardSize BoardSize { get; }
        List<TakenShot> TakenShots { get; }
        List<ShipSpecification> ShipSpecifications { get; }
    }
}
