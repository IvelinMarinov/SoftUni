using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_3.Clever_Lilly
{
    class Program
    {
        static void Main(string[] args)
        {
            var age = int.Parse(Console.ReadLine());
            var washerPrice = double.Parse(Console.ReadLine());
            var priceToy = int.Parse(Console.ReadLine());

            var evenBdays = 0;
            var oddBdays = 0;
            var money = 0;
            var toys = 0;
            
            for (int i = 1; i <= age; i++)
            {
                if (i % 2 == 0)
                {
                    evenBdays++;
                    money += 10 * i / 2;
                    money--;
                }
                else
                {
                    oddBdays++;
                    toys++;
                }
            }

            var totalMoney = money + (toys * priceToy);
            var difference = Math.Abs(totalMoney - washerPrice);

            if (totalMoney > washerPrice)
            {
                Console.WriteLine("Yes! {0:f2}", difference);
            }
            else
            {
                Console.WriteLine("No! {0:f2}", difference);
            }

        }
    }
}
