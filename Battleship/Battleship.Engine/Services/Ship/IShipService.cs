using Battleship.Engine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Engine.Services
{
    public interface IShipService
    {
        List<Ship> CreateShips(BoardSize boardSize, List<ShipSpecification> shipSpecifications);
    }
}
