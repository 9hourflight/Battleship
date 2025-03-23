using System.Security.Cryptography.X509Certificates;

namespace Battleship
{
    class BasePlayer
    {
        public static string[] shipNames = { "Battleship", "Carrier", "Cruiser", "Submarine", "Destroyer" };
        public static int[] shipLengths = { 5, 4, 3, 3, 2 };
        private Grid grid;
        private Random rand;

        public BasePlayer()
        {
            grid = new Grid();
            rand = new Random();
            PlaceShips();
        }

        public void PlaceShips()
        {
            Random rand = new Random();
         
            for (int i = 0; i < shipNames.Length; i++)
            {
                string direction = "H";
                if (rand.Next(0, 2) == 0)
                {
                    direction = "V";
                }

                if(!grid.PlaceShip(new Ship(shipNames[i], shipLengths[i]), rand.Next(grid.BoardLength()), rand.Next(grid.BoardLength()), direction))
                {
                    i--;
                }
            }
            
        }
        public enum YToLetters
        {
            A, B, C, D, E, F, G, H, I, J,
        }

        public virtual bool Attack(Grid enemyGrid)
        {
            int x, y;
            string? xInput;
            string? yInput;
            do
            {
                Console.WriteLine("Enter a number for the x-coordinate of where you will fire");
                xInput = Console.ReadLine();
                if(xInput != null)
                {
                    if (int.TryParse(xInput, out int xCoord) && (xCoord >= 0 && xCoord <= 10))
                    {
                        x = xCoord;
                    }
                    else
                    {
                        Console.WriteLine("Input error");
                        break;  
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input");
                    break;
                }
                Console.WriteLine("Enter the letter of the y-coordinate of where you will fire");
                
                yInput = Console.ReadLine().ToUpper();
                if (yInput != null)
                {
                    y = (int)((YToLetters)Enum.Parse(typeof(YToLetters), yInput));
                    Console.WriteLine(y);
                }
                else
                {
                    Console.WriteLine("Invalid input");
                    break;
                }

            }
            while (enemyGrid.MakeGuess(y, x)); //calling as (x, Y) causes it to place incorrectly for some reason, switching it fixes the problem
            return true;
        }

        public Grid GetGrid()
        {
            return grid;
        }
    }
}
