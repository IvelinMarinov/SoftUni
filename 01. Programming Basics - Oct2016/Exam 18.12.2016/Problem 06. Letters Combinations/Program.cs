using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_06.Letters_Combinations
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = Console.ReadLine();
            var b = Console.ReadLine();
            var c = Console.ReadLine();

            var A = Convert.ToChar(a);
            var B = Convert.ToChar(b);
            var C = Convert.ToChar(c);

            var combinations = 0;

            for (var i = A; i <= B; i++)
            {
                for (var j = A; j <= B; j++)
                {
                    for (var k = A; k <= B; k++)
                    {
                        if (i == C || j == C || k == C)
                        {
                            continue;
                        }
                        Console.Write("{0}{1}{2} ", i, j, k);
                        combinations++;
                    }
                }
            }
            Console.Write(combinations);
            Console.WriteLine();
        }
    }
}
