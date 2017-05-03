using System;
using System.Linq;

namespace _02.Rotate_and_Sum
{
    class RotateAndSum
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var rotations = int.Parse(Console.ReadLine());
            var n = numbers.Length;

            var sum = new int[n];

            for (int i = 1; i <= rotations; i++)
            {
                var rotatedNums = new int[n];

                for (int j = 0; j < n; j++)
                {
                    numbers[j] = rotatedNums[(j + 1) % n];                   
                }

                for (int k = 0; k < n; k++)
                {
                    sum[k] += rotatedNums[k];
                }

                numbers = rotatedNums;
            }
            var result = string.Join(" ", sum);

            Console.WriteLine(result);
        }
    }
}
