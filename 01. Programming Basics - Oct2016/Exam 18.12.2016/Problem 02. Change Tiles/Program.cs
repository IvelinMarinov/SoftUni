using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_02.Change_Tiles
{
    class Program
    {
        static void Main(string[] args)
        {
            var budget = double.Parse(Console.ReadLine());
            var floorW = double.Parse(Console.ReadLine());
            var floorL = double.Parse(Console.ReadLine());
            var tileA = double.Parse(Console.ReadLine());
            var tileH = double.Parse(Console.ReadLine());
            var tilePrice = double.Parse(Console.ReadLine());
            var mountingCost = double.Parse(Console.ReadLine());

            var floorArea = floorL * floorW;
            var tileArea = (tileA * tileH) / 2;
            var tilesNeeded = Math.Ceiling(floorArea / tileArea);
            var tilesToBeBought = tilesNeeded + 5;
            var tilesCost = tilesToBeBought * tilePrice;
            var totalCost = tilesCost + mountingCost;

            var difference = Math.Abs(totalCost - budget);

            if (budget >= totalCost)
            {
                Console.WriteLine("{0:f2} lv left.", difference);
            }
            else
            {
                Console.WriteLine("You'll need {0:f2} lv more.", difference);
            }
        }
    }
}
