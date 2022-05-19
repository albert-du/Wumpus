using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WumpusJones
{
    class Cave
    {
        List<Room> roomExplored = new();

        public Cave()
        {
            AllRooms = new Room[]
            {
                new Room(1, 25, 26, 2, 7, 6, 30),
                new Room(2, 26, 3, 9, 8, 7, 1),
                new Room(3, 27, 28, 4, 9, 2, 26),
                new Room(4, 28, 5, 11, 10, 9, 3),
                new Room(5, 29, 30, 6, 11, 4, 28),
                new Room(6, 30, 1, 7, 12, 11, 5),
                new Room(7, 1, 2, 8, 13, 12, 6),
                new Room(8, 2, 9, 15, 14, 13, 7),
                new Room(9, 3, 4, 10, 15, 8, 2),
                new Room(10, 4, 11, 17, 16, 15, 9),
                new Room(11, 5, 6, 12, 17, 10, 4),
                new Room(12, 6, 7, 13, 18, 17, 11),
                new Room(13, 7, 8, 14, 19, 18, 12),
                new Room(14, 8, 15, 21, 20, 19, 13),
                new Room(15, 9, 10, 16, 21, 14, 8),
                new Room(16, 10, 17, 23, 22, 21, 15),
                new Room(17, 11, 12, 18, 23, 16, 10),
                new Room(18, 12, 13, 19, 24, 23, 17),
                new Room(19, 13, 14, 20, 25, 24, 18),
                new Room(20, 14, 21, 27, 26, 25, 19),
                new Room(21, 15, 16, 22, 27, 20, 14),
                new Room(22, 16, 23, 29, 28, 27, 21),
                new Room(23, 17, 18, 24, 29, 22, 16),
                new Room(24, 18, 19, 25, 30, 29, 23),
                new Room(25, 19, 20, 26, 1, 30, 24),
                new Room(26, 20, 27, 3, 2, 1, 25),
                new Room(27, 21, 22, 28, 3, 26, 20),
                new Room(28, 22, 29, 5, 4, 3, 27),
                new Room(29, 23, 24, 30, 5, 28, 22),
                new Room(30, 24, 25, 1, 6, 5, 29)
            };
        }
        public Room[] AllRooms { get; set; }
        

        public void ExploredRoom(Room room)
        {
            roomExplored.Add(room);
        }
    }
}
