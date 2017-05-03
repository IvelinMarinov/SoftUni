using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.OddEvenPositions
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberCount = double.Parse(Console.ReadLine());
            var evenMin = double.MaxValue;
            var evenMax = double.MinValue;
            var oddMin = double.MaxValue;
            var oddMax = double.MinValue;
            var oddSum = 0.0;
            var evenSum = 0.0;

            for (int i = 1; i <= numberCount; i++)
            {
                var num = double.Parse(Console.ReadLine());

                if (i % 2 == 0)
                {
                    evenSum += num;
                    if (num < evenMin)
                    {
                        evenMin = num;
                    }
                    if (num > evenMax)
                    {
                        evenMax = num;
                    }
                }
                else
                {
                    oddSum += num;
                    if (num < oddMin)
                    {
                        oddMin = num;
                    }
                    if (num > oddMax)
                    {
                        oddMax = num;
                    }
                }
            }
            Console.WriteLine("OddSum={0}",oddSum);

            if (oddMin != double.MaxValue)
            {
                Console.WriteLine("OddMin={0}",oddMin);
            }
            else
            {
                Console.WriteLine("OddMin=No");
            }
            if (oddMax != double.MinValue)
            {
                Console.WriteLine("OddMax={0}",oddMax);
            }
            else
            {
                Console.WriteLine("OddMax=No");
            }

            Console.WriteLine("EvenSum={0}",evenSum);

            if (evenMin != double.MaxValue)
            {
                Console.WriteLine("EvenMin={0}",evenMin);
            }
            else
            {
                Console.WriteLine("EvenMin=No");
            }
            if (evenMax != double.MinValue)
            {
                Console.WriteLine("EvenMax={0}", evenMax);
            }
            else
            {
                Console.WriteLine("EvenMax=No");
            }
           

        }
    }
}
