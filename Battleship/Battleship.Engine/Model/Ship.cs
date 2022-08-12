using Battleship.Engine.Enums;
using Battleship.Engine.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Engine.Model
{
    public class Ship
    {
        public Position StartPosition { get; private set; }
        public Position EndPosition { get; private set; }
        public bool IsSunk { get; set; }

        public ShipType ShipType
        {
            get
            {
                return StartPosition.Y == EndPosition.Y ? ShipType.HORIZONTAL : ShipType.VERTICAL;
            }
        }

        public int ShipLength
        {
            get
            {
                return ShipType == ShipType.VERTICAL ?
                    Math.Abs(EndPosition.Y - StartPosition.Y) + 1 :
                    Math.Abs(EndPosition.X - StartPosition.X) + 1;
            }
        }

        public Ship(Position startPosition, Position endPosition)
        {
            this.StartPosition = startPosition;
            this.EndPosition = endPosition;
            IsSunk = false;
        }

        public bool Contains(Position position)
        {
            return ShipType == ShipType.VERTICAL ?
                position.X == StartPosition.X && position.Y.InRange(StartPosition.Y, EndPosition.Y) :
                position.Y == StartPosition.Y && position.X.InRange(StartPosition.X, EndPosition.X);
        }

        public bool IsColiding(Ship ship)
        {
            return GetAllPositions().Intersect(ship.GetAllPositions()).Any();
        }

        public List<Position> GetAllPositions()
        {
            if (ShipType == ShipType.VERTICAL)
            {
                var yRange = Enumerable.Range(Math.Min(StartPosition.Y, EndPosition.Y), ShipLength);
                return yRange.Select(y => new Position(StartPosition.X, y)).ToList();
            }
            else
            {
                var xRange = Enumerable.Range(Math.Min(StartPosition.X, EndPosition.X), ShipLength);
                return xRange.Select(x => new Position(x, StartPosition.Y)).ToList();
            }
        }
    }
}
