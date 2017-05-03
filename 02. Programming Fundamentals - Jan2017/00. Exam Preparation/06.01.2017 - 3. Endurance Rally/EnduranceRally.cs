using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._01._2017___3.Endurance_Rally
{
    public class EnduranceRally
    {
        public static void Main()
        {
            var drivers = Console.ReadLine().Split().ToList();
            var trackLayout = Console.ReadLine().Split().Select(double.Parse).ToList();
            var checkpoints = Console.ReadLine().Split().Select(int.Parse).ToList();
            var track = new List<Section>();

            for (int i = 0; i < trackLayout.Count; i++)
            {
                var currFuel = 0.0;
                var currIsCheckpoint = false;
                var currIndex = i;

                if (checkpoints.Contains(i))
                {
                    currIsCheckpoint = true;
                }

                currFuel += trackLayout[i];

                var currSection = new Section()
                {
                    Index = currIndex,
                    Fuel = currFuel,
                    IsCheckpoint = currIsCheckpoint
                };
                track.Add(currSection);
            }

            foreach (var driver in drivers)
            {
                var outOfFuel = false;

                double fuel = driver[0];

                for (int i = 0; i < track.Count; i++)
                {
                    if (track[i].IsCheckpoint)
                    {
                        fuel += track[i].Fuel;
                    }
                    else
                    {
                        fuel -= track[i].Fuel;
                    }                    

                    if (fuel <= 0)
                    {
                        Console.WriteLine($"{driver} - reached {i}");
                        outOfFuel = true;
                        break;
                    }
                }
                if (outOfFuel)
                {
                    continue;
                }

                Console.WriteLine($"{driver} - fuel left {fuel:f2}");

            }
        }
    }
}
