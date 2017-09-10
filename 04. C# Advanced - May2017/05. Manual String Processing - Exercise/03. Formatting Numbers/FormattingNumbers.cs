using System;

namespace _03.Formatting_Numbers
{
    public class FormattingNumbers
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split(new []{' ', '\t', '\n'},StringSplitOptions.RemoveEmptyEntries);

            var firstNum = int.Parse(numbers[0]);
            var secondNum = double.Parse(numbers[1]);
            var thirdNum = double.Parse(numbers[2]);

            var firstNumAsHexPadded = Convert.ToString(firstNum, 16).PadRight(10, ' ').ToUpper();
            var firstNumAsBinaryPadded = Convert.ToString(firstNum, 2).PadLeft(10, '0');

            if (firstNumAsBinaryPadded.Length > 10)
            {
                firstNumAsBinaryPadded = firstNumAsBinaryPadded.Substring(0, 10);
            }

            secondNum = Math.Round(secondNum, 2);
            thirdNum = Math.Round(thirdNum, 3);

            var secondNumAsString = secondNum.ToString();
            var thirdNumAsString = thirdNum.ToString();

            secondNumAsString = AddTrailingZeros(secondNumAsString, 2);
            thirdNumAsString = AddTrailingZeros(thirdNumAsString, 3);

            var secondNumPadded = secondNumAsString.PadLeft(10, ' ');
            var thirdNumPadded = thirdNumAsString.PadRight(10, ' ');

            Console.WriteLine($"|{firstNumAsHexPadded}|{firstNumAsBinaryPadded}|{secondNumPadded}|{thirdNumPadded}|");
        }

        private static string AddTrailingZeros(string num, int numOfTrailingZeroes)
        {
            var indexOfFloatingPoint = num.IndexOf(".");

            if (indexOfFloatingPoint != -1)
            {
                var stringAfterFloatingPoint = num.Substring(indexOfFloatingPoint, num.Length - indexOfFloatingPoint);

                if (stringAfterFloatingPoint.Length < numOfTrailingZeroes + 1)
                {
                    stringAfterFloatingPoint = stringAfterFloatingPoint.PadRight(numOfTrailingZeroes + 1, '0');
                }
                else if (stringAfterFloatingPoint.Length > numOfTrailingZeroes + 1)
                {
                    stringAfterFloatingPoint = stringAfterFloatingPoint.Substring(0, numOfTrailingZeroes + 1);
                }
                var stringBeforeFloatingPoinnt = num.Substring(0, indexOfFloatingPoint);
                num = String.Concat(stringBeforeFloatingPoinnt, stringAfterFloatingPoint);
            }
            else
            {
                num = string.Concat(num, '.', new string('0', numOfTrailingZeroes));
            }

            return num;
        }
    }
}
