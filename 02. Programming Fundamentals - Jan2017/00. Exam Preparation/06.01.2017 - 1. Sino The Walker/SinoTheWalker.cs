using System;
using System.Globalization;
using System.Numerics;

namespace _06._01._2017___1.Sino_The_Walker
{
    public class SinoTheWalker
    {
        public static void Main()
        {
            var departureTime = DateTime.ParseExact(Console.ReadLine(), "HH:mm:ss", CultureInfo.InvariantCulture);
            long numOfSteps = long.Parse(Console.ReadLine());
            long secsPerStep = long.Parse(Console.ReadLine());

            BigInteger timeNeededTotal = numOfSteps * secsPerStep;
            var secondsToAdd = timeNeededTotal % (60 * 60 * 24);
            
            var arrivalTime = departureTime.AddSeconds((double)secondsToAdd);

            Console.WriteLine($"Time Arrival: {arrivalTime.TimeOfDay}");
        }
    }
}
