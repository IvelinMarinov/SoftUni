using System;

namespace _01.Hornet_Flaps
{
    public class HornetFlaps
    {
        public static void Main()
        {
            var wingFlaps = int.Parse(Console.ReadLine());
            var distancePer1000Flaps = decimal.Parse(Console.ReadLine());
            var endurance = int.Parse(Console.ReadLine());

            var restDuration = 5;
            var flapsPerSec = 100;

            var speedPerSec = distancePer1000Flaps / 10;
            var totalTimeFlying = wingFlaps / flapsPerSec;

            var totalDistance = speedPerSec * totalTimeFlying;

            var restsCount = wingFlaps / endurance;

            var totalTimeResting = restsCount * restDuration;

            var totalTime = totalTimeFlying + totalTimeResting;

            Console.WriteLine($"{totalDistance:f2} m.");

            Console.WriteLine($"{totalTime} s.");
        }
    }
}
