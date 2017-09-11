using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.Rectangle_Intersection
{
    public class StartUp
    {
        public static void Main()
        {
            var parameters = Console.ReadLine().Split();
            var rectanglesNum = int.Parse(parameters[0]);
            var intersectionsNum = int.Parse(parameters[1]);
            var rectangles = new List<Rectangle>();

            for (int i = 0; i < rectanglesNum; i++)
            {
                var input = Console.ReadLine().Split();
                var id = input[0];
                var width = double.Parse(input[1]);
                var height = double.Parse(input[2]);
                var x = double.Parse(input[3]);
                var y = double.Parse(input[4]);
                var rectangle = new Rectangle(id, width, height, x, y);
                rectangles.Add(rectangle);
            }

            for (int i = 0; i < intersectionsNum; i++)
            {
                var input = Console.ReadLine().Split();
                var firstRectangleId = input[0];
                var seecondRectangleId = input[1];

                var firstRectangle = rectangles
                    .FirstOrDefault(r => r.Id == firstRectangleId);
                var secondRectangle = rectangles
                    .FirstOrDefault(r => r.Id == seecondRectangleId);

                var result = firstRectangle.InteresectsWith(secondRectangle);

                Console.WriteLine(result.ToString().ToLower());
            }
        }
    }
}
