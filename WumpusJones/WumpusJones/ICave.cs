using System.Collections.Generic;

namespace WumpusJones
{
    public interface ICave
    {
        IReadOnlyList<Room> AllRooms { get; }
        IReadOnlyList<Room> NearbyRooms { get; }
        IReadOnlyList<Room> ExploredRooms { get; }
    }
}