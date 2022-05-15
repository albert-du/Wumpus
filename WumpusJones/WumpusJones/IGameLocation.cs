using System.Collections.Generic;

namespace WumpusJones
{
    public interface IGameLocations
    {
        Room Player { get; set; }
        Room WumpusLocations { get; set; }
        IReadOnlyCollection<Hazard> NearbyHazards { get; set; }
        void MovePlayer(Direction direction);

    }
}