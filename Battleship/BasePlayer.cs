using System.Security.Cryptography.X509Certificates;

namespace Battleship
{
    class BasePlayer
    {
        public static string[] shipNames = { "Battleship", "Carrier", "Cruiser", "Submarine", "Destroyer" };
        public static int[] shipLengths = { 5, 4, 3, 3, 2 };
        public Grid grid;
        private Random rand;

        public BasePlayer()
        {
            grid = new Grid();
            rand = new Random();
            ShipDirection();
        }

        public enum YToLetters
        {
            A, B, C, D, E, F, G, H, I, J,
        }
        public virtual void ShipDirection()
        {
            char direction = 'H';
            char horizontal = 'H';
            char vertical = 'V';
            int x;
            string xInput;
            int y;
            string yInput;
         
            for (int i = 0; i < shipNames.Length; i++)
            {
                Console.WriteLine("Now placing " + shipNames[i] + " . Enter V to place vertically, or H to place horizontally.");
                string userInput = Console.ReadLine().ToUpper();
                if (char.TryParse(userInput, out char character) && userInput != null)
                {
                    if (userInput.Contains(horizontal))
                    {
                        direction = horizontal;
                    }
                    else if (userInput.Contains(vertical))
                    {
                        direction = vertical;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input");
                    break;
                }
                Console.WriteLine("Enter a number for the x-coordinate of where you want to place your "+ shipNames[i]);
                xInput = Console.ReadLine();
                if (xInput != null)
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
                Console.WriteLine("Enter the letter of the y-coordinate of where you want to place your " + shipNames[i]);
                yInput = Console.ReadLine().ToUpper();
                if (yInput != null)
                {
                    y = (int)((YToLetters)Enum.Parse(typeof(YToLetters), yInput));
                }
                else
                {
                    Console.WriteLine("Invalid input");
                    break;
                }
                if (!grid.PlaceShip(new Ship(shipNames[i], shipLengths[i]), x, y, direction))
                {
                    i--;
                }
            }
            
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
