using System;
using System.Linq;

namespace _05.Rounding_Numbers
{
    class RoundingNumbers
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();

            for (int i = 0; i < input.Length; i++)
            {
                Console.WriteLine($"{input[i]} => {Math.Round(input[i], MidpointRounding.AwayFromZero)}");
            }

        }
    }
}
