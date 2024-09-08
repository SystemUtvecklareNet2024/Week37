using MultiplicationLoop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace UserAccountsWIthBankAccount
{
    internal class Program
    {
        static int totalAccounts = 1;
        static UserDatabase database = new UserDatabase();
        static Color myColor = new Color(ConsoleColor.Green);
        

        static void Main(string[] args)
        {
            myColor.ResetColor();

            bool quit = false;            

            while (!quit)
            {
                Menu();

                string choice = Console.ReadLine();
                choice.ToUpper();

                switch (choice)
                {
                    case "1":
                        // Create new User
                        CreateUser();
                        break;

                    case "2":
                        // Remove user
                        RemoveUser();
                        break;

                    case "3":
                        // Deposit
                        Deposit();
                        break;

                    case "4":
                        // Withdraw
                        Withdraw();
                        break;

                    case "5":
                        // Show all accounts
                        ShowAllAccounts();
                        break;

                    case "Q":
                        // quit
                        Console.WriteLine("Have a nice day! Good bye!");
                        quit = true;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Must enter a valid choice!");
                        break;
                }
            }

            Console.ReadLine();
        }

        static void Withdraw()
        {
            Console.Clear();
            ShowAllAccounts();

            bool valid = false;
            int accNumber = 0;
            int withdrawAmount = 0;

            while (!valid)
            {
                Console.Write("Wich user do you want to Withdraw from? Enter accountnumber: ");
                try
                {
                    accNumber = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.Write("Please enter a accountNumber: ");
                }

                Console.WriteLine("Enter amount to withdraw: ");
                try
                {
                    withdrawAmount = int.Parse(Console.ReadLine());
                    valid = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Please enter amount in valid numbers. Try again.");
                }

                // Iterate users to find user with correct accountnumber and withdraws money if enough money is available.
                foreach (User user in database.Users)
                {
                    if (user.Account.GetAccountNumber() == accNumber)
                    {
                        Console.Clear();
                        if (user.Account.Withdraw(withdrawAmount))
                        {
                            Console.WriteLine($"{withdrawAmount} has been removed from account {accNumber}.");
                        }
                        else
                        {
                            //Console.WriteLine($"Not enough balance to Withdraw {withdrawAmount}. Current Balance: {user.Account.GetBalance()}");
                            myColor.Cyan($"Not enough balance to Withdraw {withdrawAmount}. Current Balance: {user.Account.GetBalance()}\n");
                        }
                        break;
                    }
                }
            }
        }

        static void Deposit()
        {
            ShowAllAccounts();
            bool valid = false;
            int accNumber = 0;
            int depositAmount = 0;

            while (!valid)
            {
                Console.Write("Wich user do you want to desposit too? Enter accountnumber: ");
                try
                {
                    accNumber = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.Write("Please enter a accountNumber: ");
                }

                Console.WriteLine("Enter amount to Deposit: ");
                try
                {
                    depositAmount = int.Parse(Console.ReadLine());
                    valid = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Please enter amount in valid numbers. Try again.");
                }

                // Iterate and find the correct account and deposit the amount to the account.
                foreach (User user in database.Users)
                {
                    if (user.Account.GetAccountNumber() == accNumber)
                    {
                        user.Account.Deposit(depositAmount);
                        break;
                    }
                }
            }
            Console.Clear();
            Console.WriteLine($"{depositAmount} has been added to account {accNumber}.");
        }
        static void RemoveUser()
        {
            ShowAllAccounts();
            bool valid = false;
            int number = 0;

            while (!valid)
            {
                Console.Write("Wich user do you want to remove? Enter accountnumber: ");
                try
                {
                    number = int.Parse(Console.ReadLine());
                    valid = true;
                }
                catch (Exception)
                {
                    Console.Write("Please enter a accountNumber: ");
                }
            }

            foreach (User user in database.Users)
            {
                if (user.Account.GetAccountNumber() == number)
                {
                    database.Users.Remove(user);
                    break;
                }
            }
        }

        static void ShowAllAccounts()
        {
            Console.Clear();

            // Show structured table Headline. {0, -10} where 0 is the first arg after the ',' and -10 the width of 'column width'
            Console.WriteLine(new string('-', 94));
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("{0,-10} {1,-20} {2,-20} {3,-12} {4,-15} {5,12}", "Account", "Name", "Street", "Postalcode", "City", "Balance");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(new string('-', 94));

            Console.ForegroundColor = ConsoleColor.Yellow;

            // Iterate all users if database not empty and prints out in structured rows with same values as tableheadline
            if (database.Users.Count() > 0)
            {

                foreach (var user in database.Users)
                {
                    Console.WriteLine("{0,-10} {1,-20} {2,-20} {3,-12} {4,-15} {5,12}", user.Account.GetAccountNumber(), user.Name, user.Street, user.PostalCode, user.City, user.Account.GetBalance() + "$");
                }
            }
            else
            {
                myColor.Red("Database is empty!");                
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(new string('-', 94));
            Console.WriteLine();
        }

        static void CreateUser()
        {
            // Reads inputvalues to store in a new user.
            Console.WriteLine("--------------------------");
            Console.Write("Name: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string name = Console.ReadLine();
            Console.ForegroundColor= ConsoleColor.Green;  
            Console.Write("Adress: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string adress = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("City: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string city = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Postalcode: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string postalCode = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Green;
            
            

            // Creates a new user
            User newUser = new User(name, adress, city, postalCode, totalAccounts);

            // Add user to database
            database.AddUser(newUser);

            Console.Clear();
            Console.WriteLine("New user added.");

            // Increase amount of accounts created.
            totalAccounts++;
        }

        static void Menu()
        {
            Console.Write("###################################\n");
            Console.Write("#   Userdatabase for Bankaccount  #\n");
            Console.Write("-----------------------------------\n");

            Console.WriteLine("Select one option from the menu.");
            Console.WriteLine("(1). Create new user");
            Console.WriteLine("(2). Remove user");
            Console.WriteLine("(3). Deposit ");
            Console.WriteLine("(4). Withdraw");
            Console.WriteLine("(5). Show all accounts");
            Console.WriteLine("(Q). Quit");
            Console.WriteLine();
            Console.Write("Enter choice: ");
        }
    }
}
