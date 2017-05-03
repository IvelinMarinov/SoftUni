using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaOfFigures
{
    class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();
            double one = 0;
            double two = 0;
            double area = 0;

            if (figure == "square")
            {
                one = double.Parse(Console.ReadLine());
                area = one * one;
            }
            else if (figure == "rectangle")
            {
                one = double.Parse(Console.ReadLine());
                two = double.Parse(Console.ReadLine());
                area = one * two;
            }
            else if (figure == "circle")
            {
                one = double.Parse(Console.ReadLine());
                area = one * one * Math.PI;
            }
            else if (figure == "triangle")
            {
                one = double.Parse(Console.ReadLine());
                two = double.Parse(Console.ReadLine());
                area = (one * two) / 2;
            }
            Console.WriteLine(Math.Round(area, 3));
        }
    }
}