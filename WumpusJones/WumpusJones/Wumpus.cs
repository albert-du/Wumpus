using System;
using System.Collections.Generic;
using System.Linq;

namespace WumpusJones
{
    public class Wumpus
    {
        private int moving;

        public int Room { get; set; }
        
        protected Cave Cave { get; private set; }
        protected Random Random { get; } = new();
        protected IReadOnlyList<int> Travelable =>
            Cave.RoomAt(Room).Neighbors.Where(x => x > 0).ToList();

        public Wumpus(Cave cave) =>
            Cave = cave;

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
