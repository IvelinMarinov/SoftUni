using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Convert_Speed_Units
{
    class Program
    {
        static void Main(string[] args)
        {
            int distanceMeters = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            int seconds = int.Parse(Console.ReadLine());

            int totalTimeSeconds = seconds + (minutes * 60) + (hours * 3600);

            float speedMetersPerSecond = (float)distanceMeters / totalTimeSeconds;
            Console.WriteLine("{0:}", speedMetersPerSecond);
            float speedKilometersPerHour = (distanceMeters / 1000.0f) / (totalTimeSeconds / 3600.0f);
            Console.WriteLine("{0:}", speedKilometersPerHour);
            float speedMilesPerHour = ((float)distanceMeters / 1609) / ((float)totalTimeSeconds / 3600);
            Console.WriteLine("{0}", speedMilesPerHour);
        }
    }
}
