using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputNumber = int.Parse(Console.ReadLine());
            var sum = 0;

            for (int i = 0; i < inputNumber; i++)
            {
                var num = int.Parse(Console.ReadLine());
                sum += num;
            }

            Console.WriteLine(sum);
        }
    }
}
