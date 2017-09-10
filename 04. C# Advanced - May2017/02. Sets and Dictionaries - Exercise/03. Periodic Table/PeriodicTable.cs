using System;
using System.Collections.Generic;

namespace _03.Periodic_Table
{
    public class PeriodicTable
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            string[] input;
            var set = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                input = Console.ReadLine()
                    .Split();

                foreach (var element in input)
                {
                    set.Add(element);
                }
            }

            Console.WriteLine(string.Join(" ", set));
        }
    }
}
