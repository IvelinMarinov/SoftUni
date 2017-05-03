using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_2.Division_with_nothing_left
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var count1 = 0;
            var count2 = 0;
            var count3 = 0;

            for (int i = 0; i < n; i++)
            {
                var num = int.Parse(Console.ReadLine());
                if (num % 2 == 0)
                {
                    count1++;
                }
                if (num % 3 == 0)
                {
                    count2++;
                }
                if (num % 4 == 0)
                {
                    count3++;
                }
            }
            var percentage1 = count1 * 100.0 / n; 
            var percentage2 = count2 * 100.0 / n;
            var percentage3 = count3 * 100.0 / n;

            Console.WriteLine("{0:f2}%", percentage1);
            Console.WriteLine("{0:f2}%", percentage2);
            Console.WriteLine("{0:f2}%", percentage3);

        }
    }
}
