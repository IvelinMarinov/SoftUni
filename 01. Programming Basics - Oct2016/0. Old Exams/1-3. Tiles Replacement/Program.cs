using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Tiles_Replacement
{
    class Program
    {
        static void Main(string[] args)
        {
            var areaSide = int.Parse(Console.ReadLine());
            var tileWidth = double.Parse(Console.ReadLine());
            var tileHeight = double.Parse(Console.ReadLine());
            var benchWidth = int.Parse(Console.ReadLine());
            var benchHeight = int.Parse(Console.ReadLine());

            var tiles = ((areaSide * areaSide) - (benchHeight * benchWidth)) / (tileHeight * tileWidth);
            Console.WriteLine(tiles);
            var timeNeeded = tiles * 0.2;
            Console.WriteLine(timeNeeded);
        }
    }
}
