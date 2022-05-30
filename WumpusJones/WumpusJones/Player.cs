namespace WumpusJones
{
    public class Player
    {
        public int Arrows { get; set; } = 3;
        public int Turns { get; set; }
        public int Coins { get; set; } = 5;
        public double Secret { get; set; }

        private int totalCoins;

        public bool ShootArrows()
        {
            Turn();
            Arrows -= 1;
            return Arrows > 0;
        }

        public void ArrowPurchase()
        {
            Arrows += 2;
            Turn();
        }

        public void SecretPurchase()
        {
            Turn();
        }

        private void Turn()
        {
            Turns++;
        }

        public void IncrementCoin()
        {
            if (totalCoins++ < 100)
                Coins++;
        }
    }
}