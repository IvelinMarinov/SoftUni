using System;
using System.Linq;

namespace _03.Fold_and_Sum
{
    class FoldAndSum
    {
        static void Main()
        {
            var nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var k = nums.Length / 4;

            var upperRowLeft = new int[k];
            var upperRowRight = new int[k];
            var lowerRow = new int[2 * k];

            for (int i = 0; i < k; i++)
            {
                upperRowLeft[i] = nums[i];
                upperRowRight[i] = nums[3 * k + i];
                lowerRow[i] = nums[k + i];
                lowerRow[k + i] = nums[2 * k + i];
            }

            var temp1 = upperRowLeft.Reverse().ToArray();
            var temp2 = upperRowRight.Reverse().ToArray();

            var upperRowString = string.Join(" ", temp1) + " " + string.Join(" ", temp2);
            var upperRowFinal = upperRowString.Split(' ').Select(int.Parse).ToArray();

            var sum = new int[2* k];

            for (int i = 0; i < 2*k; i++)
            {
                sum[i] = upperRowFinal[i] + lowerRow[i];
            }

            var result = string.Join(" ", sum);
              
            Console.WriteLine(result);

        }
    }
}
