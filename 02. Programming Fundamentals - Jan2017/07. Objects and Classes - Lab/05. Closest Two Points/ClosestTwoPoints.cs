using System;
using System.Linq;

namespace _05.Closest_Two_Points
{
    public class ClosestTwoPoints
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var pointsArr = new Point[n];

            for (int i = 0; i < n; i++)
            {
                var pointCoordinates = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

                Point currPoint = new Point()
                {
                    X = pointCoordinates[0],
                    Y = pointCoordinates[1]
                };

                pointsArr[i] = currPoint;
            }

            var distance = 0.0;
            var MinDistance = double.MaxValue;
            Point startPoint = null;
            Point endPoint = null;

            for (int i = 0; i < pointsArr.Length - 1; i++)
            {
                for (int j = 1 + i; j < pointsArr.Length; j++)
                {
                    distance = CalculateDistance(pointsArr[i], pointsArr[j]);

                    if (distance < MinDistance)
                    {
                        MinDistance = distance;
                        startPoint = pointsArr[i];
                        endPoint = pointsArr[j];
                    }
                }
            }

            Console.WriteLine($"{MinDistance:f3}");
            Console.WriteLine($"({startPoint.X}, {startPoint.Y})");
            Console.WriteLine($"({endPoint.X}, {endPoint.Y})");
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
