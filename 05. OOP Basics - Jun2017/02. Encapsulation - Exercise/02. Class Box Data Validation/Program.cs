using System;
using System.Linq;
using System.Reflection;

namespace _02.Class_Box_Data_Validation
{
    public class Program
    {
        public static void Main()
        {
            Type boxType = typeof(Box);
            FieldInfo[] fields = boxType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            Console.WriteLine(fields.Count());

            var width = double.Parse(Console.ReadLine());
            var length = double.Parse(Console.ReadLine());
            var height = double.Parse(Console.ReadLine());
            
            try
            {
                var parallelepiped = new Box(width, length, height);
                Console.WriteLine($"Surface Area - {parallelepiped.SurfaceArea():f2}");
                Console.WriteLine($"Lateral Surface Area - {parallelepiped.LateralSurfaceArea():f2}");
                Console.WriteLine($"Volume - {parallelepiped.Volume():f2}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
