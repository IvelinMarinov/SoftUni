using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fruit_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            var fruit = Console.ReadLine().ToLower();
            var day = Console.ReadLine().ToLower();
            var quantity = double.Parse(Console.ReadLine());
            var price = -1.0;

            if (day == "monday" || day == "tuesday" || day == "wednesday" || day == "thursday" || day == "friday")
            {
                if (fruit == "banana")
                {
                    price = 2.5;
                }
                else if (fruit == "apple")
                {
                    price = 1.2;
                }
                else if (fruit == "orange")
                {
                    price = 0.85;
                }
                else if (fruit == "grapefruit")
                {
                    price = 1.45;
                }
                else if (fruit == "kiwi")
                {
                    price = 2.7;
                }
                else if (fruit == "pineapple")
                {
                    price = 5.5;
                }
                else if (fruit == "grapes")
                {
                    price = 3.85;
                }
                else
                {
                    Console.WriteLine("error");
                }
            }

            else if (day == "saturday" || day == "sunday")
            {
                if (fruit == "banana")
                {
                    price = 2.7;
                }
                else if (fruit == "apple")
                {
                    price = 1.25;
                }
                else if (fruit == "orange")
                {
                    price = 0.9;
                }
                else if (fruit == "grapefruit")
                {
                    price = 1.6;
                }
                else if (fruit == "kiwi")
                {
                    price = 3;
                }
                else if (fruit == "pineapple")
                {
                    price = 5.6;
                }
                else if (fruit == "grapes")
                {
                    price = 4.2;
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else
            {
                Console.WriteLine("error");
            }


            if (price >= 0)
            {
                Console.WriteLine("{0:f2}", price * quantity);
            }
            else
            {
                Console.WriteLine("error");
            }
        }    
    }
}
