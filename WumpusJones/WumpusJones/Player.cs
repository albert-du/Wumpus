namespace WumpusJones
{
    public class Player
    {
        public int Arrows { get; private set; } = 3;
        public int Turns { get; private set; }
        public int Coins { get; set; } = 5;
        public int Secrets { get; private set; }

        private int totalCoins;

        public bool ShootArrows()
        {
            Arrows -= 1;
            return Arrows > 0;
        }

        public void ArrowPurchase() =>
            Arrows += 2;
        
        public void SecretPurchase() =>
            Secrets++;
      
        public void Turn() =>
            Turns++;

        public void IncrementCoin()
        {
            if (totalCoins++ < 100)
                Coins++;
        }
    }
}