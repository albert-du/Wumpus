namespace WumpusJones
{
    public interface IGameController
    {
        void StartGame();
        void EndGame();
        void Move(Direction direction);
        void Shoot();
    }
}