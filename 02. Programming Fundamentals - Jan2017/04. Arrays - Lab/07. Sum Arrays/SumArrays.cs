using System;
using System.Linq;

namespace _07.Sum_Arrays
{
    class SumArrays
    {
        static void Main()
        {
            var firstInput = Console.ReadLine();
            var secondInput = Console.ReadLine();

            var firstArr = firstInput.Split(' ').Select(int.Parse).ToArray();
            var secondArr = secondInput.Split(' ').Select(int.Parse).ToArray();

            var biggerArr = Math.Max(firstArr.Length, secondArr.Length);

            var sum = 0;

            for (int i = 0; i < biggerArr; i++)
            {
                sum = firstArr[i % firstArr.Length] + secondArr[i % secondArr.Length];
                Console.Write($"{sum} ");
            }
            Console.WriteLine();
        }
    }
}
