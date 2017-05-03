using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Vegetable_Exchange
{
    class Program
    {
        static void Main(string[] args)
        {
            var priceVeggie = double.Parse(Console.ReadLine());
            var priceFruit = double.Parse(Console.ReadLine());
            var weightVeggie = int.Parse(Console.ReadLine());
            var weightFruit = int.Parse(Console.ReadLine());

            var revenue = (priceVeggie * weightVeggie) + (priceFruit * weightFruit);
            var revenueEUR = revenue / 1.94;
            Console.WriteLine(revenueEUR);


        }
    }
}
