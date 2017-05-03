using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Extract_Middle_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            var intArr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var n = intArr.Length;

            if (n == 1)
            {
                Console.WriteLine("{{ {0} }}", intArr[0]);
            }

            else
            {
                if (intArr.Length % 2 == 0)
                {
                    Console.WriteLine("{{ {0}, {1} }}", intArr[n / 2 - 1], intArr[n / 2]);
                }

                else if (intArr.Length % 2 == 1)
                {
                    Console.WriteLine("{{ {0}, {1}, {2} }}", intArr[n / 2 - 1],
                        intArr[n / 2], intArr[n / 2 + 1]);
                }
            }
        }
    }
}
