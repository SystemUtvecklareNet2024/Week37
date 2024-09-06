using System.Runtime.CompilerServices;

namespace Poker
{
    public enum CardValue { Two = 2, Three = 3, Four = 4, Five = 5, Six = 6, Seven = 7, Eight = 8, Nine = 9, Ten = 10, Jack = 11, Queen = 12, King = 13, Ace = 14 }
    public enum CardSuit { Hearts, Spades, Clubs, Diamonds }
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
