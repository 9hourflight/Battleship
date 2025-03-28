namespace Battleship
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome to Battleship! Press Enter to start.");
            Console.ReadLine();
            BasePlayer player = new BasePlayer();
            BasePlayer ai = new AIPlayer();
            Grid aiGrid = ai.GetGrid();
            Grid playerGrid = player.GetGrid();
            playerGrid.DisplayBoard(false);
            int playerShots = 0;
            int aiShots = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("AI's Board (Shots Fired):" + playerShots);
                aiGrid.DisplayBoard(true);
                player.Attack(aiGrid);
                Console.Clear();
                Console.WriteLine("AI's Board (Shots Fired):" + playerShots);
                aiGrid.DisplayBoard(true);
                playerShots++;

                Console.WriteLine("\nYour Board:");
                ai.Attack(playerGrid);
                aiShots++;
                playerGrid.DisplayBoard(false);
                Console.WriteLine("AI has fired at you." );
                Thread.Sleep(7000);
                //how can I make this display for longer?
                if (aiGrid.CheckWin())
                {
                    Console.WriteLine("You win in " + playerShots + " shots!");
                    break;
                }
                ai.Attack(playerGrid);
                if (playerGrid.CheckWin())
                {
                    Console.WriteLine("AI wins in " + aiShots + "!");
                    break;
                }
            }
        }
    }


}