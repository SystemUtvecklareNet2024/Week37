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
            bool playing = true;
            int storyCounter = 0;

            string gameNameText = "Descent";

            player = Menu();

            while (playing)
            {
                Console.Clear();
                // spela storyn
                Console.WriteLine(story.storySentences[1]);
                // Slumpa monster här.
                
                monster = monsterGenerator.monsters[random.Next(0, monsterGenerator.monsters.Count())];
                monster.Weapon = weaponList.weapons[random.Next(0, weaponList.weapons.Count())];
                player.Weapon = weaponList.dagger;

                Console.WriteLine($"A {monster.Name} suddenly appears with a {monster.Weapon.Name} what do u do?\n");

                Console.WriteLine("(A) Attack.");
                Console.WriteLine("(N) Go North.");
                Console.WriteLine("(S) Go South.");
                Console.WriteLine("(W) Go West.");
                Console.WriteLine("(E) Go East.");
                Console.WriteLine();
                Console.Write("Choice: ");
                string choice = Console.ReadLine();

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


                // switch för händelser.
            }

















            /*while (true)
            {
                Console.WriteLine("nu startar spelet");
                Console.ReadLine();

                Console.WriteLine("{0, -100}", story.storySentences[0]);
                Console.ReadLine();
                Console.WriteLine(story.storySentences[1]);
            }*/

            /*Console.Write(new string('-', 50));
            foreach (char letter in gameNameText)
            {
                Console.Write(letter); // Print the letter
                Thread.Sleep(1000);    // Wait 1 second
            }
            Thread.Sleep(1000);*/

            //Character player = new Character("Stefan", 20);
            /*Monster rat = new Monster(10, "Frodo");
            rat.Weapon = weaponList.axe;
            Console.WriteLine(rat.Weapon.MinDamage);*/
            /*Console.WriteLine(player.Name);
            rat.Weapon = weaponList.dagger;
            //Console.WriteLine("rat sword min damage: " + rat.Weapon.MinDamage);
            player.Weapon = weaponList.axe;
            Console.WriteLine(player.Weapon.Name);*/

            /*while (true)   // utför loopen så länge inte någon har 0 eller mindre HP
            {
                if (player.IsDead() || rat.IsDead())
                {
                    break;
                }
                else
                {
                    player.Attack(player, rat);    // anropar attackmetoden i Entity
                    rat.Attack(player, rat);   // anropar attack metoden i Entit
                }
            }*/


        }

        private static string Encounter(Character player, Monster monster)
        {
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
                    player.Attack(player, monster);    // anropar attackmetoden i Entity
                    monster.Attack(player, monster);   // anropar attack metoden i Entit
                }
            }
        }
        private static Character Menu()
        {
            Character player;
            Console.WriteLine(" ####  #####  #####  #####  #####  #   #  ##### ");
            Console.WriteLine(" #   # #      #      #      #      ##  #    #   ");
            Console.WriteLine(" #   # #####  #####  #      #####  # # #    #   ");
            Console.WriteLine(" #   # #          #  #      #      #  ##    #   ");
            Console.WriteLine(" ####  #####  #####  #####  #####  #   #    #   ");
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
    }
}
