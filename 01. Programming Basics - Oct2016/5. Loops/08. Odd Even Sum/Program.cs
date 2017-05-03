using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddEvenSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberCount = int.Parse(Console.ReadLine());
            var oddSum = 0;
            var evenSum = 0;

            for (int i = 0; i < numberCount; i++)
            {
                var num = int.Parse(Console.ReadLine());
               
                if (i % 2 == 0)
                {
                    evenSum += num;
                }
                else if (i % 2 !=0)
                {
                    oddSum += num;
                }
            }
            if (oddSum == evenSum)
            {
                Console.WriteLine("Yes Sum = {0}", oddSum);
            }
            else
            {
                Console.WriteLine("No Diff = {0}", Math.Abs(oddSum - evenSum));
            }
            
        }
    }
}
