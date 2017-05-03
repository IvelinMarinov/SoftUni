using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greater_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter two integers: ");
            var a = int.Parse(Console.ReadLine());
            var b = int.Parse(Console.ReadLine());
            Console.Write("Greater number: ");
            if (a > b)
            {
                Console.WriteLine(a);
            }
            else if (b > a)
            {
                Console.WriteLine(b);
            }

        }
    }
}
