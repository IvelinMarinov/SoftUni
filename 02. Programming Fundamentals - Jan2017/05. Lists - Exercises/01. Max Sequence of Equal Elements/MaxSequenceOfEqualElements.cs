using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Max_Sequence_of_Equal_Elements
{
    class MaxSequenceOfEqualElements
    {
        static void Main()
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            List<int> currSubsequence = new List<int>();
            List<int> longestSubsequence = new List<int>();

            currSubsequence.Add(numbers[0]);

            for (int i = 1; i < numbers.Count; i++)
            {
                if (currSubsequence[0] == numbers[i])
                {
                    currSubsequence.Add(numbers[i]);
                }
                else
                {
                    if (currSubsequence.Count > longestSubsequence.Count)
                    {
                        longestSubsequence.Clear();
                        longestSubsequence.AddRange(currSubsequence);
                    }

                    currSubsequence.Clear();
                    currSubsequence.Add(numbers[i]);
                }
            }

            if (currSubsequence.Count > longestSubsequence.Count)
            {
                longestSubsequence.Clear();
                longestSubsequence.AddRange(currSubsequence);
            }

            Console.WriteLine(string.Join(" ", longestSubsequence));
        }
    }
}
