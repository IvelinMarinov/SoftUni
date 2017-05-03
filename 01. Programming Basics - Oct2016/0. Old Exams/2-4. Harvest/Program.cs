using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_4.Harvest
{
    class Program
    {
        static void Main(string[] args)
        {
            var area = int.Parse(Console.ReadLine());
            var yield = double.Parse(Console.ReadLine());
            var wineTarget = int.Parse(Console.ReadLine());
            var numWorkers = int.Parse(Console.ReadLine());

            var grapePerLWine = 2.5;
            var harvest = area * yield;
            var totalWine = harvest * 0.4 / grapePerLWine;
            var difference = Math.Abs(totalWine - wineTarget);

            if (totalWine < wineTarget)
            {
                Console.WriteLine("It will be a tough winter! More {0} liters wine needed.", Math.Floor(difference));
            }
            else
            {
                Console.WriteLine("Good harvest this year! Total wine: {0} liters.", Math.Floor(totalWine));
                Console.WriteLine("{0} liters left -> {1} liters per person.", Math.Ceiling(difference), Math.Ceiling(difference/numWorkers));
            }

        }
    }
}
