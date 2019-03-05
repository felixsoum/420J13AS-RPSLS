using Microsoft.VisualStudio.TestTools.UnitTesting;
using RPSLS;

namespace TestRPSLS
{
    [TestClass]
    public class TestMoveComparator
    {
        [TestMethod]
        public void TestTie()
        {
            Assert.AreEqual(0, Move.Rock.CompareWith(Move.Rock));
            Assert.AreEqual(0, Move.Paper.CompareWith(Move.Paper));
            Assert.AreEqual(0, Move.Scissors.CompareWith(Move.Scissors));
            Assert.AreEqual(0, Move.Lizard.CompareWith(Move.Lizard));
            Assert.AreEqual(0, Move.Spock.CompareWith(Move.Spock));
        }

        [TestMethod]
        public void TestScissorsPaper()
        {
            Assert.AreEqual(1, Move.Scissors.CompareWith(Move.Paper));
            Assert.AreEqual(-1, Move.Paper.CompareWith(Move.Scissors));
        }

        [TestMethod]
        public void TestPaperRock()
        {
            Assert.AreEqual(1, Move.Paper.CompareWith(Move.Rock));
            Assert.AreEqual(-1, Move.Rock.CompareWith(Move.Paper));
        }

        [TestMethod]
        public void TestRockLizard()
        {
            Assert.AreEqual(1, Move.Rock.CompareWith(Move.Lizard));
            Assert.AreEqual(-1, Move.Lizard.CompareWith(Move.Rock));
        }

        [TestMethod]
        public void TestLizardSpock()
        {
            Assert.AreEqual(1, Move.Lizard.CompareWith(Move.Spock));
            Assert.AreEqual(-1, Move.Spock.CompareWith(Move.Lizard));
        }

        [TestMethod]
        public void TestSpockScissors()
        {
            Assert.AreEqual(1, Move.Spock.CompareWith(Move.Scissors));
            Assert.AreEqual(-1, Move.Scissors.CompareWith(Move.Spock));
        }

        [TestMethod]
        public void TestScissorsLizard()
        {
            Assert.AreEqual(1, Move.Scissors.CompareWith(Move.Lizard));
            Assert.AreEqual(-1, Move.Lizard.CompareWith(Move.Scissors));
        }

        [TestMethod]
        public void TestLizardPaper()
        {
            Assert.AreEqual(1, Move.Lizard.CompareWith(Move.Paper));
            Assert.AreEqual(-1, Move.Paper.CompareWith(Move.Lizard));
        }

        [TestMethod]
        public void TestPaperSpock()
        {
            Assert.AreEqual(1, Move.Paper.CompareWith(Move.Spock));
            Assert.AreEqual(-1, Move.Spock.CompareWith(Move.Paper));
        }

        [TestMethod]
        public void TestSpockRock()
        {
            Assert.AreEqual(1, Move.Spock.CompareWith(Move.Rock));
            Assert.AreEqual(-1, Move.Rock.CompareWith(Move.Spock));
        }

        [TestMethod]
        public void TestRockScissors()
        {
            Assert.AreEqual(1, Move.Rock.CompareWith(Move.Scissors));
            Assert.AreEqual(-1, Move.Scissors.CompareWith(Move.Rock));
        }

        [TestMethod]
        public void TestInvalid()
        {
            Move invalid = (Move)(-1);
            Assert.AreEqual(0, invalid.CompareTo(invalid));
            Assert.AreEqual(1, Move.Rock.CompareTo(invalid));
            Assert.AreEqual(-1, invalid.CompareTo(Move.Rock));
        }
    }
}
