﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_1.Stupid_Password_Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var l = int.Parse(Console.ReadLine());

            for (var d1 = 1; d1 <= n; d1++)
            {
                for (var d2 = 1; d2 <= n; d2++)
                {
                    for (var l1 = 'a'; l1 < 'a' + l; l1++)
                    {
                        for (var l2 = 'a';  l2 < 'a' + l; l2++)
                        {
                            for (var d3 = Math.Max(d1, d2) + 1; d3 <=n ; d3++)
                            {
                                Console.Write("{0}{1}{2}{3}{4} ", d1, d2, l1, l2, d3);
                            }
                        }
                    }
                }
            }
            Console.WriteLine();
            
        }
    }
}
