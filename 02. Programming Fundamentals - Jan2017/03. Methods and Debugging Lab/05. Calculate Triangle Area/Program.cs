using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Calculate_Triangle_Area
{
    class Program
    {
        static double TriangleArea(double side, double height)
        {
            return (side * height) / 2;
        }

        static void Main(string[] args)
        {
            var side = double.Parse(Console.ReadLine());
            var height = double.Parse(Console.ReadLine());
            var area = TriangleArea(side, height);

            Console.WriteLine(area);
        }
    }
}
