using System;

namespace _08.Multiply_big_number
{
    public class MultiplyBigNumber
    {
        public static void Main()
        {
            var firstNum = Console.ReadLine().TrimStart(new[] { '0' });
            var secondNum = int.Parse(Console.ReadLine());

            firstNum = firstNum.PadLeft(firstNum.Length + 1, '0');

            var result = new int[firstNum.Length];
            int temp;

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
