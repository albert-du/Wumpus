using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WumpusJones;

namespace WumpusJonesCaveTests
{
    [TestClass]
    public class CaveTests
    {
        Cave Cave = new Cave(1);

        [TestMethod]
        public void TestExploredRoom()
        {
            //testing to see if explored goes up by 1 once
            //go into a room that hasn't been explored
            Cave.ExploredRoom(1);
            var explored = Cave.Explored;

            Assert.IsTrue(explored[0] == 1);
        }


    }
}
