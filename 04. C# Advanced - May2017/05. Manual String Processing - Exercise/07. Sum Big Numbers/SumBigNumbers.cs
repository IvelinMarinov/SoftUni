using System;

namespace _07.Sum_Big_Numbers
{
    public class SumBigNumbers
    {
        public static void Main()
        {
            var firstNum = Console.ReadLine().TrimStart(new[] { '0' });
            var secondNum = Console.ReadLine().TrimStart(new[] { '0' });

            firstNum = firstNum.PadLeft(Math.Max(firstNum.Length, secondNum.Length) + 1, '0');
            secondNum = secondNum.PadLeft(Math.Max(firstNum.Length, secondNum.Length), '0');

            var result = new int[firstNum.Length];
            int temp;

            for (int i = firstNum.Length - 1; i >= 1; i--)
            {
                temp = result[i] + ((int)firstNum[i] + (int)secondNum[i] - 96);
                result[i] = temp % 10;
                result[i - 1] = temp / 10;
            }

            var resultToPrint = string.Join("", result).TrimStart(new char[] { '0' });

            Console.WriteLine(resultToPrint);
        }
    }
}
