using System;
using System.Collections.Generic;

namespace _09.Traffic_Lights
{
    public class StartUp
    {
        public static void Main()
        {
            var lightsInput = Console.ReadLine()
                .Split(new[] {' ', '\t'}, StringSplitOptions.RemoveEmptyEntries);

            var trafficLights = new List<TrafficLight>();

            foreach (var lightEntry in lightsInput)
            {
                trafficLights.Add(new TrafficLight(lightEntry));
            }

            var changesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < changesCount; i++)
            {
                trafficLights.ForEach(x => x.ChangeLight());
                trafficLights.ForEach(x => Console.Write(x + " "));
                Console.WriteLine();
            }
        }
    }
}
