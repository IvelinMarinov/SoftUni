using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.Sunglasses
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var line = "";

            Console.WriteLine(new string('*', 2 * n) + new string(' ', n) + new string('*', 2 * n));

            for (int i = 0; i < n - 2; i++)
            {
                if (i == ((n - 1) / 2) - 1)
                {
                    Console.WriteLine("{0}{1}{0}{2}{0}{1}{0}", "*", new string('/', 2 * n - 2), new string('|', n));
                }
                else
                {
                    Console.WriteLine("{0}{1}{0}{2}{0}{1}{0}", "*", new string('/', 2 * n - 2), new string(' ', n));

                }
            }
            Console.WriteLine(new string('*', 2 * n) + new string(' ', n) + new string('*', 2 * n));


        }
    }
}
