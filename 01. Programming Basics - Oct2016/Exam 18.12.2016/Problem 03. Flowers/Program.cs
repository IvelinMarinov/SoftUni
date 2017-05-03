using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_03.Flowers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numChrysanthemums = int.Parse(Console.ReadLine());
            var numRoses = int.Parse(Console.ReadLine());
            var numTulips = int.Parse(Console.ReadLine());
            var season = Console.ReadLine();
            var holiday = Console.ReadLine();

            var ChrysanthemumsPriceSS = 2.00;
            var ChrysanthemumsPriceAW = 3.75;
            var RosesPriceSS = 4.10;
            var RosesPriceAW = 4.50;
            var TulipsPriceSS = 2.50;
            var TulipsPriceAW = 4.15;

            var totalCost = 0.00;

            if (season == "Spring" || season == "Summer")
            {
                totalCost = (numChrysanthemums * ChrysanthemumsPriceSS) + (numRoses * RosesPriceSS) + (numTulips * TulipsPriceSS);
            }
            else
            {
                totalCost = (numChrysanthemums * ChrysanthemumsPriceAW) + (numRoses * RosesPriceAW) + (numTulips * TulipsPriceAW);

            }
            if (holiday == "Y")
            {
                totalCost *= 1.15;
            }
            if (season == "Spring" && numTulips > 7)
            {
                totalCost *= 0.95;
            }
            if (season == "Winter" && numRoses >= 10)
            {
                totalCost *= 0.9;
            }
            if (numChrysanthemums + numRoses + numTulips >= 20)
            {
                totalCost *= 0.8;
            }
            var finalCost = totalCost + 2;
            Console.WriteLine("{0:f2}", finalCost);
        }
    }
}