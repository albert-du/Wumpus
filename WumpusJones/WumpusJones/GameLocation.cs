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
        }

        public string MovePlayer(int room)
        {
            var neighbors = cave.RoomAt(room).Neighbors;
            string value = "";
            foreach (var r in neighbors)
            {
                if (r == WumpusRoom)
                {
                    value += "Boulder nearby\n";
                }
                if (r == BatRoom)
                {
                    value += "Bat nearby\n";
                }
                if (r == HoleRoom)
                {
                    value += "Hole nearby\n";
                }
            }
            return value;
        }

        private void CreateHazards()
        {
            
        }
    }
}
