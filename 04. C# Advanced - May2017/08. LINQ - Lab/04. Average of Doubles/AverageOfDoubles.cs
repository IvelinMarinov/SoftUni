using System;
using System.Linq;

namespace _04.Average_of_Doubles
{
    public class AverageOfDoubles
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .Average();

            Console.WriteLine($"{input:f2}");
        }
    }
}
