using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Custom_Min_Function
{
    public class CustomMinFunction
    {
        public static void Main()
        {
            Func<List<int>, int> sorter = x => x.OrderBy(n => n).First();

            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            Console.WriteLine(sorter(input));
        }
    }
}
