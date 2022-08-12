using Battleship.Engine.Enums;
using Battleship.Engine.Model;
using Battleship.Engine.Options;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Engine.Services
{
    public class BattleshipEngine : IBattleshipEngine
    {
        private readonly IShipService _shipService;
        private readonly IShotService _shootService;
        private readonly IBoardDrawer _boardDrawer;
        private readonly IOptions<BoardDrawerOptions> _boardDrawerOptions;

        private readonly List<Ship> _ships;

        private readonly BoardSize _boardSize = new BoardSize(10, 10);
        public BoardSize BoardSize => _boardSize;

        private readonly List<TakenShot> _takenShots = new List<TakenShot>();
        public List<TakenShot> TakenShots => _takenShots;

        private readonly List<ShipSpecification> _shipSpecifications = new List<ShipSpecification>
        {
            new ShipSpecification(5, 1),
            new ShipSpecification(4, 2)
        };
        public List<ShipSpecification> ShipSpecifications => _shipSpecifications;

        private const char boardStartY = 'a';

        public BattleshipEngine(
            IShipService shipService,
            IShotService shootService,
            IBoardDrawer boardDrawer,
            IOptions<BoardDrawerOptions> boardDrawerOptions)
        {
            _shipService = shipService;
            _shootService = shootService;
            _boardDrawer = boardDrawer;
            _boardDrawerOptions = boardDrawerOptions;

            _ships = _shipService.CreateShips(_boardSize, _shipSpecifications);

            DrawBoard(true);

        }

        private void DrawBoard(bool isFirstDraw = false)
        {
            if (_boardDrawerOptions.Value.DrawTakenShots && !isFirstDraw)
            {
                _boardDrawer.Draw(_boardSize, _takenShots);
            }
            if (_boardDrawerOptions.Value.DrawShipPositions)
            {
                _boardDrawer.Draw(_boardSize, _ships);
            }
        }

        public ShotResult? Shoot(string? shotPosition)
        {
            var position = ParseInputPosition(shotPosition);
            if (position == null)
            {
                return null;
            }

            var result = Shoot(position);

            DrawBoard();

            return result;
        }

        private Position? ParseInputPosition(string? position)
        {
            if(string.IsNullOrEmpty(position) || position.Length < 2)
            {
                return null;
            }

            var y = position.ToLower()[0] - boardStartY;
            if (!int.TryParse(position.Substring(1), out var x) ||
                y < 0 || y >= _boardSize.Y || x - 1 < 0 || x - 1 >= _boardSize.X)
            {
                return null;
            }

            return new Position(x - 1, y);
        }

        private ShotResult Shoot(Position shotPosition)
        {
            var y = _shootService.CheckShot(_ships, shotPosition, _takenShots);

            return y;
        }
    }
}
