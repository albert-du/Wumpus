using System;
using System.Linq;

namespace WumpusJones
{
    public class ActiveWumpus
    {
        public int Room { get; set; }

        private readonly Cave _cave;
        private readonly Random rnd = new();
        private bool isAwake;
        private int lostTrivia;
        private int turnsRemaining = 5;

        public ActiveWumpus(Cave cave)
        {
            _cave = cave;
        }

        private void MoveRandomly(int player)
        {
            var validMovements = _cave.RoomAt(Room).Neighbors.Where(x => x > 0 && x != player).ToList();
            if (validMovements.Count == 0) return;
            Room = validMovements.ElementAt(rnd.Next(validMovements.Count));
        }

        public void Turn(int player)
        {
            if (rnd.Next(0, 100) < 5)
            {
                do
                    Room = rnd.Next(0, 31);
                while (Room == player);
                return;
            }
            
            if (lostTrivia > 0)
            {
                lostTrivia--;
                var amount = rnd.Next(1, 3);
                for (var i = 0; i < amount; i++)
                    MoveRandomly(player);
                return;
            }
            if (isAwake)
                MoveRandomly(player);

            turnsRemaining--;
            if (turnsRemaining == 0)
            {
                isAwake = !isAwake;
                turnsRemaining = isAwake ? rnd.Next(1, 4) : rnd.Next(5, 11);
            }
        }

        public void LostTrivia() =>
            lostTrivia = 3;
    }
}
