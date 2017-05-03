using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.TriangleOfDollars
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            string rows = "";

            for (int i = 0; i < n; i++)
            {
                rows += "$ ";
                Console.WriteLine(rows);
            }


        }
    }
}
