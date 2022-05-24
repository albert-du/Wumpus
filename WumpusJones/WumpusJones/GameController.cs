using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WumpusJones
{
    public class GameController
    {
        private string _name;
        Cave cave;
        GameLocation gameLocation;
        Player player;



        public GameController(string name, int caveNumber)
        {
            cave = new(caveNumber);
            gameLocation = new(cave);
            player = new();
            _name = name;
        }
        public void Move(int room)
        {
            var output = gameLocation.MovePlayer(room);
            if (room == gameLocation.WumpusRoom.Number)
            {
                OnGameEnd.Invoke()
            }
        }

        public void Shoot(int room)
        {
            
        }

        public void BuyArrows()
        {

        }

        public event EventHandler<string> OnTextChanged;
        public event EventHandler<(bool, string)> OnGameEnd;
        public event EventHandler<int> OnMove;
        
    }
}
