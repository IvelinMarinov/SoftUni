using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point_On_Rectangle_Border
{
    class Program
    {
        static void Main(string[] args)
        {
            var x1 = int.Parse(Console.ReadLine());
            var y1 = int.Parse(Console.ReadLine());
            var x2 = int.Parse(Console.ReadLine());
            var y2 = int.Parse(Console.ReadLine());
            var x = int.Parse(Console.ReadLine());
            var y = int.Parse(Console.ReadLine());

            if (((x == x1 || x == x2) && (y >= y1 && y <= y2)) || ((y == y1 || y == y2) && (x >= x1 && x >= x2)))
            {
                Console.WriteLine("Border");
            }
           
           
            else
            {
                Console.WriteLine("Inside / Outside");
            }
        
          

        }
    }
}
