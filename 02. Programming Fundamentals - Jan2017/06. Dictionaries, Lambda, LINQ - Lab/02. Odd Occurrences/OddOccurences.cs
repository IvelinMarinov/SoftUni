using System;
using System.Collections.Generic;
using System.Linq;


namespace _02.Odd_Occurrences
{
    class OddOccurences
    {
        static void Main()
        {
            var words = Console.ReadLine()
                .ToLower()
                .Split()
                .ToList();

            var occurences = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (!occurences.ContainsKey(word))
                {
                    occurences[word] = 0;
                }

                occurences[word]++;
            }

            var result = new List<string>();

            foreach (var item in occurences)
            {
                if (item.Value % 2 == 1)
                {
                    result.Add(item.Key);
                }
            }

            Console.WriteLine(string.Join(", ", result));
        }
    }
}
