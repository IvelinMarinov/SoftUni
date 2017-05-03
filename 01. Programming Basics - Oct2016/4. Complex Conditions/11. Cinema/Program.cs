using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            var projection = Console.ReadLine().ToLower();
            var rows = int.Parse(Console.ReadLine());
            var columns = int.Parse(Console.ReadLine());
            var ticketPrice = 0.0;

            if (projection == "premiere")
            {
                ticketPrice = 12;
            }
            else if (projection == "normal")
            {
                ticketPrice = 7.5;
            }
            else if (projection == "discount")
            {
                ticketPrice = 5;
            }
            else
            {
                Console.WriteLine("error");
            }

            Console.WriteLine("{0:f2}", ticketPrice * rows * columns);
            
        }
    }
}
