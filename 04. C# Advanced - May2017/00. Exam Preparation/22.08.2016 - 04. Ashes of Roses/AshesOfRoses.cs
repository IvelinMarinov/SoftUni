using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _22._08._2016___04.Ashes_of_Roses
{
    public class AshesOfRoses
    {
        public static void Main()
        {
            var pattern = @"Grow\s<([A-Z][a-z]+)>\s<([a-zA-Z0-9]+)>\s([0-9]*)";
            Regex regex = new Regex(pattern);

            var results = new Dictionary<string, Dictionary<string,long>>();

            var input = Console.ReadLine();

            while (input != "Icarus, Ignite!")
            {
                if (regex.IsMatch(input))
                {
                    var match = regex.Match(input);
                    var region = match.Groups[1].Value;
                    var color = match.Groups[2].Value;
                    var count = long.Parse(match.Groups[3].Value);

                    if (!results.ContainsKey(region))
                    {
                        results.Add(region, new Dictionary<string, long>());
                        results[region].Add(color, count);
                    }
                    else if (!results[region].ContainsKey(color))
                    {
                        results[region].Add(color, count);
                    }
                    else
                    {
                        results[region][color] += count;
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var region in results.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(x => x.Key))
            {
                Console.WriteLine(region.Key);
                foreach (var entry in region.Value.OrderBy(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"*--{entry.Key} | {entry.Value}");
                }
            }
        }
    }
}
