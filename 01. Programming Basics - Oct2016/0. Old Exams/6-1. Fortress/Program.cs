using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_1.Fortress
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var upperDashes = "";

            for (int i = 3; i <= n; i++)
            {
            }
            if (n % 2 == 0)
            {
                Console.WriteLine("/" + new string('^', n / 2) + "\\" + new string('_', n - 4) + "/" +
                    new string('^', n / 2) + "\\");
            }
            else
            {
                Console.WriteLine("/" + new string('^', n / 2) + "\\" + new string('_', n - 3) + "/" +
                    new string('^', n / 2) + "\\");

            }
            for (int i = 3; i < n; i++)
            {
                Console.WriteLine("|" + new string(' ', (2 * n) - 2) + "|");
            }
            //if (n <= 4)
            //{
            //    Console.WriteLine("|" + new string(' ', (2 * n) - 2) + "|");
            //}
            

            if (n % 2 == 0)
            {
                Console.WriteLine("|" + new string(' ', n / 2 + 1) + new string('_', n - 4) + new string(' ', n / 2 + 1) + "|");
            }
            else
            {
                Console.WriteLine("|" + new string(' ', n / 2 + 1) + new string('_', n - 3) + new string(' ', n / 2 + 1) + "|");

            }

            if (n % 2 == 0)
            {
                Console.WriteLine("\\" + new string('_', n / 2) + "/" + new string(' ', n - 4) + "\\" +
                                    new string('_', n / 2) + "/");
            }
            else
            {
                Console.WriteLine("\\" + new string('_', n / 2) + "/" + new string(' ', n - 3) + "\\" +
                                                    new string('_', n / 2) + "/");
            }
        }
    }
}
