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

        [TestMethod]
        public void TestNotExploredRoom()
        {
            //testing to see if not explored, number does not increase
            Cave.ExploredRoom(1);
            var explored = Cave.Explored;

            Assert.IsFalse(explored[0] == 2);
        }

        [TestMethod]
        public void CheckRoomAt1()
        {
            //testing to see if it sees what room you are in
            //also to test adjacent rooms
            Room room = Cave.RoomAt(1);

            Assert.AreEqual(room.Neighbors[0], -25);
            Assert.IsTrue(room.Number == 1);
        }

        [TestMethod]
        public void CheckRoomAt3()
        {
            //testing to see if it sees what room you are in
            //also to test adjacent rooms
            Room room = Cave.RoomAt(3);

            Assert.AreEqual(room.Neighbors[0], -27);
            Assert.IsTrue(room.Number == 3);
        }

        [TestMethod]
        public void NotInRoomAt1()
        {
            //testing to see if it sees you are in a different room
            Room room = Cave.RoomAt(1);

            Assert.IsFalse(room.Number == 3);
        }

        [TestMethod]
        public void NotInRoomAt3()
        {
            //testing to see if it sees you are in a different room
            Room room = Cave.RoomAt(3);

            Assert.IsFalse(room.Number == 1);
        }
    }
}
