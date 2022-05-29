using System;
using System.Linq;

namespace WumpusJones
{
    public class GameLocation
    {
        public int PlayerRoom { get; set; } = new Random().Next(1, 31);
        public int StartingRoom { get; }
        public int WumpusRoom { get; set; }
        public int BatRoom1 { get; set; }
        public int BatRoom2 { get; set; }
        public int HoleRoom { get; set; }

        Random rnd = new Random();
        Cave cave;

        public GameLocation(Cave cave)
        {
            this.cave = cave;
            cave.ExploredRoom(PlayerRoom);
            StartingRoom = PlayerRoom;
        }

        /// <summary>
        /// Moves the boulder (wumpus) 2 caves over
        /// </summary>
        public void RandomizeWumpus()
        {
            var validMovements = cave.RoomAt(WumpusRoom).Neighbors.Where(x => x > 0).ToList();
            int next = 0;
            while (next == 0 || next == PlayerRoom)
                next = validMovements.ElementAt(rnd.Next(validMovements.Count));

            validMovements = cave.RoomAt(next).Neighbors.Where(x => x > 0).ToList();
            next = 0;
            while (next == 0 || next == PlayerRoom)
                next = validMovements.ElementAt(rnd.Next(validMovements.Count));

            WumpusRoom = next;
        }
        public void CreateHazards()
        {
            List<int> rooms = new() { PlayerRoom };
            while (rooms.Count < 5)
            {
                var r = rnd.Next(1, 31);
                if (!rooms.Contains(r))
                    rooms.Add(r);
            }
            WumpusRoom = rooms[1];
            BatRoom1 = rooms[2];
            BatRoom2 = rooms[3];
            HoleRoom = rooms[4];
        }

        public string MovePlayer(int room)
        {
            PlayerRoom = room;
            cave.ExploredRoom(PlayerRoom);
            var neighbors = cave.RoomAt(room).Neighbors;
            string value = "";
            foreach (var r in neighbors)
            {
                if (r == WumpusRoom)
                {
                    value += "You sense something huge nearby\n";
                }
                if (r == BatRoom1 || r == BatRoom2)
                {
                    value += "Sounds of chittering bounce off the walls\n";
                }
                if (r == BatRoom1 && r == BatRoom2)
                {
                    value += "The sounds are louder than usual\n";
                }
                if (r == HoleRoom)
                {
                    value += "A draft blows through the room\n";
                }
            }
            return value;
        }
    }
}
