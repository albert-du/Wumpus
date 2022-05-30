using System;

namespace WumpusJones
{
    public class Room
    {
        public int Number { get; }
        public int[] Neighbors { get; }

        public Room(int number, int n, int ne, int se, int s, int sw, int nw)
        {
            Number = number;
            Neighbors = new[] { n, ne, se, s, sw, nw };
        }

        public void Parse(string text)
        {
            // Serialization format:
            // -+-+--
            try
            {
                for (var i = 0; i < 6; i++)
                    Neighbors[i] *= text[i] == '-' ? -1 : 1;
            }
            catch
            {
                throw new ArgumentException("bad formatting", nameof(text));
            }
        }

        public override bool Equals(object obj) => obj switch
        {
            Room room => room.Number == Number,
            _ => false
        };

        public override int GetHashCode() => Number;

        public int North => Neighbors[0];
        public int NorthEast => Neighbors[1];
        public int SouthEast => Neighbors[2];
        public int South => Neighbors[3];
        public int SouthWest => Neighbors[4];
        public int NorthWest => Neighbors[5];
    }
}