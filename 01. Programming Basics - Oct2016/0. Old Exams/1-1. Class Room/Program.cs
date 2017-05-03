using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Class_Room1
{
    class Program
    {
        static void Main(string[] args)
        {
            var h = double.Parse(Console.ReadLine());
            var w = double.Parse(Console.ReadLine());

            var rows = Math.Truncate(h / 1.2);
            var deskPerRow = Math.Truncate((w - 1) / 0.7);
            var desks = (rows * deskPerRow) - 3;
            
            Console.WriteLine(desks);

        }
    }
}
