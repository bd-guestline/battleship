using Microsoft.Extensions.DependencyInjection;
using Battleship.Engine.Extensions;
using Battleship.Engine.Services;
using Microsoft.Extensions.Configuration;
using Battleship.Engine.Enums;

namespace BattleShip.Application
{
    internal static class BattleShipApp
    {
        internal static void Main(string[] args)
        {
            IConfiguration config = BuildConfiguration();
            ServiceProvider serviceProvider = BuildServiceProvider(config);
            var battleShipEngine = serviceProvider.GetService<IBattleshipEngine>();

            Console.WriteLine("Welcome to Battleship!");
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine();
                Console.Write("Provide shot position: ");
                var userShotPosition = Console.ReadLine();
                var shotResult = battleShipEngine?.Shoot(userShotPosition);

                if(shotResult == ShotResult.HIT)
                {
                    Console.WriteLine("Hit!");
                }
                else if (shotResult == ShotResult.MISS)
                {
                    Console.WriteLine("Miss!");
                }
                else if (shotResult == ShotResult.HIT_AND_GAME_OVER)
                {
                    Console.WriteLine("Hit! You won, congratulations!");
                    break;
                }
                else
                {
                    Console.WriteLine("Please provide valid input");
                }
            }
        }

        private static ServiceProvider BuildServiceProvider(IConfiguration config)
        {
            return new ServiceCollection()
                .AddBattleshipEngine(config)
                .BuildServiceProvider();
        }

        private static IConfiguration BuildConfiguration()
        {
            return new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        }
    }
}