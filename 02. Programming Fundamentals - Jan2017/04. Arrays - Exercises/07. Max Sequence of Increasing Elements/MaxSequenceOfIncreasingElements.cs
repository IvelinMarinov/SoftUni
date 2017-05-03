using System;
using System.Linq;

namespace _07.Max_Sequence_of_Increasing_Elements
{
    class MaxSequenceOfIncreasingElements
    {
        static void Main()
        {
            int[] nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var start = 0;
            var len = 1;
            var maxStart = 0;
            var maxLen = 0;

            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] < nums[i + 1])
                {
                    start = i - len + 1;
                    len++;

                    if (len > maxLen)
                    {
                        maxLen = len;
                        maxStart = start;
                    }
                }
                else
                {
                    len = 1;
                }
            }

            int[] result = new int[maxLen];

            for (int i = 0; i < maxLen; i++)
            {
                result[i] = nums[maxStart + i];
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
