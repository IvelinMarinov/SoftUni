using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumsTo100
{
    class Program
    {
        static void Main(string[] args)
        {
            var num = int.Parse(Console.ReadLine());
            string[] tillNineteen = {"zero", "one", "two", "three", "four",
            "five", "six", "seven", "eight", "nine", "ten", "eleven",
            "twelve", "thirteen", "fourteen", "fifteen", "sixteen",
            "seventeen", "eighteen", "nineteen"};
            string[] tillNinety = {"twenty", "thirty", "fourty", "fifty", "sixty",
            "seventy", "eighty", "ninety"};
            if (num < 0 || num > 100)
            {
                Console.WriteLine("Invalid number");
            }
            else if (num >= 0 && num <= 19)
            {
                Console.WriteLine(tillNineteen[num]);
            }
            else if (num >= 20 && num < 100)
            {
                if (num % 10 == 0)
                {
                    Console.WriteLine(tillNinety[(num / 10) - 2]);
                }
                else
                {
                    Console.WriteLine(tillNinety[(num / 10) - 2] + " " + tillNineteen[(num % 10)]);
                }
            }
            else if (num == 100)
            {
                Console.WriteLine("one hundred");
            }
        }
    }
}