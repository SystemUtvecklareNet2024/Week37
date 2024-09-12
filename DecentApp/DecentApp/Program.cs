using System;
using System.Numerics;
using System.Security.AccessControl;
using System.Xml.Xsl;
using static System.Net.Mime.MediaTypeNames;

namespace DecentApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WeaponList weaponList = new WeaponList();
            MonsterGenerator monsterGenerator = new MonsterGenerator();
            Monster monster;
            Story story = new Story();
            Character player;
            Random random = new Random();
            // Sätta lite färg på spelet enklare.
            Color colorWrite = new Color(ConsoleColor.Green);

            bool playing = true;
            int storyCounter = 0;

            string gameNameText = "Descent";

            // Sätter basfärgen i consolen.
            colorWrite.ResetColor();

            // Visar intro och meny för spelet.
            player = Menu();

            while (playing)
            {
                Console.Clear();

                // Spela storyn
                Console.WriteLine(story.storySentences[1]);

                // Slumpa monster och ett vapen.
                monster = monsterGenerator.monsters[random.Next(0, monsterGenerator.monsters.Count())];
                monster.Weapon = weaponList.weapons[random.Next(0, weaponList.weapons.Count())];
                player.Weapon = weaponList.dagger;

                //Console.WriteLine($"A {monster.Name} suddenly appears with a {monster.Weapon.Name} what do u do?\n");
                colorWrite.Yellow("A ");
                colorWrite.Blue(monster.Name);
                colorWrite.Yellow(" suddenly appears with a ");
                colorWrite.Blue(monster.Weapon.Name);
                colorWrite.Yellow("! What do u do?\n");


                // Continue or see score?
                Console.WriteLine("(A) Attack.");
                Console.WriteLine("(N) Go North.");
                Console.WriteLine("(S) Go South.");
                Console.WriteLine("(W) Go West.");
                Console.WriteLine("(E) Go East.");
                Console.WriteLine();
                Console.Write("Choice: ");
                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "A":
                    case "a":
                        // Attack koden.
                        Console.WriteLine(Encounter(player, monster));
                        // Vem dog?
                        Console.ReadLine();

                        break;
                    case "N":
                    case "n":
                        // Go north

                        break;
                    case "S":
                    case "s":
                        // Go south

                        break;
                    case "W":
                    case "w":
                        // Go west

                        break;
                    case "E":
                    case "e":
                        // Go East

                        break;
                    default:
                        // Måste göra nåt åt denna sen om vi hinner.
                        Console.WriteLine("Must enter a valid choice.");
                        break;
                }

                storyCounter++;                
            }

            /*Console.Write(new string('-', 50));
            foreach (char letter in gameNameText)
            {
                Console.Write(letter); // Print the letter
                Thread.Sleep(1000);    // Wait 1 second
            }
            Thread.Sleep(1000);*/

        }

        private static string Encounter(Character player, Monster monster)
        {
            Console.WriteLine("A fierce battle appears and ..");
            while(true)
            {
                if (player.IsDead())
                {
                    return "You died";
                }
                else if(monster.IsDead())
                {
                    monster.Dead = false;
                    monster.Health = 20;
                    player.AddExperience(monster.ExperienceReward);
                    return $"{monster.Name} died. You earned {monster.ExperienceReward} exp.";
                }
                else
                {
                    player.Attack(player, monster);
                    monster.Attack(player, monster);
                }
            }
        }
        private static Character Menu()
        {
            Character player;
            /*Console.WriteLine(" ####  #####  #####  #####  #####  #   #  ##### ");
            Console.WriteLine(" #   # #      #      #      #      ##  #    #   ");
            Console.WriteLine(" #   # #####  #####  #      #####  # # #    #   ");
            Console.WriteLine(" #   # #          #  #      #      #  ##    #   ");
            Console.WriteLine(" ####  #####  #####  #####  #####  #   #    #   ");
            Console.WriteLine();*/
            GameHeader();

            Console.WriteLine();
            Console.WriteLine("Deep within the Forgotten Mountains lay the vast, eerie caverns known as Shadow Hollow, rumored to be home to ancient treasures and mysterious creatures. Among the most feared inhabitants were the intelligent, shadow-born rats, led by their enormous, scarred king, Gnash. These rats, with their glowing red eyes and cunning minds, waited patiently for humans to venture too far into their dark domain.");
            Console.WriteLine();
            Console.WriteLine("Press enter to start Adventure.");
            Console.ReadLine();
            Console.WriteLine();
            Console.Write("Enter your forgotten name: ");
            string name = Console.ReadLine();
            player = new Character(name, 100);
            return player;
        }

        private static void GameHeader()
        {
            List<string> Header = new List<string>();
            string decentHeader1 = " ####  #####  #####  #####  #####  #   #  ##### ";
            string decentHeader2 = " #   # #      #      #      #      ##  #    #   ";
            string decentHeader3 = " #   # #####  #####  #      #####  # # #    #   ";
            string decentHeader4 = " #   # #          #  #      #      #  ##    #   ";
            string decentHeader5 = " ####  #####  #####  #####  #####  #   #    #   ";
            Header.Add(decentHeader1);
            Header.Add(decentHeader2);
            Header.Add(decentHeader3);
            Header.Add(decentHeader4);
            Header.Add(decentHeader5);

            foreach (string header in Header)
            {
                for (int i = 0; header.Length > i; i++)
                {
                    Console.Write(header[i]);
                    Thread.Sleep(30);
                }
                Console.WriteLine("");
            }
        }
    }
}
