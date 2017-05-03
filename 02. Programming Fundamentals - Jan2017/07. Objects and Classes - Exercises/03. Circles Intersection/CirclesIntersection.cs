using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Circles_Intersection
{
    public class CirclesIntersection
    {
        public static Circle InitializeCircle(int[] circleInfo)
        {
            var currCenter = new Point()
            {
                X = circleInfo[0],
                Y = circleInfo[1],
            };

            var currCircle = new Circle()
            {
                Radius = circleInfo[2],
                Center = currCenter
            };

            return currCircle;
        }

        public static bool Intersects(Circle firstCircle, Circle secondCircle)
        {
            var deltaX = firstCircle.Center.X - secondCircle.Center.X;
            var deltaY = firstCircle.Center.Y - secondCircle.Center.Y;

            var distance = Math.Sqrt((deltaX * deltaX) + (deltaY * deltaY));

            if (distance <= firstCircle.Radius + secondCircle.Radius)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public static void Main()
        {
            var firstCircleInfo = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var firstCircle = InitializeCircle(firstCircleInfo);

            var secondCircleInfo = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var secondCircle = InitializeCircle(secondCircleInfo);

            if (Intersects(firstCircle, secondCircle))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }

        }
    }
}
