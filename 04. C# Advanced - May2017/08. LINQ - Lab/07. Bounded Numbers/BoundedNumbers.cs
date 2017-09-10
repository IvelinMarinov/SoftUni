using System;
using System.Linq;

namespace _07.Bounded_Numbers
{
    public class BoundedNumbers
    {
        public static void Main()
        {
            var bounds = Console.ReadLine()
                .Split()
                .Select(int.Parse);

            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Where(n => bounds.Min() <= n && n <= bounds.Max())
                .ToList();

            numbers.ForEach(n => Console.Write($"{n} "));
        }
    }
}
