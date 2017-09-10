using System;
using System.Linq;

namespace _05.Min_Even_Number
{
    public class MinEvenNumber
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .Where(x => Math.Abs(x) % 2 == 0)
                .OrderBy(x => x)
                .FirstOrDefault();
            
            if (numbers != 0)
            {
                Console.WriteLine($"{numbers:f2}");
            }
            else
            {
                Console.WriteLine("No match");
            }
        }
    }
}
