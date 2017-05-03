using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Count_Real_Numbers
{
    class CountRealNumbers
    {
        static void Main()
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToList();

            var result = new SortedDictionary<double, int>();

            foreach (var number in numbers)
            {
                if (!result.ContainsKey(number))
                {
                    result[number] = 0;
                }
                result[number]++;
            }

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
