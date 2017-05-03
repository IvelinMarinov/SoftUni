﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Center_Point
{
    class CenterPoint

    {
        static void ClosestPoint(double x1, double y1, double x2, double y2)
        {
            double distance1 = Math.Sqrt((x1 * x1) + (y1 * y1));
            double distance2 = Math.Sqrt((x2 * x2) + (y2 * y2));

            if (distance1 <= distance2)
            {
                Console.WriteLine($"({x1}, {y1})");
            }
            else
            {
                Console.WriteLine($"({x2}, {y2})");
            }
        }

        static void Main()
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            ClosestPoint(x1, y1, x2, y2);
        }
    }
}
