using Battleship.Engine.Model;
using System.Collections.Generic;
using Xunit;
using FluentAssertions;

namespace Battleship.UnitTests
{
    public class ShipTests
    {
        [Theory]
        [MemberData(nameof(ShipContainsTestData))]
        public void ShipContains_ReturnValidData(Position shipStartPosition, Position shipEndPosition, Position position, bool shouldContain)
        {
            var ship = new Ship(shipStartPosition, shipEndPosition);

            var contains = ship.Contains(position);

            contains.Should().Be(shouldContain);
        }

        [Theory]
        [MemberData(nameof(ShipPositionsTestData))]
        public void ShipGetAllPositions_ReturnValidData(Position shipStartPosition, Position shipEndPosition, List<Position> positions)
        {
            var ship = new Ship(shipStartPosition, shipEndPosition);

            var shipPositions = ship.GetAllPositions();

            shipPositions.Should().BeEquivalentTo(positions);
        }
        [Theory]
        [MemberData(nameof(ShipCollidingTestData))]
        public void ShipIsColliding_ReturnValidData(Position shipStartPosition, Position shipEndPosition, Position secondShipStartPosition, Position secondShipEndPosition, bool shouldCollide)
        {
            var ship = new Ship(shipStartPosition, shipEndPosition);
            var secondShip = new Ship(secondShipStartPosition, secondShipEndPosition);

            var isColliding = ship.IsColiding(secondShip);

            isColliding.Should().Be(shouldCollide);
        }


        public static IEnumerable<object[]> ShipContainsTestData =>
            new List<object[]>
            {
                new object[] { new Position(1,5), new Position(1,2),  new Position(1,2), true},
                new object[] { new Position(1,2), new Position(1,5),  new Position(1,3), true},
                new object[] { new Position(1,2), new Position(1,5),  new Position(1,2), true},
                new object[] { new Position(1,2), new Position(1,5),  new Position(1,5), true},
                new object[] { new Position(1,2), new Position(1,5),  new Position(1,6), false},
                new object[] { new Position(1,2), new Position(1,5),  new Position(1,1), false},
                new object[] { new Position(1,2), new Position(1,5),  new Position(7,7), false},
                new object[] { new Position(1,2), new Position(5,2),  new Position(3,2), true},
                new object[] { new Position(1,2), new Position(5,2),  new Position(1,2), true},
                new object[] { new Position(1,2), new Position(5,2),  new Position(5,2), true},
                new object[] { new Position(1,2), new Position(5,2),  new Position(6,2), false},
                new object[] { new Position(1,2), new Position(5,2),  new Position(0,2), false},
                new object[] { new Position(1,2), new Position(5,2),  new Position(7,7), false},
            };

        public static IEnumerable<object[]> ShipPositionsTestData =>
            new List<object[]>
            {
                new object[] { new Position(1,2), new Position(1,5),  new List<Position>
                {
                    new Position(1,2),
                    new Position(1,3),
                    new Position(1,4),
                    new Position(1,5),
                }},
                new object[] { new Position(5,4), new Position(9,4),  new List<Position>
                {
                    new Position(5,4),
                    new Position(6,4),
                    new Position(7,4),
                    new Position(8,4),
                    new Position(9,4),
                }},
                new object[] { new Position(9,4), new Position(5,4),  new List<Position>
                {
                    new Position(5,4),
                    new Position(6,4),
                    new Position(7,4),
                    new Position(8,4),
                    new Position(9,4),
                }},
                new object[] { new Position(5,5), new Position(5,5),  new List<Position>
                {
                    new Position(5,5),
                }},
                new object[] { new Position(0,0), new Position(0,1),  new List<Position>
                {
                    new Position(0,0),
                    new Position(0,1),
                }},
            };
        public static IEnumerable<object[]> ShipCollidingTestData =>
            new List<object[]>
            {
                new object[] { new Position(1,2), new Position(1,5),  new Position(1,2), new Position(1, 5), true},
                new object[] { new Position(1,2), new Position(1,5),  new Position(1,5), new Position(1, 9), true},
                new object[] { new Position(1,2), new Position(1,5),  new Position(1,6), new Position(1, 9), false},
                new object[] { new Position(1,2), new Position(1,5),  new Position(1,0), new Position(1, 1), false},
                new object[] { new Position(1,2), new Position(1,5),  new Position(1,3), new Position(1, 4), true},
                new object[] { new Position(1,2), new Position(1,5),  new Position(1,3), new Position(1, 9), true},

                new object[] { new Position(1,2), new Position(5,2),  new Position(1,2), new Position(5,2), true},
                new object[] { new Position(1,2), new Position(5,2),  new Position(5,2), new Position(9,2), true},
                new object[] { new Position(1,2), new Position(5,2),  new Position(6,2), new Position(9,2), false},
                new object[] { new Position(1,2), new Position(5,2),  new Position(0,2), new Position(0,2), false},
                new object[] { new Position(1,2), new Position(5,2),  new Position(2,2), new Position(4,2), true},
                new object[] { new Position(1,2), new Position(5,2),  new Position(2,2), new Position(9,2), true},

                new object[] { new Position(1,2), new Position(5,2),  new Position(1,5), new Position(1,0), true},
                new object[] { new Position(1,2), new Position(5,2),  new Position(1,5), new Position(1,2), true},
                new object[] { new Position(1,2), new Position(5,2),  new Position(1,5), new Position(1,3), false},

                new object[] { new Position(1,2), new Position(5,2),  new Position(5,5), new Position(5,0), true},
                new object[] { new Position(1,2), new Position(5,2),  new Position(5,5), new Position(5,2), true},
                new object[] { new Position(1,2), new Position(5,2),  new Position(5,5), new Position(5,3), false},

                new object[] { new Position(1,2), new Position(5,2),  new Position(3,5), new Position(3,0), true},
                new object[] { new Position(1,2), new Position(5,2),  new Position(3,5), new Position(3,2), true},
                new object[] { new Position(1,2), new Position(5,2),  new Position(3,5), new Position(3,3), false},
            };
    }
}