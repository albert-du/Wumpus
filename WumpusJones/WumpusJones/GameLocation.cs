using System;
using System.Collections.Generic;
using System.Linq;

namespace WumpusJones
{
    public class GameLocation
    {
        public int StartingRoom { get; }
        public int PlayerRoom { get; set; }
        public int WumpusRoom { get; set; }
        public int BatRoom1 { get; set; }
        public int BatRoom2 { get; set; }
        public int HoleRoom { get; set; }

        private readonly Random rnd;
        private readonly IReadOnlyList<Room> cave;

        public GameLocation(IReadOnlyList<Room> cave, Random random)
        {
            rnd = random;
            this.cave = cave;
            PlayerRoom = rnd.Next(1, 31);
            StartingRoom = PlayerRoom;
            CreateHazards();
        }

        public bool IsWumpusNearby =>
            cave[WumpusRoom - 1].Neighbors
                .Where(x => x > 0)
                .Any(x => cave[x - 1].Neighbors
                          .Where(x => x > 0)
                          .Any(x => x == PlayerRoom));

        public void RandomizePlayer()
        {
            var room = 0;
            while (room == 0 || room == BatRoom1 || room == BatRoom2 || room == WumpusRoom || room == HoleRoom)
                room = rnd.Next(1, 31);
            MovePlayer(room);
        }

        public void RandomizeBat1()
        {
            do
                BatRoom1 = rnd.Next(1, 31);
            while (BatRoom1 == PlayerRoom || BatRoom2 == BatRoom1 || BatRoom1 == HoleRoom);
        }

        public void RandomizeBat2()
        {
            do
                BatRoom2 = rnd.Next(1, 31);
            while (BatRoom2 == PlayerRoom || BatRoom2 == BatRoom1 || BatRoom2 == HoleRoom);
        }

        public void CreateHazards()
        {
            List<int> rooms = new() { PlayerRoom };
            while (rooms.Count < 5)
            {
                var r = rnd.Next(1, 31);
                if (!rooms.Contains(r))
                    rooms.Add(r);
            }
            WumpusRoom = rooms[1];
            BatRoom1 = rooms[2];
            BatRoom2 = rooms[3];
            HoleRoom = rooms[4];
        }

        public string MovePlayer(int room)
        {
            PlayerRoom = room;
            var neighbors = cave[room - 1].Neighbors;
            string value = "";
            foreach (var r1 in neighbors)
            {
                var r = Math.Abs(r1);
                if (r == WumpusRoom)
                {
                    value += "You sense something huge nearby\n";
                }
                if (r == BatRoom1 || r == BatRoom2)
                {
                    value += "Sounds of chittering bounce off the walls\n";
                }
                if (r == BatRoom1 && r == BatRoom2)
                {
                    value += "The sounds are louder than usual\n";
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