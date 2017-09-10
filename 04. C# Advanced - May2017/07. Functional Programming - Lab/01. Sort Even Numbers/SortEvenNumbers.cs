using System;
using System.Linq;

namespace _01.Sort_Even_Numbers
{
    public class SortEvenNumbers
    {
        public static void Main()
        {
            Console.WriteLine(string.Join(", ", Console.ReadLine()
                .Split(new[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n))
                .Where(n => n % 2 == 0)
                .OrderBy(n => n)
                .ToList()));
        }
    }
}
