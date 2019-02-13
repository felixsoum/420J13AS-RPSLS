using Microsoft.VisualStudio.TestTools.UnitTesting;
using RPSLS;

namespace TestRPSLS
{
    [TestClass]
    public class TestGame
    {
        Game game;

        [TestInitialize]
        public void Initialize()
        {
            game = Game.Create<RockOnlyAI>();
            game.IsLogging = false;
        }

        [TestCleanup]
        public void Cleanup()
        {
            game.End();
        }

        [TestMethod]
        public void TestBattleWin()
        {
            Assert.AreEqual(1, game.Battle<ScissorsOnlyAI>());
        }

        [TestMethod]
        public void TestBattleLose()
        {
            Assert.AreEqual(-1, game.Battle<PaperOnlyAI>());
        }

        [TestMethod]
        public void TestBattleTie()
        {
            Assert.AreEqual(0, game.Battle<RockOnlyAI>());
        }
    }
}
