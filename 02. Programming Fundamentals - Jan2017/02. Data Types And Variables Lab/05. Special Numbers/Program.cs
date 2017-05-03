using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            
            for (int num = 1; num <= n; num++)
            {
                int sumOfDigits = 0;
                int digits = num;
                while (digits > 0)
                {
                    sumOfDigits += digits % 10;
                    digits = digits / 10;
                }
                bool special = (sumOfDigits == 5 || sumOfDigits == 7 || sumOfDigits == 11);
                Console.WriteLine("{0} -> {1}", num, special);
            }
        }
    }
}
