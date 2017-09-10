using System;
using System.Linq;

namespace _02.Sum_Numbers
{
    public class SumNumbers
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n))
                .ToList();

            Console.WriteLine(numbers.Count);
            Console.WriteLine(numbers.Sum());
        }
    }
}
