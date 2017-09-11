using System;

namespace _03.Shapes
{
    public class StartUp
    {
        public static void Main()
        {
            var circle = new Circle(3);
            var rectangle = new Rectangle(4, 5);

            Console.WriteLine(circle.CalculateArea());
            Console.WriteLine(circle.CalculatePerimeter());
            Console.WriteLine(circle.Draw());
            Console.WriteLine();
            Console.WriteLine(rectangle.CalculateArea());
            Console.WriteLine(rectangle.CalculatePerimeter());
            Console.WriteLine(rectangle.Draw());
        }
    }
}
