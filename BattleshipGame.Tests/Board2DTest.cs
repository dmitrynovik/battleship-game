using System;
using BattleshipGame;
using NUnit.Framework;
using FluentAssertions;

namespace BattleshipGame.Tests
{
    [TestFixture]
    public class Board2DTest
    {
        [Test]
        public void Can_Add_Horizontal_Ship_To_Board_Within_Board_Bounds() => MakeBoard()
            .Add(new Ship(0, 0, Ship.Direction.Horizontal, 10))
            .Should().Be(true);

        [Test]
        public void Can_Add_Vertical_Ship_To_Board_Within_Board_Bounds() => MakeBoard()
            .Add(new Ship(0, 0, Ship.Direction.Vertical, 10))
            .Should().Be(true);

        [Test]
        public void Cannot_Add_Horizontal_Ship_To_Board_OutOf_X_Bounds() => MakeBoard()
            .Add(new Ship(1, 0, Ship.Direction.Horizontal, 10))
            .Should().Be(false);

        [Test]
        public void Cannot_Add_Vertical_Ship_To_Board_OutOf_X_Bounds() => MakeBoard()
            .Add(new Ship(10, 0, Ship.Direction.Vertical, 10))
            .Should().Be(false);

        [Test]
        public void Cannot_Add_Horizontal_Ship_To_Board_OutOf_Y_Bounds() => MakeBoard()
            .Add(new Ship(0, 10, Ship.Direction.Horizontal, 10))
            .Should().Be(false);

        [Test]
        public void Cannot_Add_Vertical_Ship_To_Board_OutOf_Y_Bounds() => MakeBoard()
            .Add(new Ship(0, 1, Ship.Direction.Vertical, 10))
            .Should().Be(false);


        private Board2D MakeBoard() => new SparseBoard2D();
    }
}
