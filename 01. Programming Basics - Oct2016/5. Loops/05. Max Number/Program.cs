using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberCount = int.Parse(Console.ReadLine());
            var biggestNumer = int.MinValue;

            for (int i = 0; i < numberCount; i++)
            {
                var num = int.Parse(Console.ReadLine());

                if (num > biggestNumer)
                {
                    biggestNumer = num;
                }
            }

            Console.WriteLine(biggestNumer);
        }
    }
}
