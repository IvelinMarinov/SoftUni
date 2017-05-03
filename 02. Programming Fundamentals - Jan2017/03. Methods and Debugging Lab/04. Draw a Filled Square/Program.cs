using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Draw_a_Filled_Square
{
    class Program
    {
        static void PrintUpper(int n)
        {
            Console.WriteLine(new string('-', 2 * n));
        }

        static void PrintMiddle(int n)
        {
            Console.Write('-');

            for (int i = 0; i < n-1; i++)
            {
                Console.Write("\\/");
            }

            Console.WriteLine('-');
        }

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            PrintUpper(n);

            for (int i = 0; i < n -2; i++)
            {
                PrintMiddle(n);
            }

            PrintUpper(n);
        }
    }
}
