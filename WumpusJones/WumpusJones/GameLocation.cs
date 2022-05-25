using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WumpusJones
{
    class GameLocation
    {
        public Room PlayerRoom { get; set; }
        public Room WumpusRoom { get; set; }
        public Room BatRoom1 { get; set; }
        public Room BatRoom2 { get; set; }
        public Room HoleRoom { get; set; }

        Random rnd = new Random();
        Cave cave;

        public GameLocation(Cave cave)
        {
            this.cave = cave;
        }

        public void CreateHazards()
        {
            int bat1 = rnd.Next(30) + 1;
            int bat2 = rnd.Next(30) + 1;
            int wumpus = rnd.Next(30) + 1;
            int hole = rnd.Next(30) + 1;

            WumpusRoom = cave.Rooms[wumpus - 1];
            BatRoom1 = cave.Rooms[bat1 - 1];
            BatRoom2 = cave.Rooms[bat2 - 1];
            HoleRoom = cave.Rooms[hole - 1];
        }

        public string MovePlayer(int room)
        {
            var neighbors = cave.Rooms[room - 1].Neighbors;
            string value = "";
            foreach (var r in neighbors)
            {
                if (r - 1 == WumpusRoom.Number)
                {
                    value += "You sense something huge nearby\n";
                }
                if (r - 1 == BatRoom1.Number || r - 1 == BatRoom2.Number)
                {
                    value += "Sounds of chittering bounce off the walls\n";
                }
                if (r - 1 == BatRoom1.Number && r - 1 == BatRoom2.Number)
                {
                    value += "Sounds are louder than usual\n";
                }
                if (r - 1 == HoleRoom.Number)
                {
                    value += "A draft blows through the room\n";
                }
            }
            return value;
        }
    }
}
