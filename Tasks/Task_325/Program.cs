using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_325
{
    class Program
    {
        /// <summary>
        /// Checks that number is prime
        /// </summary>
        /// <param name="number">natural number</param>
        /// <returns>true if number is prime</returns>
        public static bool IsPrime(int number)
        {
            bool isPrime = number == 1 ? false : true;
            int i = 2;
            while ( isPrime == true && i <= Math.Sqrt(number))
            {
                isPrime = (number % i == 0) ? false : true;
                i++;
            }
            return isPrime;
        }

        /// <summary>
        /// Finds prime dividers of number
        /// </summary>
        /// <param name="number">natural number</param>
        /// <returns>list of prime dividers of number</returns>
        public static List<int> FindPrimeDividers(int number)
        {
            List<int> dividers = new List<int>();
            int divider = 1;
            while (divider < Math.Sqrt(number))
            {
                if (number % divider == 0)
                {
                    if (IsPrime(divider))
                    {
                        dividers.Add(divider);
                    }
                    if ( IsPrime(number / divider))
                    {
                        dividers.Add(number / divider);
                    }
                }
                divider++;
            }
            if (number / divider == divider)
            {
                dividers.Add(divider);
            }
            return dividers;
        }

        static void Main(string[] args)
        {
            int number;
            bool isNumber = false;

            string inputMessage = "Please, input the number: ";
            string outputMessage = "Dividers are: ";
            string wrongInputMessage = "It is not a natural number! Try again.";

            while (!isNumber)
            {
                Console.Write(inputMessage);
                if (Int32.TryParse(Console.ReadLine(), out number) == true)
                {
                    Console.WriteLine(outputMessage);
                    foreach (var divider in FindPrimeDividers(number))
                    {
                        Console.WriteLine(divider);
                    }
                    isNumber = true;
                }
                else
                {
                    Console.WriteLine(wrongInputMessage);
                }
            }

            Console.ReadLine();
        }
    }
}
