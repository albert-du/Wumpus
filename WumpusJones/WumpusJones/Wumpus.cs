using System;
using System.Collections.Generic;
using System.Linq;

namespace WumpusJones
{
    public class Wumpus
    {
        private int moving;

        public int Room { get; set; }
        
        protected IReadOnlyList<Room> Cave { get; private set; }
        protected Random Random { get; }
        protected IReadOnlyList<int> Travelable =>
            Cave[Room - 1].Neighbors.Where(x => x > 0).ToList();

        public Wumpus(IReadOnlyList<Room> cave, Random random)
        {
            Cave = cave;
            Random = random;
        }

        protected void MoveRandomly() =>
            Room = Travelable[Random.Next(Travelable.Count)];

        public virtual void ArrowMissed() =>
            moving += Random.Next(1, 3);

        public virtual void TriviaLost() =>
            moving += Random.Next(1, 4);

        public virtual void WumpusTurn()
        {
            if (moving == 0)
                return;
            moving--;
            MoveRandomly();
        }
    }
}
