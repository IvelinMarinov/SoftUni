using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_15
{
    class Program
    {
        static void Main(string[] args)
        {
            var hours = int.Parse(Console.ReadLine());
            var mins = int.Parse(Console.ReadLine());
            var mins15 = mins + 15;

            if (mins15 >= 59)
            {
                mins15 -= 60;
                hours += 1;
            }
            else
            {
            }

            if (hours == 24)
            {
                hours = 0;
            }
            else
            {
            }

            Console.WriteLine("{0}:{1}", hours.ToString("00"), mins15.ToString("00"));
        }
    }
}
