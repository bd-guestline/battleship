using Battleship.Engine.Enums;
using Battleship.Engine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Engine.Services
{
    public class ShipService : IShipService
    {
        private readonly Random random = new Random();

        public List<Ship> CreateShips(BoardSize boardSize, List<ShipSpecification> shipSpecifications)
        {
            List<Ship> resultShips = new List<Ship>();

            foreach (var shipSpec in shipSpecifications)
            {
                for (int i = 0; i < shipSpec.NumberOfShips; i++)
                {
                    Ship ship;
                    do
                    {
                        ship = GenerateShip(boardSize, shipSpec.Length);
                    }
                    while (resultShips.Any(x => x.IsColiding(ship)));

                    resultShips.Add(ship);
                }
            }

            return resultShips;
        }

        private Ship GenerateShip(BoardSize boardSize, int shipLength)
        {
            Array values = Enum.GetValues(typeof(ShipType));
            ShipType shipType = (ShipType)values.GetValue(random.Next(values.Length))!;

            if (shipType == ShipType.HORIZONTAL)
            {
                var x = random.Next(boardSize.X - shipLength + 1);
                var y = random.Next(boardSize.Y);

                return new Ship(new Position(x, y), new Position(x + shipLength - 1, y));
            }
            else
            {
                var x = random.Next(boardSize.X);
                var y = random.Next(boardSize.Y - shipLength + 1);

                return new Ship(new Position(x, y), new Position(x, y + shipLength - 1));
            }
        }
    }
}
