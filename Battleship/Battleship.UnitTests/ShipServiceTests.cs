using Battleship.Engine.Model;
using Battleship.Engine.Services;
using System.Collections.Generic;
using Xunit;
using FluentAssertions;
using System.Linq;

namespace Battleship.UnitTests
{
    public class ShipServiceTests
    {
        private readonly ShipService _shipService;
        
        public ShipServiceTests()
        {
            _shipService = new ShipService();
            
        }

        [Theory]
        [MemberData(nameof(GenerateShipsTestData))]
        public void GenerateShip_ReturnsValidShips(BoardSize boardSize, List<ShipSpecification> shipSpecifications)
        {
            var ships = _shipService.CreateShips(boardSize, shipSpecifications);

            foreach(var shipSpecification in shipSpecifications)
            {
                var numberOfShips = ships.Count(x => x.ShipLength == shipSpecification.Length);
                numberOfShips.Should().Be(shipSpecification.NumberOfShips);
            }
        }

        public static IEnumerable<object[]> GenerateShipsTestData =>
           new List<object[]>
           {
                new object[] {
                    new BoardSize(5, 5),
                    new List<ShipSpecification>
                    {
                        new ShipSpecification(4, 1),
                    }
                },
                new object[] {
                    new BoardSize(10, 10), 
                    new List<ShipSpecification>
                    {
                        new ShipSpecification(5, 1),
                        new ShipSpecification(4, 2),
                    } 
                },

                new object[] {
                    new BoardSize(10, 10),
                    new List<ShipSpecification>
                    {
                        new ShipSpecification(5, 2),
                    }
                },
                new object[] {
                    new BoardSize(100, 100),
                    new List<ShipSpecification>
                    {
                        new ShipSpecification(5, 15),
                        new ShipSpecification(4, 10),
                        new ShipSpecification(3, 1),
                    }
                }
           };
    }
}
