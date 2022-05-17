namespace WumpusJones
{
    public interface IPlayer
    {
        int Arrows { get; }
        int Score { get; }
        int Turns { get; set; }
        int ShootArrow();
        int ArrowPurchase();
    }
}