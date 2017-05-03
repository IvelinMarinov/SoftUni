using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_01.Distance_
{
    class Program
    {
        static void Main(string[] args)
        {
            var initialSpeed = int.Parse(Console.ReadLine());
            var firstTimeMins = int.Parse(Console.ReadLine());
            var secondTimeMins = int.Parse(Console.ReadLine());
            var thirdTimeMins = int.Parse(Console.ReadLine());

            var speedIncrease = 1.1;
            var speedReduction = 0.95;

            var firstTimeH = firstTimeMins / 60.00;
            var secondTimeH = secondTimeMins / 60.00;
            var thirdTimeH = thirdTimeMins / 60.00;

            var distanceFirst = initialSpeed * firstTimeH;
            var secondSpeed = initialSpeed * speedIncrease;
            var distanceSecond = secondSpeed * secondTimeH;
            var thirdSpeed = secondSpeed * speedReduction;
            var distanceThird = thirdSpeed * thirdTimeH;

            var totalDistance = distanceFirst + distanceSecond + distanceThird;

            Console.WriteLine("{0:f2}", totalDistance);

        }
    }
}
