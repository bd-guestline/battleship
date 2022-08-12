using Battleship.Engine.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Engine.Services
{
    public class BoardDrawer : IBoardDrawer
    {
        public void Draw(BoardSize boardSize, List<TakenShot> takenShots)
        {
            Console.WriteLine();
            Console.WriteLine("Taken shots:");
            Console.Write("    ");
            for (int j = 0; j < boardSize.X; j++)
            {
                Console.Write($"{j+1} ");
            }
            Console.WriteLine();
            for (int i = 0; i < boardSize.Y; i++)
            {
                Console.Write($"{(char)('A' + i)}   ");
                for (int j = 0; j < boardSize.X; j++)
                {
                    var shot = takenShots.FirstOrDefault(x => x.Position == new Position(j, i));

                    if (shot != null)
                    {
                        if (shot.IsHit)
                            Console.Write("o ");
                        else
                            Console.Write("x ");
                    }
                    else
                        Console.Write(". ");
                }

                Console.WriteLine();
            }
        }

        public void Draw(BoardSize boardSize, List<Ship> ships)
        {
            Console.WriteLine();
            Console.WriteLine("Ship positions:");
            Console.Write("    ");
            for (int j = 0; j < boardSize.X; j++)
            {
                Console.Write($"{j+1} ");
            }
            Console.WriteLine();
            for (int i = 0; i < boardSize.Y; i++)
            {
                Console.Write($"{(char)('A' + i)}   ");
                for (int j = 0; j < boardSize.X; j++)
                {

                    if (ships.Any(x => x.Contains(new Position(j, i))))
                        Console.Write("x ");
                    else
                        Console.Write(". ");
                }

                Console.WriteLine();
            }
        }
    }
}
