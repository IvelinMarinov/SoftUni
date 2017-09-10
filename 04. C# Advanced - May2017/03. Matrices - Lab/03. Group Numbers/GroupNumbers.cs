using System;
using System.Linq;

namespace _03.Group_Numbers
{
    public class GroupNumbers
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new char[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var remainderZero = numbers.Where(x => Math.Abs(x % 3) == 0);
            var remainderOne = numbers.Where(x => Math.Abs(x % 3) == 1);
            var remainderTwo = numbers.Where(x => Math.Abs(x % 3) == 2);

            Console.WriteLine(string.Join(" ", remainderZero));
            Console.WriteLine(string.Join(" ", remainderOne));
            Console.WriteLine(string.Join(" ", remainderTwo));
        }
    }
}
