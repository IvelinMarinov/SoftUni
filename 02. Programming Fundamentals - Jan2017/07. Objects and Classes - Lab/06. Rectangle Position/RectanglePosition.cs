using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Rectangle_Position
{
    public class RectanglePosition
    {
        public static Rectangle InitializeRectangle(int[] rectangleInfo)
        {
            var newRectangle = new Rectangle()
            {
                Left = rectangleInfo[0],
                Top = rectangleInfo[1],
                Width = rectangleInfo[2],
                Height = rectangleInfo[3]
            };

            return newRectangle;
        }

        public static bool IsInside(Rectangle first, Rectangle second)
        {
            var leftIsCorrect = first.Left >= second.Left;
            var rightIsCorrect = first.Right <= second.Right;
            var topIsCorrect = first.Top >= second.Top;
            var bottomIsCorrect = first.Bottom <= second.Bottom;

            return leftIsCorrect && rightIsCorrect && topIsCorrect && bottomIsCorrect;          

        }

        public static void Main()
        {
            var firstRectangleInfo = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var firstRectangle = InitializeRectangle(firstRectangleInfo);

            var secondRectangleInfo = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var secondRectangle = InitializeRectangle(secondRectangleInfo);

            if (IsInside(firstRectangle, secondRectangle))
            {
                Console.WriteLine("Inside");
            }
            else
            {
                Console.WriteLine("Not inside");
            }
        }
    }
}
