using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Sum_Adjacent_Equal_Numbers
{
    public class SumAdjacentEqualNums
    {
        public static void Main()
        {
            List<decimal> input = Console.ReadLine().Split(' ').Select(decimal.Parse).ToList();

            for (int i = 0; i < input.Count - 1; i++)
            {
                if (input[i] == input[i + 1])
                {
                    var sum = input[i] + input[i + 1];
                    input[i] = sum;
                    input.Remove(input[i + 1]);
                    i = -1;
                }
            }

            Console.WriteLine(string.Join(" ", input));
        }
    }
}
