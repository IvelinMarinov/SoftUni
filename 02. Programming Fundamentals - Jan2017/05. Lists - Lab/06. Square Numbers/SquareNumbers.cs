using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Square_Numbers
{
    public class SquareNumbers
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();

            List<int> result = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (Math.Sqrt(numbers[i]) == (int)Math.Sqrt(numbers[i]))
                {
                    result.Add(numbers[i]);
                }
            }
            result.Sort();
            result.Reverse();

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
