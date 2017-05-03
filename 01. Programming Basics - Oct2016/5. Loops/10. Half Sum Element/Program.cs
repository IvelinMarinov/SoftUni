using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.NumEqualToTheRest
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberCount = int.Parse(Console.ReadLine());
            var sum = 0;
            var biggestNum = 0;

            for (int i = 0; i < numberCount; i++)
            {
                var num = int.Parse(Console.ReadLine());
                sum += num;

                if (num > biggestNum)
                {
                    biggestNum = num;
                }
            }

            if (biggestNum == (sum - biggestNum))
            {
                Console.WriteLine("Yes Sum = {0}", biggestNum);
            }
            else
            {
                Console.WriteLine("No Diff = {0}",Math.Abs(biggestNum - (sum - biggestNum)));
            }
        }
    }
}
