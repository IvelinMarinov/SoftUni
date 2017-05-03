using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_5.Firm
{
    class Program
    {
        static void Main(string[] args)
        {
            var hoursNeeded = int.Parse(Console.ReadLine());
            var daysAvailable = int.Parse(Console.ReadLine());
            var employees = int.Parse(Console.ReadLine());

            var daysWithoutTraining = daysAvailable * 0.9;
            var regularHours = daysWithoutTraining * 8.0;
            var overtimeHours = employees * 2.0 * daysAvailable;
            var hoursAvailable = Math.Floor(regularHours + overtimeHours);

            var difference = Math.Abs(hoursAvailable - hoursNeeded);

            if (hoursAvailable >= hoursNeeded)
            {
                Console.WriteLine("Yes!{0} hours left.", difference);
            }
            else
            {
                Console.WriteLine("Not enough time!{0} hours needed.", difference);
            }
        }
    }
}
