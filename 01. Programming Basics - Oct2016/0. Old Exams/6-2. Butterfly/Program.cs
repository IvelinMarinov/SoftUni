using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_2.Butterfly
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            //upper part
            for (int i = 0; i <= (n - 2)/2 - 1; i++)
            {
                Console.WriteLine("{0}\\ /{0}", new string('*', n - 2));
                Console.WriteLine("{0}\\ /{0}", new string('-', n - 2));
            }
            if (n % 2 == 1)
            {
                Console.WriteLine("{0}\\ /{0}", new string('*', n - 2));
            }
            //middle part
            Console.WriteLine("{0}@", new string(' ', n-1));

            //lower part
            if (n % 2 == 1)
            {
                Console.WriteLine("{0}/ \\{0}", new string('*', n - 2));
            }
            for (int i = 0; i <= (n - 2) / 2 - 1; i++)
            {
                Console.WriteLine("{0}/ \\{0}", new string('-', n - 2));
                Console.WriteLine("{0}/ \\{0}", new string('*', n - 2));                
            }
        }
    }
}
