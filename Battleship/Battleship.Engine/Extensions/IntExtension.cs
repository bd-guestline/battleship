using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Engine.Extensions
{
    public static class IntExtension
    {
        public static bool InRange(this int number, int startRange, int endRange)
        {
            if (Math.Min(startRange, endRange) <= number &&
                    number <= Math.Max(startRange, endRange))
            {
                return true;
            }

            return false;
        }
    }
}
