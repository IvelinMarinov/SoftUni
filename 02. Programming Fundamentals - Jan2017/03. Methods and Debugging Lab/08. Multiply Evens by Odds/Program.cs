using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Multiply_Evens_by_Odds
{
    class Program
    {
        static int GetMultipleOfEvenAndOddSums(int number)
        {
            return SumOfEvenDigits(number) * SumOfOddDigits(number);
        }

        static int SumOfEvenDigits(int number)
        {
            var evenSum = 0;

            while (number > 0)
            {
                int lasDigit = number % 10;
                if (lasDigit % 2 == 0)
                {
                    evenSum += lasDigit;
                }
                number = number / 10;
            }
            return evenSum;
        }

        static int SumOfOddDigits(int number)
        {
            var oddSum = 0;

            while (number > 0)
            {
                int lasDigit = number % 10;
                if (lasDigit % 2 == 1)
                {
                    oddSum += lasDigit;
                }
                number = number / 10;
            }
            return oddSum;
        }

        static void Main(string[] args)
        {
            var number = Math.Abs(int.Parse(Console.ReadLine()));

            var result = GetMultipleOfEvenAndOddSums(number);

            Console.WriteLine(result);
        }
    }
}
