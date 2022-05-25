using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WumpusJones
{
    class GameLocation
    {
        public int PlayerRoom { get; set; }
        public int WumpusRoom { get; set; }
        public int BatRoom { get; set; }
        public int HoleRoom { get; set; }

        Random rnd = new Random();
        Cave cave;

        public GameLocation(Cave cave)
        {
            this.cave = cave;
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

        public void CreateHazards()
        {
            int bat1 = rnd.Next(30) + 1;
            int bat2 = rnd.Next(30) + 1;
            int wumpus = rnd.Next(30) + 1;
            int hole = rnd.Next(30) + 1;

            WumpusRoom = cave.RoomAt(wumpus);
            BatRoom1 = cave.RoomAt(bat1);
            BatRoom2 = cave.RoomAt(bat2);
            HoleRoom = cave.RoomAt(hole);
        }

        public string MovePlayer(int room)
        {
            var neighbors = cave.RoomAt(room).Neighbors;
            string value = "";
            foreach (var r in neighbors)
            {
                if (r == WumpusRoom)
                {
                    value += "You sense something huge nearby\n";
                }
                if (r == BatRoom1.Number || r == BatRoom2)
                {
                    value += "Sounds of chittering bounce off the walls\n";
                }
                if (r == BatRoom1.Number && r == BatRoom2)
                {
                    value += "Sounds are louder than usual\n";
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
