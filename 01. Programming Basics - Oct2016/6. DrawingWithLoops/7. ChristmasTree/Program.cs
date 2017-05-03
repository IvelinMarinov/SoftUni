using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.ChristmasTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var rows = n + 1;

            for (int i = 0; i < rows; i++)
            {
                var row = new string(' ', n - i) + new string('*', i) + " | " + new string('*', i) + new string(' ', n - i);
                Console.WriteLine(row);

            }
        }
    }
}
