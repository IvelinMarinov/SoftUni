using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Custom_Comparator
{
    public class CustomComparator
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            Func<List<int>, List<int>> evensSorter = x => x.Where(y => Math.Abs(y) % 2 == 0).OrderBy(y => y).ToList();
            Func<List<int>, List<int>> oddsSorter = x => x.Where(y => Math.Abs(y) % 2 == 1).OrderBy(y => y).ToList();
            Action<List<int>> printer = x => Console.WriteLine(string.Join(" ", x));

            var sortedNumbers = new List<int>();
            sortedNumbers.AddRange(evensSorter(numbers));
            sortedNumbers.AddRange(oddsSorter(numbers));
            printer(sortedNumbers);
        }
    }
}
