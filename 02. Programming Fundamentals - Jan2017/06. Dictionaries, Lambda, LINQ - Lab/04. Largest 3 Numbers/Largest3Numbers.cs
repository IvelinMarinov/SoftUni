using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Largest_3_Numbers
{
    class Largest3Numbers
    {
        static void Main()
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            var result = numbers
                .OrderByDescending(x => x)
                .Take(3)
                .ToList();

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
