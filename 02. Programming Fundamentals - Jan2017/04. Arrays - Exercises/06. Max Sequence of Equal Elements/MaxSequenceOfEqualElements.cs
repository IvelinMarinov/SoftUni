using System;
using System.Linq;

namespace _06.Max_Sequence_of_Equal_Elements
{
    class MaxSequenceOfEqualElements
    {
        static void Main()
        {
            int[] nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var start = 0;
            var len = 1;
            var maxStart = 0;
            var maxLen = 1;

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[start] == nums[i])
                {
                    len++;
                    if (len > maxLen)
                    {
                        maxLen = len;
                        maxStart = start;
                    }
                }
                else
                {
                    start = i;
                    len = 1;
                }
            }

            int[] result = new int[maxLen];

            for (int i = 0; i < maxLen; i++)
            {
                result[i] = nums[i + maxStart];
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
