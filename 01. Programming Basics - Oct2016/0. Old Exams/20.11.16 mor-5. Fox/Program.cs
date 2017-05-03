using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20._11._16_mor_5.Fox
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var width = 2 * n + 3;
            var height = (2 * n) + (n / 3);
            var eyes = n / 3;
            var upperDashes = (2 *n) - 1;
            var midOuterStars= (n - 1) / 2;
            var midMidStars = n;
            var midIncrements = n / 3;
            var lowerStars = (2 * n) - 1;

            //ears
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("{0}\\{1}/{0}", new string('*', i), new string('-', upperDashes));
                upperDashes -= 2;
            }
            //eyes
            for (int i = 0; i < midIncrements; i++)
            {
                Console.WriteLine("|{0}\\{1}/{0}|", new string('*', midOuterStars), new string('*', midMidStars));
                midOuterStars++;
                midMidStars -= 2;
            }
            //mouth
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("{0}\\{1}/{0}", new string('-', i), new string('*', lowerStars));
                lowerStars -= 2;
            }
        }
    }
}
