using System;
using System.Linq;

namespace _08.Condense_Array_to_Number
{
    class CondenseArrayToNum
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            if (numbers.Length == 1)
            {
                Console.WriteLine(numbers[0]);
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                var condensedNums = new int[numbers.Length - 1];

                for (int j = 0; j < numbers.Length - 1; j++)
                {
                    condensedNums[j] = numbers[j] + numbers[j + 1];
                }

                numbers = condensedNums;
            }

            Console.WriteLine(numbers[0]);
        }
    }
}
