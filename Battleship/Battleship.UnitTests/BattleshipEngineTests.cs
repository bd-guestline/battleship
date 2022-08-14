using Battleship.Engine.Model;
using Battleship.Engine.Services;
using System.Collections.Generic;
using Xunit;
using FluentAssertions;
using System.Linq;
using Moq;
using Microsoft.Extensions.Options;
using Battleship.Engine.Options;
using Battleship.Engine.Enums;

namespace Battleship.UnitTests
{
    public class BattleshipEngineTests
    {
        private readonly BattleshipEngine _engine;
        private readonly Mock<IShipService> _shipServiceMock;
        private readonly Mock<IShotService> _shootServiceMock;
        private readonly Mock<IBoardDrawer> _boardDrawerMock;

        public BattleshipEngineTests()
        {
            _shipServiceMock = new Mock<IShipService>();
            _shootServiceMock = new Mock<IShotService>();
            _boardDrawerMock = new Mock<IBoardDrawer>();

            var boardDrawerOptions = Options.Create(new BoardDrawerOptions
            {
                DrawTakenShots = false,
                DrawShipPositions = false
            });

            _engine = new BattleshipEngine(
                _shipServiceMock.Object,
                _shootServiceMock.Object,
                _boardDrawerMock.Object,
                boardDrawerOptions);
        }

        [Theory]
        [InlineData("A1")]
        [InlineData("A2")]
        [InlineData("A3")]
        [InlineData("A4")]
        [InlineData("A5")]
        [InlineData("A6")]
        [InlineData("A7")]
        [InlineData("A8")]
        [InlineData("A9")]
        [InlineData("A10")]
        [InlineData("a10")]
        [InlineData("B5")]
        [InlineData("C5")]
        [InlineData("D5")]
        [InlineData("E5")]
        [InlineData("F5")]
        [InlineData("H5")]
        [InlineData("I5")]
        [InlineData("J5")]
        public void Shoot_WithValidInput(string input)
        {
            _shootServiceMock
                .Setup(s =>
                    s.CheckShot(It.IsAny<List<Ship>>(), It.IsAny<Position>(), It.IsAny<List<TakenShot>>()))
                .Returns(ShotResult.HIT);

            var shotResult = _engine.Shoot(input);
            shotResult.Should().Be(ShotResult.HIT);
        }

        [Theory]
        [InlineData("A0")]
        [InlineData("A11")]
        [InlineData("A99")]
        [InlineData("4a")]
        [InlineData("")]
        [InlineData("A")]
        [InlineData("7")]
        [InlineData("K9")]
        [InlineData("L6")]
        [InlineData("X2")]
        [InlineData("--")]
        [InlineData("A12")]
        [InlineData("AAAAA12")]
        public void Shoot_WithInvalidInput(string input)
        {
            _shootServiceMock
                .Setup(s =>
                    s.CheckShot(It.IsAny<List<Ship>>(), It.IsAny<Position>(), It.IsAny<List<TakenShot>>()))
                .Returns(ShotResult.HIT);

            var shotResult = _engine.Shoot(input);
            shotResult.Should().BeNull();
        }
    }
}
