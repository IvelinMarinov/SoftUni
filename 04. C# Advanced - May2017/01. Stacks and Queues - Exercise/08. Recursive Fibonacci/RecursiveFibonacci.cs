using System;

namespace _08.Recursive_Fibonacci
{
    public class RecursiveFibonacci
    {
        private static long[] fibNums;

        private static void Main()
        {
            var n = long.Parse(Console.ReadLine());
            fibNums = new long[n];

            long nthFibNum = GetFibNum(n);

            Console.WriteLine(nthFibNum);
        }

        private static long GetFibNum(long n)
        {
            if (n <= 2)
            {
                return 1;
            }
            if (fibNums[n - 1] != 0)
            {
                return fibNums[n - 1];
            }
            return fibNums[n - 1] = GetFibNum(n - 1) + GetFibNum(n - 2);
        }
    }
}
