using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticesAndPrinciple.GoodPractices
{
    #region Bad Example
    // Bad Example
    internal class NumberServiceBad
    {
        public List<int> numbers = new List<int>();
        public void GetStats()
        {
            Console.WriteLine("Welcome to the app!");
            Console.WriteLine("Enter 5 numbers:");
            for (int i = 0; i < 5; i++)
            {
                Console.Write("Enter number:");
                numbers.Add(int.Parse(Console.ReadLine()));
            }
            Console.Write("You entered: ");
            foreach (int num in numbers)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Stats:");
            int even = numbers.Where(x => x % 2 == 0).Count();
            Console.WriteLine($"Even numbers: {even}");

            int odd = numbers.Count - even;
            Console.WriteLine($"Odd numbers: {odd}");

            int positive = numbers.Where(x => x >= 0).Count();
            Console.WriteLine($"Positive numbers: {positive}");

            int negative = numbers.Count - positive;
            Console.WriteLine($"Negative numbers: {negative}");

            int sum = numbers.Sum();
            Console.WriteLine($"Sum of numbers: {sum}");
        }
    }
    #endregion

    #region Good Example
    internal class NumberService
    {
        public List<int> RequestNumbers(int numbersCount)
        {
            List<int> numbers = new List<int>();
            Console.WriteLine("Welcome to the app!");
            Console.WriteLine($"Enter {numbersCount} numbers:");
            for (int i = 0; i < numbersCount; i++)
            {
                Console.Write("Enter number:");
                numbers.Add(int.Parse(Console.ReadLine()));
            }
            return numbers;
        }
        public void PrintNumbers(List<int> numbers)
        {
            Console.Write("You entered: ");
            foreach (int num in numbers)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }

        public void PrintStats(List<int> numbers)
        {
            Console.WriteLine("Stats:");
            int even = numbers.Where(x => x % 2 == 0).Count();
            Console.WriteLine($"Even numbers: {even}");

            int odd = numbers.Count - even;
            Console.WriteLine($"Odd numbers: {odd}");

            int positive = numbers.Where(x => x >= 0).Count();
            Console.WriteLine($"Positive numbers: {positive}");

            int negative = numbers.Count - positive;
            Console.WriteLine($"Negative numbers: {negative}");

            int sum = numbers.Sum();
            Console.WriteLine($"Sum of numbers: {sum}");
        }
    }
    #endregion
}
