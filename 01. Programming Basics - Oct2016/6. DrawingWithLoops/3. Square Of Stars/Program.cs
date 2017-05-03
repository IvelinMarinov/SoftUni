using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.SquareOfStars
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            for (int rows = 0; rows < n; rows++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }
        }
    }
}
