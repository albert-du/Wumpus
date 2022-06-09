using System;
using System.Collections.Generic;
using static WumpusJones.WumpusState;

namespace WumpusJones
{
    public class ActiveWumpus : Wumpus
    {
        private WumpusState state;
        private Asleep Sleep => new(Random.Next(5, 11));
        private Awake Wake => new(Random.Next(1, 4));
        private Defeated Defeat => new(Random.Next(1, 4), 2);

        public ActiveWumpus(IReadOnlyList<Room> cave, Random random) : base(cave, random) =>
            state = Sleep;

        public override void ArrowMissed() =>
            state = Wake;

        public override void TriviaLost() =>
            state = Defeat;

        public override void WumpusTurn()
        {
            if (Random.Next(0,100) < 5)
                Room = Random.Next(0, 31);
            
            switch (state)
            {
                case (Defeated defeated):
                    var r = Random.Next(defeated.Speed + 1);
                    for (var i = 0; i < r; i++)
                        MoveRandomly();
                    break;
                case (Awake):
                    MoveRandomly();
                    break;
            }

            state = state switch
            {
                _ when state.Duration > 1 => state with { Duration = state.Duration - 1 },
                Asleep or Defeated => Wake,
                Awake => Sleep,
                _ => state
            };
        }
    }
}
