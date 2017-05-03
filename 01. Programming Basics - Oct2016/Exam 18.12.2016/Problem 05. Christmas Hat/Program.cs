using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_05.Christmas_Hat
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var dots = (2 * n) - 1;

            //upper part
            Console.WriteLine("{0}/|\\{0}", new string('.', dots));
            Console.WriteLine("{0}\\|/{0}", new string('.', dots));

            //middle part
            for (int i = 0; i < 2*n; i++)
            {
                Console.WriteLine("{0}*{1}*{1}*{0}", new string('.', dots), new string('-', i) );
                dots--;
            }

            //lower part
            Console.WriteLine("{0}", new string('*', 4 * n + 1));

            for (int i = 0; i < 2*n; i++)
            {
                Console.Write('*');
                Console.Write('.');
            }
            Console.Write('*');
            Console.WriteLine();        

            Console.WriteLine("{0}", new string('*', 4 * n + 1));


        }
    }
}
