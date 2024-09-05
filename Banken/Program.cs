namespace Banken
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] users = new string[20];

            int[] balance = new int[20];

            int userCount = 0;
            int index;

            bool quit = false;

            while (!quit)
            {
                Console.WriteLine("1. New user");
                Console.WriteLine("2. deposit to account");
                Console.WriteLine("3. withdraw from account");
                Console.WriteLine("4. show all");
                Console.WriteLine("q. quit.");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        // new user
                        Console.Write("Enter name: ");
                        string name = Console.ReadLine();
                        users[userCount] = name;
                        balance[userCount] = 0;
                        userCount++;

                        break;
                    case "2":
                        // deposit
                        for (int i = 0; i < users.Length; i++)
                        {
                            if(users[i] != null)
                                Console.WriteLine(users[i] + " account: " + i);
                        }

                        Console.Write("Which account number to desposit too?: ");
                        index = int.Parse(Console.ReadLine());
                        Console.Write("How much to deposit?: ");
                        int depositAmount = int.Parse(Console.ReadLine());
                        balance[index] += depositAmount;
                        break;

                    case "3":
                        // withdraw
                        for (int i = 0; i < users.Length; i++)
                        {
                            if (users[i] != null)
                                Console.WriteLine(users[i] + " account: " + i);
                        }
                        Console.Write("Which account to withdraw from?: ");
                        index = int.Parse(Console.ReadLine());
                        Console.Write("How much to withdraw?: ");
                        int withdrawAmount = int.Parse(Console.ReadLine());
                        if(withdrawAmount > balance[0])
                            balance[index] -= withdrawAmount;

                        break;

                     case "4":
                        // show all
                        for (int i = 0; i < users.Length; i++)
                        {
                            if (users[i] != null)
                                Console.WriteLine(users[i] + " : " + balance[i]);
                        }

                        break;
                    case "q":
                        // quit
                        quit = true;
                        break;
                    default:
                        break;
                }
            }

            Console.ReadLine();
        }
    }
}
