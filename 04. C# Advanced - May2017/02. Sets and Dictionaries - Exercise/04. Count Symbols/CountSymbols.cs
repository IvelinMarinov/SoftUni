using System;
using System.Collections.Generic;

namespace _04.Count_Symbols
{
    public class CountSymbols
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var summary = new SortedDictionary<char, int>();

            foreach (var ch in input)
            {
                if (!summary.ContainsKey(ch))
                {
                    summary[ch] = 1;
                }
                else
                {
                    summary[ch]++;
                }
            }

            foreach (var kvp in summary)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}
