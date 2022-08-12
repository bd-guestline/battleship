using Battleship.Engine.Services;
using Battleship.Engine.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Engine.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBattleshipEngine(this IServiceCollection services,
            IConfiguration config,
            string sectionName = "BoardDrawer")
        {
            services.Configure<BoardDrawerOptions>(options => config.GetSection(sectionName).Bind(options));
            services.AddScoped<IShipService, ShipService>();
            services.AddScoped<IShotService, ShotService>();
            services.AddScoped<IBoardDrawer, BoardDrawer>();
            services.AddScoped<IBattleshipEngine, BattleshipEngine>();

            return services;
        }
    }
}
