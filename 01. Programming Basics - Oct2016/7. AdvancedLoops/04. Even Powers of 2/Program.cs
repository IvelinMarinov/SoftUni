using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Even_Powers_of_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var num = 1;

            for (int i = 0; i <= n; i+=2)
            {
                Console.WriteLine(num);
                num *= 2 * 2;

            }
        }
    }
}
