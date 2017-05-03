using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = double.Parse(Console.ReadLine());

            if (input <= 10)
            {
                Console.WriteLine("slow");
            }
            if (input > 10 && input <= 50)
            {
                Console.WriteLine("average");
            }
            if (input > 50 && input <= 150)
            {
                Console.WriteLine("fast");
            }
            if (input > 150 && input <= 1000)
            {
                Console.WriteLine("ultra fast");
            }
            if (input > 1000)
            {
                Console.WriteLine("extremely fast");
            }
        }
    }
}
