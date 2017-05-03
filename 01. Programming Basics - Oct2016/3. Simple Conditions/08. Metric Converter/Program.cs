using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputValue = double.Parse(Console.ReadLine());
            var inputVar = Console.ReadLine();
            var outputVar = Console.ReadLine();

            if (inputVar == "mm")
            {
                inputValue /= 1000;
            }
            else if (inputVar == "cm")
            {
                inputValue /= 100;
            }
            else if (inputVar == "mi")
            {
                inputValue /= 0.000621371192;
            }
            else if (inputVar == "in")
            {
                inputValue /= 39.3700787;
            }
            else if (inputVar == "km")
            {
                inputValue /= 0.001;
            }
            else if (inputVar == "ft")
            {
                inputValue /= 3.2808399;
            }
            else if (inputVar == "yd")
            {
                inputValue /= 1.0936133;
            }

            if (outputVar == "mm")
            {
                inputValue *= 1000;
            }
            else if (outputVar == "cm")
            {
                inputValue *= 100;
            }
            else if (outputVar == "mi")
            {
                inputValue *= 0.000621371192;
            }
            else if (outputVar == "in")
            {
                inputValue *= 39.3700787;
            }
            else if (outputVar == "km")
            {
                inputValue *= 0.001;
            }
            else if (outputVar == "ft")
            {
                inputValue *= 3.2808399;
            }
            else if (outputVar == "yd")
            {
                inputValue *= 1.0936133;
            }
            Console.WriteLine(inputValue);


        }
    }
}
