using System.Collections.Generic;

namespace WumpusJones
{
    public interface ICave
    {
        IReadOnlyCollection<Room> AllRooms { get; }
        IReadOnlyCollection<Room> NearbyRooms { get; }
        IReadOnlyCollection<Room> ExploredRooms { get; }
    }
}