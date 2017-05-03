using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_2.Magic_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            for (var d1 = 1; d1 <= 9; d1++)
            {
                for (var d2 = 1; d2 <= 9; d2++)
                {
                    for (var d3 = 1; d3 <= 9; d3++)
                    {
                        for (var d4 = 1; d4 <= 9; d4++)
                        {
                            for (var d5 = 1; d5 <= 9; d5++)
                            {
                                for (var d6 = 1; d6 <= 9; d6++)
                                {
                                    if (d1 * d2* d3 * d4 * d5 * d6 == n)
                                    {
                                        Console.Write("{0}{1}{2}{3}{4}{5} ", d1, d2, d3, d4, d5, d6);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
