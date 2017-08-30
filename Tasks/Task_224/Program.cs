using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_224
{
    class Program
    {
        /// <summary>
        /// Finds dividers of number
        /// </summary>
        /// <param name="number">Natural number</param>
        /// <returns>list of dividers of given number</returns>
        public static List<int> FindDividers(int number)
        {
            List<int> dividers = new List<int>();
            int divider = 1;
            while (divider < Math.Sqrt(number))
            {
                if (number % divider == 0)
                {
                    dividers.Add(divider);
                    dividers.Add(number / divider);
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
                Console.Write( inputMessage );
                if (Int32.TryParse(Console.ReadLine(), out number) == true)
                {
                    Console.WriteLine(outputMessage);
                    foreach (var divider in FindDividers(number))
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
