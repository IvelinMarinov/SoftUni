using System;
using System.Numerics;

namespace _03.Big_Factorial
{
    class BigFactorial
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            BigInteger Fact = 1;

            for (int i = 2; i <= n; i++)
            {
                Fact *= i;
            }

            Console.WriteLine(Fact);
        }
    }
}
