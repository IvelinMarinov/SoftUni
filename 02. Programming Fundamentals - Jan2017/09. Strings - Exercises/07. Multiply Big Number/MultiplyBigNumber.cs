using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Multiply_Big_Number
{
    public class MultiplyBigNumber
    {
        public static void Main()
        {
            var firstInputNum = Console.ReadLine().TrimStart(new[] { '0' });
            var secondNum = int.Parse(Console.ReadLine());

            var firstNum = firstInputNum.PadLeft(firstInputNum.Length + 1, '0');

            var result = new int[firstNum.Length];
            var temp = 0;

            for (int i = firstNum.Length - 1; i >= 1; i--)
            {
                temp = result[i] + ((int)firstNum[i] - 48) * secondNum;
                result[i] = temp % 10;
                result[i - 1] = temp / 10;
            }

            var resultToPrint = string.Join("", result).TrimStart(new char[] { '0' });

            if (secondNum == 0)
            {
                resultToPrint = "0";
            }

            Console.WriteLine(resultToPrint);
        }
    }
}
