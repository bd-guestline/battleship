using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Engine.Model
{
    public class Position
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj) => this.Equals(obj as Position);

        public bool Equals(Position? p)
        {
            if (p is null)
            {
                return false;
            }

            if (Object.ReferenceEquals(this, p))
            {
                return true;
            }

            if (this.GetType() != p.GetType())
            {
                return false;
            }

            return (X == p.X) && (Y == p.Y);
        }

        public override int GetHashCode() => (X, Y).GetHashCode();

        public static bool operator ==(Position? lhs, Position? rhs)
        {
            if (lhs is null)
            {
                if (rhs is null)
                {
                    return true;
                }

                return false;
            }

            return lhs.Equals(rhs);
        }

        public static bool operator !=(Position lhs, Position rhs) => !(lhs == rhs);
    }
}
