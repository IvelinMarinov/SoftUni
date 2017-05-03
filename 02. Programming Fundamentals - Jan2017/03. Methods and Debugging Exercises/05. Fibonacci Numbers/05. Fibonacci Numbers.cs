using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Fibonacci_Numbers
{
    class FibonacciNumbers
    {
        static long Fib(int n)
        {
            long fib0 = 0;
            long fib1 = 1;
            long fibSum = 0;

            for (int i = 0; i < n; i++)
            {
                fibSum = fib1 + fib0;
                fib0 = fib1;
                fib1 = fibSum;
            }
            return fibSum;
        }

        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            if (n == 0)
            {
                Console.WriteLine("1");
            }

            else
            {
                Console.WriteLine(Fib(n));
            }
        }
    }
}
