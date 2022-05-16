using System.Collections.Generic;

namespace WumpusJones
{
    public interface IGameLocations
    {
        Room Player { get; set; }
        Room WumpusLocations { get; set; }
        IReadOnlyList<Hazard> NearbyHazards { get; set; }
        void MovePlayer(Direction direction);

    }
}