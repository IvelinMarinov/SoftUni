using System;

namespace _23._10._2016___1.Charity_Marathon
{
    public class CharityMarathon
    {
        public static void Main()
        {
            var marathonLenghtDays = int.Parse(Console.ReadLine());
            var runnersListed = int.Parse(Console.ReadLine());
            var averageLaps = int.Parse(Console.ReadLine());
            var trackLenght = int.Parse(Console.ReadLine())/1000.0;
            var trackCapacity = int.Parse(Console.ReadLine());
            var moneyPerKm = double.Parse(Console.ReadLine());

            var runnersActual = 0;

            if (trackCapacity * marathonLenghtDays < runnersListed)
            {
                runnersActual = trackCapacity * marathonLenghtDays;
            }
            else
            {
                runnersActual = runnersListed;
            }

            var totalDistance = runnersActual * averageLaps * trackLenght;

            var totalMoneyRaised = totalDistance * moneyPerKm;

            Console.WriteLine($"Money raised: {totalMoneyRaised:f2}");
        }
    }
}
