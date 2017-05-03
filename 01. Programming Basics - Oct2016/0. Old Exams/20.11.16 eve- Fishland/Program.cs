using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20._11._16_eve__Fishland
{
    class Program
    {
        static void Main(string[] args)
        {
            var priceSkumria = double.Parse(Console.ReadLine());
            var priceCaca = double.Parse(Console.ReadLine());
            var quantityPalamud = double.Parse(Console.ReadLine());
            var quantitySafrid = double.Parse(Console.ReadLine());
            var quantityMidi = int.Parse(Console.ReadLine());

            var pricePalamud = priceSkumria * 1.6;
            var priceSafrid = priceCaca * 1.8;
            var priceMidi = 7.5;

            var totalPalamud = pricePalamud * quantityPalamud;
            var totalSafrid = priceSafrid * quantitySafrid;
            var totalMidi = 7.5 * quantityMidi;

            var totalExpenditure = totalPalamud + totalSafrid + totalMidi;
            Console.WriteLine("{0:f2}", totalExpenditure);

            

        }
    }
}
