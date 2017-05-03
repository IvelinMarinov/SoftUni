using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _13.Factorial
{
    class FactorialTask
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

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(Factorial(n));
        }
    }
}
