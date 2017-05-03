using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Greatest_Common_Divisor__CGD_
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = int.Parse(Console.ReadLine());
            var b = int.Parse(Console.ReadLine());
            var temp = 0;

            while (b != 0)
            {
                temp = b;
                b = a % b;
                a = temp;
            }
            Console.WriteLine(a);
        }
    }
}
