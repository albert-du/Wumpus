using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WumpusJones
{
    class Player
    {

        public int Arrows { get; set; }
        public double Inventory {get;set;}
        public int Turns { get; set; }
        public int Coins { get; set; }
        public double Secret { get; set; }

        public bool ShootArrows()
        {
            Turn();
            Arrows -= 1;
            return Arrows > 0;
        }


        public void ArrowPurchase()
        {

            Arrows++;
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

        public void NoArrows()
        {

        }

        //public 


    }
}
