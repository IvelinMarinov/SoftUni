using System;

namespace _09.Longer_Line
{
    class LongerLineTask

    {
        static double CalculateHypotenuse(double leg1, double leg2)
        {
            return Math.Sqrt(Math.Pow(leg1, 2) + Math.Pow(leg2, 2));
        }

        static void ClosestPoint(double x1, double y1, double x2, double y2)
        {
            double distance1 = CalculateHypotenuse(x1, y1);
            double distance2 = CalculateHypotenuse(x2, y2);

            if (distance1 <= distance2)
            {
                Console.WriteLine($"({x1}, {y1})({x2}, {y2})");
            }
            else
            {
                Console.WriteLine($"({x2}, {y2})({x1}, {y1})");
            }
        }

        static void LongerLine(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4)
        {
            double sideATriangle12 = Math.Abs(y1 - y2);
            double sideBTriangle12 = Math.Abs(x1 - x2);
            double lenghtLine12 = CalculateHypotenuse(sideATriangle12, sideBTriangle12);

            double sideATriangle34 = Math.Abs(y3 - y4);
            double sideBTriangle34 = Math.Abs(x3 - x4);
            double lenghtLine34 = CalculateHypotenuse(sideATriangle34, sideBTriangle34);

            if (lenghtLine12 >= lenghtLine34)
            {
                ClosestPoint(x1, y1, x2, y2);
            }
            else
            {
                ClosestPoint(x3, y3, x4, y4);
            }
        }

        static void Main()
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double x3 = double.Parse(Console.ReadLine());
            double y3 = double.Parse(Console.ReadLine());
            double x4 = double.Parse(Console.ReadLine());
            double y4 = double.Parse(Console.ReadLine());

            LongerLine(x1, y1, x2, y2, x3, y3, x4, y4);
        }
    }
}
