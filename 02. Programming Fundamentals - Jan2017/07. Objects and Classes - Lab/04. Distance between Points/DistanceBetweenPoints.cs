using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Distance_between_Points
{
    public class DistanceBetweenPoints
    {
        public static void Main()
        {
            var firstPointCoordinates = Console.ReadLine()
                .Split().
                Select(int.Parse)
                .ToArray();

            var secondPointCoordinates = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Point firstPoint = new Point()
            {
                X = firstPointCoordinates[0],
                Y = firstPointCoordinates[1]
            };

            Point secondPoint = new Point()
            {
                X = secondPointCoordinates[0],
                Y = secondPointCoordinates[1]
            };

            var distance = CalculateDistance(firstPoint, secondPoint);

            Console.WriteLine($"{distance:f3}");
        }

        public static double CalculateDistance(Point firstPoint, Point secondPoint)
        {
            var deltaX = firstPoint.X - secondPoint.X;
            var deltaY = firstPoint.Y - secondPoint.Y;

            var distance = Math.Sqrt((deltaX * deltaX) + (deltaY * deltaY));

            return distance;
        }
    }
}
