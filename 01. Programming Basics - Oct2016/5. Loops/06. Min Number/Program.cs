using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberCount = int.Parse(Console.ReadLine());
            var smallestNumer = int.MaxValue;

            for (int i = 0; i < numberCount; i++)
            {
                var num = int.Parse(Console.ReadLine());

                if (num < smallestNumer)
                {
                    smallestNumer = num;
                }
            }
            Console.WriteLine(smallestNumer);
        }
    }
}

