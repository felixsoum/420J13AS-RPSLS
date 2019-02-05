using Microsoft.VisualStudio.TestTools.UnitTesting;
using RPSLS;

namespace TestRPSLS
{
    [TestClass]
    public class TestGame
    {
        [TestInitialize]
        public void Initialize()
        {
            Game.IsLogging = false;
        }

        [TestMethod]
        public void TestBattleWin()
        {
            Assert.AreEqual(1, Game.Battle(new RockOnlyAI(), new ScissorsOnlyAI()));
        }

        [TestMethod]
        public void TestBattleLose()
        {
            Assert.AreEqual(-1, Game.Battle(new ScissorsOnlyAI(), new RockOnlyAI()));
        }

        [TestMethod]
        public void TestBattleTie()
        {
            Assert.AreEqual(0, Game.Battle(new RockOnlyAI(), new RockOnlyAI()));
        }
    }
}
