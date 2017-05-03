using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.House
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var roofRows = (n + 1) / 2;
            //var roofDashes = "";
            var roofStars = "";
            var roofStarsOdd = "*";
            var baseRows = (n / 2);

            for (int i = 0; i < roofRows; i++)
            {
                if (n % 2 == 0)
                {
                    var roofDashes = new string('-', (n - 2) / 2 - i);
                    roofStars += new string('*', 2);
                    Console.WriteLine("{0}{1}{0}", roofDashes, roofStars);
                               
                }
                else
                {
                    var roofDashes = new string('-', (n - 1) / 2 - i);
                    Console.WriteLine("{0}{1}{0}", roofDashes, roofStarsOdd);
                    roofStarsOdd += new string('*', 2);
                }
            }
            for (int i = 0; i < baseRows; i++)
            {
                Console.WriteLine("{0}{1}{0}", "|", new string('*',n-2));
            }
        }
    }
}
