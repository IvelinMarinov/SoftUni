using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_3.Stop_Sign
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var dots = n;
            var underscore = 2 * n - 1;

            //upper part
            Console.WriteLine("{0}{1}{0}", new string('.', n +1), new string('_', 2*n + 1));

            for (int i = 0; i < n; i++)
            {                
                Console.WriteLine("{0}//{1}\\\\{0}", new string('.', dots), new string('_', underscore));
                dots--;
                underscore = underscore + 2;
            }

            //middle part
            Console.WriteLine("//{0}STOP!{0}\\\\", new string('_', 2*n -3));

            //lower part
            underscore = 4 * n - 1;
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("{0}\\\\{1}//{0}", new string('.', dots), new string('_', underscore));
                dots++;
                underscore = underscore - 2;
            }
        }
    }
}
