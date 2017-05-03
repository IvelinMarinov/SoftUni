using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_1.Transport_Price
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var timeOfDay = Console.ReadLine();
            var price = 0.00;

            if (n > 0 && n < 20)
            {
                if (timeOfDay == "day")
                {
                    price = 0.7 + (n * 0.79);
                    Console.WriteLine(price);
                }
                else
                {
                    price = 0.7 + (n * 0.9);
                    Console.WriteLine(price);
                }
            }
            else if (n >= 20 && n < 100)
            {
                price = n * 0.09;
                Console.WriteLine(price);
            }
            else if (n >= 100)
            {
                price = n * 0.06;
                Console.WriteLine(price);
            }
        }
    }
}
