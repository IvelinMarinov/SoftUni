using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _14.Factorial_Trailing_Zeroes
{
    class Program
    {
        static BigInteger Factorial(int n)
        {
            BigInteger factorial = 1;

            for (int i = 1; i <= n; i++)
            {
                factorial *= i;
            }
            return factorial;
        }

        static int TrailingZeroes(BigInteger factorial)
        {
            int count = 0;

            while (factorial > 0)
            {
                if (factorial % 10 == 0)
                {
                    count++;
                    factorial = factorial / 10;
                }
                else
                {
                    break;
                }
            }
            return count;
        }

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            BigInteger factorial = Factorial(n);

            Console.WriteLine(TrailingZeroes(factorial));
        }
    }
}
