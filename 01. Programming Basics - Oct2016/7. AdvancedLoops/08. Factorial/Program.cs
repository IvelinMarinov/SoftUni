using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var factorial = 1;

            for (int i = 1; i <= n; i++)
            {
                factorial *= i;
            }
            Console.WriteLine(factorial);
        }
    }
}
