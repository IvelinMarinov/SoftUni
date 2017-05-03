using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Refactor_Volume_of_Pyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sumDigits = 0; int num = 0; bool special = false;
            for (int num = 1; num <= n; num++)
            {
                while (num > 0)
                {
                    sumDigits += num % 10;
                    num = num / 10;
                }
                special = (sumDigits == 5) || (sumDigits == 7) || (sumDigits == 11);
                Console.WriteLine($"{takova} -> {special}");
                sumDigits = 0; num = takova;
            }

        }
    }
}
