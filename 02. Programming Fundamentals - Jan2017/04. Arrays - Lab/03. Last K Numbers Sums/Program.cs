using System;

namespace _03.Last_K_Numbers_Sums
{
    class LastKNumbersSums
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var k = int.Parse(Console.ReadLine());

            var seq = new long[n];
            seq[0] = 1;

            for (int i = 1; i < n; i++)
            {
                long sum = 0;
                for (int j = i - 1; j >= 0 && j >= i - k; j--)
                {
                    sum += seq[j];
                }
                seq[i] = sum;
            }

            Console.WriteLine(string.Join(" ", seq));
        }
    }
}
