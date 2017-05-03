using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Numbers_N._._._1
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            for (int i = n; i >= 1; i--)
            {
                Console.WriteLine(i);
            }
        }
    }
}
