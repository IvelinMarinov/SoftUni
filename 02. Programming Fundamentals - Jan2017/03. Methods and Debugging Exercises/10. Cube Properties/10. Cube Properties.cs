using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Cube_Properties
{
    class CubeProperties
    {
        static double CalculateFaceDiagonals(double s)
        {
            return Math.Sqrt(2 * Math.Pow(s, 2));
        }

        static double CalculateSpaceDiagonals(double s)
        {
            return Math.Sqrt(3 * Math.Pow(s, 2));
        }

        static double CalculateVolume(double s)
        {
            return Math.Pow(s, 3);
        }

        static double CalculateArea(double s)
        {
            return 6 * Math.Pow(s, 2);
        }

        static void Main()
        {
            var s = double.Parse(Console.ReadLine());
            string property = Console.ReadLine();

            switch (property)
            {
                case "face":
                    Console.WriteLine("{0:0.00}", CalculateFaceDiagonals(s));
                    break;
                case "space":
                    Console.WriteLine("{0:0.00}", CalculateSpaceDiagonals(s));
                    break;
                case "volume":
                    Console.WriteLine("{0:0.00}", CalculateVolume(s));
                    break;
                case "area":
                    Console.WriteLine("{0:0.00}", CalculateArea(s));
                    break;
                default:
                    break;
            }
        }
    }
}
