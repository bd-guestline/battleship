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

                switch(shotResult)
                {
                    case ShotResult.HIT:
                        Console.WriteLine("Hit!");
                        break;
                    case ShotResult.MISS:
                        Console.WriteLine("Miss!");
                        break;
                    case ShotResult.SUNK:
                        Console.WriteLine("Hit! Ship sunk!");
                        break;
                    case ShotResult.HIT_AND_GAME_OVER:
                        Console.WriteLine("Hit! You won, congratulations!");
                        return;
                    default:
                        Console.WriteLine("Please provide valid input");
                        break;
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