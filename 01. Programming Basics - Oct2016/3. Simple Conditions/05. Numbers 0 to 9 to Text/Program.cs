using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers_0_9_Text
{
    class Program
    {
        static void Main(string[] args)
        {
            var num = int.Parse(Console.ReadLine());

            if (num == 1)
            {
                Console.WriteLine("one");
            }
            if (num == 2)
            {
                Console.WriteLine("two");
            }
            if (num == 3)
            {
                Console.WriteLine("three");
            }
            if (num == 4)
            {
                Console.WriteLine("four");
            }
            if (num == 5)
            {
                Console.WriteLine("five");
            }
            if (num == 6)
            {
                Console.WriteLine("six");
            }
            if (num == 7)
            {
                Console.WriteLine("seven");
            }
            if (num == 8)
            {
                Console.WriteLine("eight");
            }
            if (num == 9)
            {
                Console.WriteLine("nine");
            }
            if (num > 9)
            {
                Console.WriteLine("number too big");
            }
        }
    }
}
