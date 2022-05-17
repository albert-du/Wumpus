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

        public GameLocation(Room p, Room w, Room b, Room h)
        {
            PlayerRoom = p;
            WumpusRoom = w;
            BatRoom = b;
            HoleRoom = h;
        }
        
        public void MovePlayer(Direction direction)
        {

        }
    }
}
