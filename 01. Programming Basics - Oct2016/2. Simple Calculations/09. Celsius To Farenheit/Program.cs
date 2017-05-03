using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Celsius_To_Farenheit
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter temperature in C: ");
            var tempC = double.Parse(Console.ReadLine());
            var tempF = (tempC * 1.8) + 32;
            var tempFRounded = Math.Round(tempF, 2);
            Console.WriteLine("Temperature in F is: " + tempFRounded);
        }
    }
}
