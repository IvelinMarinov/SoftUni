using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Master_Number
{
    class MasterNumber
    {
        static int IsPalindrome(int number)
        {
            int reversedNumber = 0;

            while (number > 0)
            {
                reversedNumber = reversedNumber * 10 + number % 10;
                number /= 10;
            }
            return reversedNumber;
        }

        static bool IsSumofDigitsDivisibleBySeven(int number)
        {
            int sumOfDigits = 0;

            while (number > 0)
            {
                var digit = number % 10;
                sumOfDigits += digit;
                number = number / 10;
            }

            return (sumOfDigits % 7 == 0);           
        }

        static bool ContainsEvenDigit(int number)
        {
            while (number > 0)
            {
                var digit = number % 10;
                if (digit % 2 == 0)
                {
                    return true;
                }
                number = number / 10;
            }
            return false;
        }

        static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 232; i <= number; i++)
            {
                if (i == IsPalindrome(i) && IsSumofDigitsDivisibleBySeven(i) && ContainsEvenDigit(i))
                {
                    Console.WriteLine(i);
                }
            }

        }
    }
}