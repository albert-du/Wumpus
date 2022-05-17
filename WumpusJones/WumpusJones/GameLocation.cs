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

        public GameLocation(int p, int w, int b, int h)
        {
            PlayerRoom = p;
            WumpusRoom = w;
            BatRoom = b;
            HoleRoom = h;
        }
    }
}
