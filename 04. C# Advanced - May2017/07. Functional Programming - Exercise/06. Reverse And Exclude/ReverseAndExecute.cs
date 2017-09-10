using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Reverse_And_Exclude
{
    public class ReverseAndExecute
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            var filterNum = int.Parse(Console.ReadLine());

            Func<List<int>, List<int>> func = x => x.Where(y => y % filterNum != 0).Reverse().ToList();

            Console.WriteLine(string.Join(" ", func(numbers)));
        }
    }
}
