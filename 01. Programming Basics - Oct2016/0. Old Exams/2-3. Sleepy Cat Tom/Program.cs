using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_3.Sleepy_Cat_Tom
{
    class Program
    {
        static void Main(string[] args)
        {
            var holidays = int.Parse(Console.ReadLine());
            var workDays = 365 - holidays;

            var playHolidays = 127;
            var playWorkDays = 63;
            var target = 30000;

            var totalPlay = (holidays * playHolidays) + (workDays * playWorkDays);
            var difference = Math.Abs(target - totalPlay);
            var differenceHours = difference / 60;
            var differenceMins = difference % 60;

            if (totalPlay > target)
            {
                Console.WriteLine("Tom will run away");
                Console.WriteLine("{0} hours and {1} minutes more for play", differenceHours, differenceMins);
            }
            else
            {
                Console.WriteLine("Tom sleeps well");
                Console.WriteLine("{0} hours and {1} minutes less for play", differenceHours, differenceMins);
            }
        }
    }
}
