using System;
using System.Collections.Generic;
using System.Linq;

namespace _19._06._2016___04.Cubic_Assault
{
    public class CubicAssault
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var results = new Dictionary<string, Dictionary<string,long>>();

            while (input != "Count em all")
            {
                var tokens = input.Split(new[] {"->"}, StringSplitOptions.RemoveEmptyEntries);
                var regionName = tokens[0].Trim();
                var meteorType = tokens[1].Trim();
                var count = long.Parse(tokens[2]);

                if (!results.ContainsKey(regionName))
                {
                    results[regionName] = new Dictionary<string, long>();
                    results[regionName].Add("Green", 0);
                    results[regionName].Add("Red", 0);
                    results[regionName].Add("Black", 0);
                }

                switch (meteorType)
                {
                    case "Green":
                        results[regionName]["Green"] += count;
                        break;
                    case "Red":
                        results[regionName]["Red"] += count;
                        break;
                    case "Black":
                        results[regionName]["Black"] += count;
                        break;
                    default:
                        break;
                }

                if (results[regionName]["Green"] >= 1000000)
                {
                    results[regionName]["Red"] += results[regionName]["Green"] / 1000000;
                    results[regionName]["Green"] = results[regionName]["Green"] % 1000000;
                }

                if (results[regionName]["Red"] >= 1000000)
                {
                    results[regionName]["Black"] += results[regionName]["Red"] / 1000000;
                    results[regionName]["Red"] = results[regionName]["Red"] % 1000000;
                }

                input = Console.ReadLine();
            }

            foreach (var region in results
                .OrderByDescending(x => x.Value["Black"])
                .ThenBy(x => x.Key.Length)
                .ThenBy(x => x.Key))
            {
                Console.WriteLine(region.Key);

                foreach (var kvp in region.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"-> {kvp.Key} : {kvp.Value}");
                }
            }
        }
    }
}
