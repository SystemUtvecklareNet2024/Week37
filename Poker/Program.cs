using System.Runtime.CompilerServices;

namespace Poker
{
    
    internal class Program
    {
        static void Main(string[] args)
        {
            GameManager gameManager = new GameManager();            
            
            bool quit = false;            

            Console.ForegroundColor = ConsoleColor.Green;

            while (!quit)
            {
                string? choice = Menu(gameManager);

                switch (choice)
                {
                    case "1":
                        // Start Game                    
                        gameManager.StartGame();
                        break;
                    case "2":
                        // Quit
                        Console.WriteLine("Goodbye and thanks for playing.");
                        quit = true;
                        break;
                    default:
                        // Default msg
                        Console.Clear();
                        
                        Console.WriteLine("Must enter a valid choice.");
                        break;
                }
            }

        }

        private static string? Menu(GameManager manager)
        {
            Console.WriteLine("----- Welcome to my Cardgame -----");
            Console.WriteLine("1. Start Game");
            Console.WriteLine("2. Quit");
            Console.WriteLine("----------------------------------");
            Console.WriteLine($"Current highscore: {manager.GetHighScore()}");
            Console.WriteLine("----------------------------------");
            Console.Write    ("Enter choice: ");
            string? choice = Console.ReadLine();
            return choice;
        }
    }
}
