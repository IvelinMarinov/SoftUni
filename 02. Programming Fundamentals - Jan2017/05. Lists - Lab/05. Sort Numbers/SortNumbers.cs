using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Sort_Numbers
{
    public class SortNumbers
    {
        public static void Main()
        {
            List<decimal> input = Console.ReadLine().Split().Select(decimal.Parse).ToList();

            input.Sort();

            Console.WriteLine(string.Join(" <= ", input));
        }
    }
}
