using System.Diagnostics;
using System;
using System.Text;
using System.Collections;
using System.Linq;

namespace PrimeNumbers
{
    public class Program
    {
        static void Main(string[] args)
        {
            int choice = 0;
            while(choice != 3)
            {
                Console.WriteLine("Welcome to the Prime Number Checker!");
                Console.WriteLine("How would you like to check for a Prime Number? (select one)");
                Console.WriteLine("1. Check a single number (Get a yes or no)");
                Console.WriteLine("2. Use the Siev of Eratosthenes method (Get a list of Prime Factors, if any)");
                Console.WriteLine("3. Exit Application");
                string input = Console.ReadLine();
                if (!Int32.TryParse(input, out choice))
                {
                    Console.WriteLine($"{input} is not a valid number");
                }
                else if(choice > 3 || choice < 1)
                {
                    Console.WriteLine($"{choice} is not a valid choice");
                }
                else
                {
                    switch(choice)
                    {
                        case(1):
                            bool validInt = false;
                            int num = 0;
                            while(!validInt)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Enter a integer value: ");
                                string entry = Console.ReadLine();
                                validInt = Int32.TryParse(entry, out num);

                                if (!validInt)
                                {
                                    Console.WriteLine($"{entry} is not a valid integer");
                                }
                            }
                            Console.WriteLine(DivideMethod(num) ? $"Yes, {num} IS a Prime Number" :
                                                                  $"No, {num} IS NOT a Prime Number");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        case (2):
                            int num2 = 0;
                            bool validInt2 = false;
                            while(!validInt2)
                            {
                                Console.WriteLine("Enter an integer value: ");
                                string entry = Console.ReadLine();
                                validInt2 = int.TryParse(entry, out num2);
                                if (!validInt2)
                                {
                                    Console.WriteLine($"{entry} is not a valid integer. Please try again");
                                    Console.Read();
                                    Console.Clear();
                                }
                            }

                            List<int> results = ExecuteSiev(num2);
                            if(results.Count == 0)
                            {
                                Console.WriteLine($"{num2} is NOT a prime number.");
                                Console.WriteLine($"There are no Prime factors in {num2}");
                            }
                            else if (results[results.Count - 1] == num2)
                            {
                                Console.WriteLine($"{num2} IS a prime number");
                                Console.WriteLine("These are the Prime Factors:");
                                foreach(int i in results)
                                {
                                    Console.WriteLine(i);
                                }
                            }
                            Console.Read();
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Figure out if the provided parameter, number,  is a Prime Numbe or not by attempting to divide it by every number from 
        /// 2 to (number - 1). If every number return a mod division greater than 0, then number is a Prime
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private static bool DivideMethod(int number)
        {
            if (number < 2)
            {
                return false;
            }
            for (int i = 2; i < number; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        private static List<int> ExecuteSiev(int num)
        {
            List<int> nums = new List<int>();

            if (num == 1)
            {
                nums.Add(1);
                return nums;
            } 
           
            for(int i = 1; i <= num; i++)
            {
                nums.Add(i);
            }

            for(int i = 2; i <= num; i++)
            {
                List<int> temp = nums.Where(n => n % i == 0).ToList();
                nums = nums.Except(temp).ToList();
            }

            return nums;
        }
    }
}