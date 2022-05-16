using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WumpusJones
{
    class Cave :ICave
    {
        List<Room> roomExplored = new();
        IGameLocations _locations;

        public Cave(IGameLocations locations)
        {
            _locations = locations;
            AllRooms = new[]
            {
                new Room()
            };
        }

        public IReadOnlyList<Room> AllRooms { get; }
        public IReadOnlyList<Room> NearbyRooms 
        { 
            get
            {
                return new[] { new Room() };
            } 
        }

        public IReadOnlyList<Room> ExploredRooms => roomExplored;

        public void ExploredRoom(Room room)
        {
            roomExplored.Add(room);
        }
    }
}
