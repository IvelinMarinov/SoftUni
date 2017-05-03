using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volleyball
{
    class Program
    {
        static void Main(string[] args)
        {
            var year = Console.ReadLine();
            var holidays = int.Parse(Console.ReadLine());
            var tripsHome = int.Parse(Console.ReadLine());
            var games = ((48 - tripsHome) * 3.0 / 4) + tripsHome + (2.0 / 3 * holidays);

            if (year == "normal")
            {
                Console.WriteLine(Math.Truncate(games));
            }
            else if (year == "leap")
            {
                Console.WriteLine(Math.Truncate(games * 1.15));
            }           
        }
    }
}
