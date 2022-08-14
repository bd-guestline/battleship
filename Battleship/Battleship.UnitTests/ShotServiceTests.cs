using Battleship.Engine.Model;
using Battleship.Engine.Services;
using System.Collections.Generic;
using Xunit;
using FluentAssertions;
using System.Linq;

namespace Battleship.UnitTests
{
    public class ShotServiceTests
    {
        private readonly ShotService _shotService;
        private readonly Ship _ship;
        private readonly Ship _secondShip;

        private readonly List<TakenShot> _takenShots_OneShotMissing;
        private readonly List<TakenShot> _takenShots_TwoShotsMissing;
        public ShotServiceTests()
        {
            _shotService = new ShotService();
            _ship = new Ship(new Position(0, 0), new Position(5, 0));
            _secondShip = new Ship(new Position(7, 7), new Position(7, 8));

            _takenShots_TwoShotsMissing = new List<TakenShot>()
            {
                new TakenShot(new Position(0, 0), true),
                new TakenShot(new Position(1, 0), true),
                new TakenShot(new Position(2, 0), true),
                new TakenShot(new Position(3, 0), true),
            };

            _takenShots_OneShotMissing = new List<TakenShot>(_takenShots_TwoShotsMissing)
                .Append(new TakenShot(new Position(4, 0), true)).ToList();
        }

        [Fact]
        public void ShootNotOnShipPosition_ShouldBeMiss()
        {
            var shotResult = _shotService.CheckShot(
                new List<Ship> { _ship },
                new Position(6,0),
                new List<TakenShot>());

            shotResult.Should().Be(Engine.Enums.ShotResult.MISS);
        }

        [Fact]
        public void ShootOnShipPosition_ShouldBeHit()
        {

            var shotResult = _shotService.CheckShot(
                new List<Ship> { _ship },
                new Position(0, 0), 
                _takenShots_TwoShotsMissing);

            shotResult.Should().Be(Engine.Enums.ShotResult.HIT);
        }

        [Fact]
        public void ShootOnShipLastPosition_ShouldBeGameOver()
        {
            var shotResult = _shotService.CheckShot(
                new List<Ship> { _ship },
                new Position(5, 0),
                _takenShots_OneShotMissing);

            shotResult.Should().Be(Engine.Enums.ShotResult.HIT_AND_GAME_OVER);
        }

        [Fact]
        public void ShootOnShipLastPosition_WithOtherShipSunk_ShouldBeGameOver()
        {            
            _secondShip.IsSunk = true;

            var shotResult = _shotService.CheckShot(
                new List<Ship> { _ship, _secondShip },
                new Position(5, 0), 
                _takenShots_OneShotMissing);

            shotResult.Should().Be(Engine.Enums.ShotResult.HIT_AND_GAME_OVER);
        }

        [Fact]
        public void ShootOnShipLastPosition_WithOtherShipNotSunk_ShouldNotBeGameOver()
        {
            _secondShip.IsSunk = false;

            var shotResult = _shotService.CheckShot(
                new List<Ship> { _ship, _secondShip },
                new Position(5, 0),
                _takenShots_OneShotMissing);

            shotResult.Should().Be(Engine.Enums.ShotResult.HIT);
        }
    }
}
