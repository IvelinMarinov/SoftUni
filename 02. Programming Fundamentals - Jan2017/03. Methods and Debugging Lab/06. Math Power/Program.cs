using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Math_Power
{
    class Program
    {
        static double Power(double number, int power)
        {
            var result = 1.0;

            for (int i = 0; i < power; i++)
            {
                result *= number;
            }

            return result;
        }

        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            int power = int.Parse(Console.ReadLine());

            var result = Power(number, power);

            Console.WriteLine(result);
        }
    }
}
