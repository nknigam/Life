using Microsoft.VisualStudio.TestTools.UnitTesting;
using Life.Entities;
using System.Threading;

namespace LifeGameUnitTest
{
    [TestClass]
    public class LifeGameTest
    {
        [TestMethod]
        public void InActiveCellWhenLifeNotGiven()
        {
            Board b = new Board(2,2);

            Assert.IsFalse(b.IsCellExist(1, 1));
        }

        [TestMethod]
        public void IsCellExistWhenAdded()
        {
            Board b = new Board(2,2);

            b.GiveLife(1, 1);

            Assert.IsTrue(b.IsCellExist(1, 1));
        }


        [TestMethod]
        public void ShouldBeActiveWhenLifeGivenTwoTimesToSameCell()
        {
            Board b = new Board(2,2);

            b.GiveLife(1, 1);
            b.GiveLife(1, 1);

            Assert.IsTrue(b.IsCellExist(1, 1));
        }

        [TestMethod]
        public void ShouldCellDieWhenIsLonely()
        {
            Game game = new Game(2, 2);

            game.GameBoard.GiveLife(1, 1);
            game.ProcessNextGeneration();
            Thread.Sleep(10);

            Assert.IsFalse(game.GameBoard.IsCellExist(1, 1));
        }

        [TestMethod]
        public void ShouldLivingCellStillLiveWhenTwoNeighbours()
        {
            // test for two neighbours
            Game game = new Game(5,5);
            Board b = game.GameBoard;

            b.GiveLife(2, 2);
            b.GiveLife(3, 2);
            b.GiveLife(2, 3);
            game.ProcessNextGeneration();

            Assert.IsTrue(b.IsCellExist(2, 2));
        }

     
        [TestMethod]
        public void ShouldLiveCellStillLiveWhenThreeNeighbours()
        {
            // test for two neighbours
            Game game = new Game(5,5);
            Board b = game.GameBoard;

            b.GiveLife(2, 2);
            b.GiveLife(3, 2);
            b.GiveLife(2, 3);
            b.GiveLife(3, 3);
            game.ProcessNextGeneration();

            Assert.IsTrue(b.IsCellExist(2, 2));
        }

        [TestMethod]
        public void ShouldLivingCellDieWhenHasLessThanTwoNeighbours()
        {
            Game game = new Game(5, 5);

            game.GameBoard.GiveLife(2, 2);
            game.GameBoard.GiveLife(3, 2);
            game.ProcessNextGeneration();
            Thread.Sleep(10);

            //cell should die, if less than 2 Neighbour
            Assert.IsFalse(game.GameBoard.IsCellExist(2, 2));
        }

        [TestMethod]
        public void ShouldLivingCellDieWhenHasMoreThanThreeNeighbours()
        {
            Game game = new Game(5, 5);
            Board b = game.GameBoard;

            b.GiveLife(2, 2);
            b.GiveLife(3, 2);
            b.GiveLife(2, 3);
            b.GiveLife(3, 3);
            b.GiveLife(1, 3);
            game.ProcessNextGeneration();
            Thread.Sleep(10);

            Assert.IsFalse(game.GameBoard.IsCellExist(2, 2));
        }

    }
}
