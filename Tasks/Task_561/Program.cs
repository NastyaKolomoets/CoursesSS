using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_561
{
    class Program
    {
        /// <summary>
        /// Counts dijits in number
        /// </summary>
        /// <param name="number">Natural number</param>
        /// <returns>Amount of dijits in number</returns>
        public static int CountDijits(uint number)
        {
            int counter = 1;
            int decade = 10;
            while ( number >= decade)
            {
                decade *= 10;
                counter++;
            }
            return counter;
        }

        /// <summary>
        /// Finds numbers beetwen 1 and given number 
        /// which in pow 2 has the same last dijits as number 
        /// </summary>
        /// <param name="number">natural number</param>
        /// <returns>list of numbers that satisfy condition</returns>
        public static List<uint> FindMagicNumbers(uint number)
        {
            List<uint> magicNumbers = new List<uint>();
            for(uint i = 1; i <= number; i++)
            {
                long pow = i * i;
                if ((pow - i) % Math.Pow(10, CountDijits(i)) == 0)
                {
                    magicNumbers.Add(i);
                }
            }
            return magicNumbers;
        }

        static void Main(string[] args)
        {
            uint number;
            bool isNumber = false;

            string inputMessage = "Please, input the number: ";
            string outputMessage = "Magic numbers are: ";
            string wrongInputMessage = "It is not a natural number! Try again.";

            while (!isNumber)
            {
                Console.Write(inputMessage);
                if ( UInt32.TryParse(Console.ReadLine(), out number) == true)
                {
                    Console.WriteLine(outputMessage);
                    foreach (var magicNumber in FindMagicNumbers(number))
                    {
                        Console.WriteLine( "{0} ^ 2 = {1}", 
                            magicNumber,
                            (long) magicNumber * magicNumber);
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
