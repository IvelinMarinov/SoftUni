using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Geometry_Calculator
{
    class GeometryCalculator
    {
        static double CalculateTriangleArea(double side, double height)
        {
            return side * height / 2;
        }

        static double CalculateSquareArea(double side)
        {
            return Math.Pow(side, 2);
        }

        static double CalculateRectangleArea(double width, double height)
        {
            return width * height;
        }

        static double CalculateCircleArea(double radius)
        {
            return Math.PI * Math.Pow(radius, 2);
        }

        static void Main()
        {
            var figureType = Console.ReadLine();

            switch (figureType)
            {
                case "triangle":
                    double side = double.Parse(Console.ReadLine());
                    double height = double.Parse(Console.ReadLine());
                    Console.WriteLine("{0:0.00}", CalculateTriangleArea(side, height));
                    break;
                case "square":
                    side = double.Parse(Console.ReadLine());
                    Console.WriteLine("{0:0.00}", CalculateSquareArea(side));
                    break;
                case "rectangle":
                    double width = double.Parse(Console.ReadLine());
                    height = double.Parse(Console.ReadLine());
                    Console.WriteLine("{0:0.00}", CalculateRectangleArea(width, height));
                    break;
                case "circle":
                    double radius = double.Parse(Console.ReadLine());
                    Console.WriteLine("{0:0.00}", CalculateCircleArea(radius));
                    break;
                default:
                    break;
            }
        }
    }
}
