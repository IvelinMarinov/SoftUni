using System;
using System.Linq;

namespace _10.Pairs_by_Difference
{
    class PairsByDifference
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int difference = int.Parse(Console.ReadLine());

            var counter = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i; j < numbers.Length; j++)
                {
                    if (difference == Math.Abs(numbers[i] - numbers[j]))
                    {
                        counter++;
                    }
                }
            }

            Console.WriteLine(counter);
           
        }
    }
}
