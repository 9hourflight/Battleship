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
        
        public override void ShipDirection()
        {
            Random rand = new Random();

            for (int i = 0; i < shipNames.Length; i++)
            {
                char direction = 'H';
                if (rand.Next(0, 2) == 0)
                {
                    direction = 'V';
                }

                if (!grid.PlaceShip(new Ship(shipNames[i], shipLengths[i]), rand.Next(grid.BoardLength()), rand.Next(grid.BoardLength()), direction))
                {
                    i--;
                }
            }

        }
        
    }
}
