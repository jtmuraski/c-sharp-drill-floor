using System.Diagnostics;

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

                                if (!Int32.TryParse(entry, out num))
                                {
                                    Console.WriteLine($"{entry} is not a valid integer");
                                }
                                else
                                {
                                    Console.WriteLine(DivideMethod(num) ? $"Yes, {num} IS a Prime Number" :
                                                                          $"No, {num} IS NOT a Prime Number");
                                    Console.Read();
                                    Console.Clear();
                                }
                            }
                            break;
                        case (2):

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


    }
}
