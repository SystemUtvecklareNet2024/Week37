using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    internal class GameManager
    {
        public Deck deck = new Deck();
        public Player player = new Player();
        private bool gameOver = false;
        private bool isHigher = true;
        private int highScore = 0;
        public void StartGame()
        {
            gameOver = false;

            deck.Shuffle();
            Console.Clear();
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("In this game, you will earn 1 point for each difference\n" +
                              "in the value of the card shown, provided you correctly\n" +
                              "guess whether the next card is higher or lower.\n Game will" +
                              "end if not correctly guessed higher or lower.");
            Console.WriteLine("-------------------------------------------------------");
            Console.Write("Enter your name when ready: ");
            player.Name = Console.ReadLine();

            Console.Clear();
            Console.WriteLine($"Hello {player.Name}! Lets play.\n\n");

            while (!gameOver)
            {
                
                Console.Write($"Will the next card be higher or lower then: ");

                Console.ForegroundColor = ConsoleColor.Red;
                deck.ShowTopCard();
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine();
                Console.Write("Type 'H' or 'L' : ");

                string? choice = Console.ReadLine().ToUpper();

                Console.WriteLine();
                Console.Write($"Your card is: ");
                Console.ForegroundColor= ConsoleColor.Red;
                player.Hand.Add(deck.DealPlayerCard());
                
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine();
                Console.WriteLine("press enter for result...");
                Console.ReadLine();
                Console.Clear();

                if (choice == "H")
                {
                    CalculateScore(isHigher);
                }
                else if (choice == "L")
                {
                    CalculateScore(!isHigher);
                }
            }

            deck.ResetDeck();
        }

        private void CalculateScore(bool isHigher)
        {
            if (isHigher)
            {
                
                int playerValue = (int)(CardValue)player.Hand.Last().Value;
                int thrownValue = (int)(CardValue)deck.ShowTopThrownCard().Value;

                if (playerValue >= thrownValue)
                {
                    player.Score += playerValue - thrownValue;
                    
                    Console.WriteLine($"Correct!!! Your {player.Hand.Last().Value} was higher or the same as {deck.ShowTopThrownCard().Value}.");
                    Console.WriteLine("SCORE: " + player.Score);
                    Console.WriteLine();
                }
                else
                {                    
                    Console.WriteLine("Game Over");
                    Console.WriteLine("SCORE: " + player.Score);
                    Console.WriteLine();
                    gameOver = true;
                    CheckIfNewHighScore();
                }
            }
            else
            {
                
                int playerValue = (int)(CardValue)player.Hand.Last().Value;
                int thrownValue = (int)(CardValue)deck.ShowTopThrownCard().Value;

                if (playerValue <= thrownValue)
                {
                    player.Score += thrownValue - playerValue;
                    Console.WriteLine($"Correct!! Your {player.Hand.Last().Value} was lower or the same as {deck.ShowTopThrownCard().Value}.");
                    Console.WriteLine("SCORE: " + player.Score);
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Game Over");
                    Console.WriteLine("SCORE: " + player.Score);
                    Console.WriteLine();
                    gameOver = true;
                    CheckIfNewHighScore();
                }
            }
        }

        private void CheckIfNewHighScore()
        {
            if (player.Score > highScore)
            {
                highScore = player.Score;
            }
        }

        public int GetHighScore()
        {
            return highScore;
        }



    }
}
