using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    internal class AIPlayer: BasePlayer
    {
        private Random rand = new Random();
        public override bool Attack(Grid enemyGrid)
        {
            int x, y;
            do
            {
                x = rand.Next(10);
                y = rand.Next(10);
            }
            while (enemyGrid.MakeGuess(x, y));
            return true;
        }
    }
}
