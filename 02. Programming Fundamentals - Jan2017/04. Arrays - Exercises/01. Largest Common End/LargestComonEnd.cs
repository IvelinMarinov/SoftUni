using System;
using System.Linq;

namespace _01.Largest_Common_End
{
    class LargestComonEnd
    {
        static void Main()
        {
            var firstArr = Console.ReadLine().Split(' ');
            var secondArr = Console.ReadLine().Split(' ');

            var leftToRight = 0;

            for (int i = 0; i < Math.Min(firstArr.Length, secondArr.Length); i++)
            {
                if (firstArr[i] == secondArr[i])
                {
                    leftToRight++;
                }
            }

            var firstArrReversed = firstArr.Reverse().ToArray();
            var secondArrReversed = secondArr.Reverse().ToArray();
            var rightToLeft = 0;

            for (int j = 0; j < Math.Min(firstArrReversed.Length, secondArrReversed.Length); j++)
            {
                if (firstArrReversed[j] == secondArrReversed[j])
                {
                    rightToLeft++;
                }
            }

            var result = Math.Max(leftToRight, rightToLeft);

            Console.WriteLine(result);
        }
    }
}
