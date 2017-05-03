using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_1.Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var count1 = 0;
            var count2 = 0;
            var count3 = 0;
            var count4 = 0;
            var count5 = 0;

            for (int i = 0; i < n; i++)
            {
                var num = int.Parse(Console.ReadLine());
                if (num < 200)
                {
                    count1++;
                }
                else if (num >= 200 && num < 400)
                {
                    count2++;
                }
                else if (num >= 400 && num < 600)
                {
                    count3++;
                }
                else if (num >= 600 && num < 800)
                {
                    count4++;
                }
                else
                {
                    count5++;
                }
            }

            var percentage1 = count1 * 100.00 / n;
            var percentage2 = count2 * 100.00 / n;
            var percentage3 = count3 * 100.00 / n;
            var percentage4 = count4 * 100.00 / n;
            var percentage5 = count5 * 100.00 / n;

            Console.WriteLine("{0:f2}", percentage1);
            Console.WriteLine("{0:f2}", percentage2);
            Console.WriteLine("{0:f2}", percentage3);
            Console.WriteLine("{0:f2}", percentage4);
            Console.WriteLine("{0:f2}", percentage5);
        }
    }
}
