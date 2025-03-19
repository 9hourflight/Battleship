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
            int x = 5;
            int y = 5;

            
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

        public virtual bool Attack(Grid enemyGrid)
        {
            int x, y;
            string? xInput;
            string? yInput;
            do
            {
                Console.WriteLine("Enter x-coordinate of where you would like to fire a shot");
                xInput = Console.ReadLine();
                if(int.TryParse(xInput, out int xCoord))
                {
                    if(xCoord <= 0 && xCoord >= 10)
                    {
                        x = xCoord;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input");
                    //figure out how to get attack to prompt again
                }
                y = rand.Next(10);
            }
            while (enemyGrid.MakeGuess(x, y));
            return true;
        }

        public Grid GetGrid()
        {
            return grid;
        }
    }
}
