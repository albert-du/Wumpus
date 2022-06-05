namespace WumpusJones
{
    public abstract record WumpusState(int Duration)
    {
        public sealed record Asleep(int Duration) : WumpusState(Duration);
        public sealed record Awake(int Duration) : WumpusState(Duration);
        public sealed record Defeated(int Duration, int Speed) : WumpusState(Duration);
        public sealed record Dead() : WumpusState(int.MaxValue);
    }
}
