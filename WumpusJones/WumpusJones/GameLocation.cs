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
        public Room BatRoom { get; set; }
        public Room HoleRoom { get; set; }

        Random rnd = new Random();
        Cave cave;

        public GameLocation(Cave cave)
        {
            this.cave = cave;
        }
        
        public string MovePlayer(int room)
        {
            var neighbors = cave.Rooms[room - 1].Neighbors;
            string value = "";
            foreach (var r in neighbors)
            {
                if (r - 1 == WumpusRoom.Number)
                {
                    value += "Boulder nearby\n";
                }
                if (r - 1 == BatRoom.Number)
                {
                    value += "Bat nearby\n";
                }
                if (r - 1 == HoleRoom.Number)
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
