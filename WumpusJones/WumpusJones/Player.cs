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
            if (Arrows > 0)
            {
                Arrows -= 1;
                return true;
            }
                else return false;
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
