using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WumpusJones;


namespace WumpusJones.Tests
{
    [TestClass]
    public class PlayerTest
    {
        [TestMethod]
        public void TestShootArrows()
        {
            Player player = new Player();
            player.ShootArrows();

            Assert.AreEqual(player.Arrows, 2);
        }
        public void TestArrowPurchase()
        {
            Player player = new Player();
            player.ArrowPurchase();

            Assert.AreEqual(player.Arrows, 5);
        }
        public void TestSecretPurchase()
        {
            Player player = new Player();
            player.SecretPurchase();
            Assert.AreEqual(player.Secrets, 1);
        }
        public void TestTurn()
        {
            Player player = new Player();
            player.Turn();
            Assert.AreEqual(player.Turns, 1);
        }
    }
}
