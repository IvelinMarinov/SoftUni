using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Circle_Area__12_Digits_Precision_
{
    class Program
    {
        static void Main(string[] args)
        {
            double radius = double.Parse(Console.ReadLine());

            double area = radius * radius * Math.PI;

            Console.WriteLine("{0:f12}", area);
        }
    }
}
