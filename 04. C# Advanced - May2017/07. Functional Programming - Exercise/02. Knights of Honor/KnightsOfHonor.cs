using System;
using System.Linq;

namespace _02.Knights_of_Honor
{
    public class KnightsOfHonor
    {
        public static void Main()
        {
            Action<string> knighting = n => Console.WriteLine($"Sir {n}");

            Console.ReadLine()
                .Split(new[] {' ', '\t', '\n'}, StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(knighting);
        }
    }
}
