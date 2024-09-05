using System;
namespace AnimalApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            int[] numbers = { 1, 2, 3, 4 };
            Object[] test = [5, 6, 7, 8];

            // Print normal
            PrintArray(numbers);
            PrintArray(test);

            // copy first 2 elements from first array to test array
            Array.Copy(numbers, test, 2);

            // Print again.
            PrintArray(numbers);
            PrintArray(test);

        }

        private static void PrintArray(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]);
            }
        }
        private static void PrintArray(Object[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]);
            }
        }
    }
}
