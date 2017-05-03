using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Sum_big_numbers
{
    public class Program
    {
        public static void Main()
        {
            var firstInputNum = Console.ReadLine().TrimStart(new[] { '0' });
            var secondInputNum = Console.ReadLine().TrimStart(new[] { '0' });

            var firstNum = firstInputNum.PadLeft(Math.Max(firstInputNum.Length, secondInputNum.Length) + 1, '0');
            var secondNum = secondInputNum.PadLeft(Math.Max(firstInputNum.Length, secondInputNum.Length) + 1, '0');
            
            var result = new int[firstNum.Length];
            var temp = 0;

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
