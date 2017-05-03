using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.Legendary_Farming
{
    public class LegendaryFarming
    {
        public static void Main()
        {
            var input = Console.ReadLine().ToLower().Split().ToList();

            var resources = new Dictionary<string, int>();
            resources["shards"] = 0;
            resources["fragments"] = 0;
            resources["motes"] = 0;

            bool legendaryObtained = false;
            bool flag = false;

            while (!legendaryObtained)
            {
                for (int i = 0; i < input.Count - 1; i = i + 2)
                {
                    if (!resources.ContainsKey(input[i + 1]))
                    {
                        resources[input[i + 1]] = int.Parse(input[i]);
                    }
                    else
                    {
                        resources[input[i + 1]] += int.Parse(input[i]);
                    }

                    if (resources["shards"] >= 250)
                    {
                        legendaryObtained = true;
                        Console.WriteLine("Shadowmourne obtained!");
                        resources["shards"] -= 250;
                        SplitKeyElementsFromJunk(resources);
                        flag = true;
                        break;
                    }
                    else if (resources["fragments"] >= 250)
                    {
                        legendaryObtained = true;
                        Console.WriteLine("Valanyr obtained!");
                        resources["fragments"] -= 250;
                        SplitKeyElementsFromJunk(resources);
                        flag = true;
                        break;
                    }
                    else if (resources["motes"] >= 250)
                    {
                        legendaryObtained = true;
                        Console.WriteLine("Dragonwrath obtained!");
                        resources["motes"] -= 250;
                        SplitKeyElementsFromJunk(resources);
                        flag = true;
                        break;
                    }
                }
                if (flag)
                {
                    break;
                }

                input = Console.ReadLine().ToLower().Split().ToList();
            }
        }

        public static void SplitKeyElementsFromJunk(Dictionary<string, int> resources)
        {
            var remainingKeyElements = new Dictionary<string, int>();

            remainingKeyElements.Add("shards", resources["shards"]);
            remainingKeyElements.Add("fragments", resources["fragments"]);
            remainingKeyElements.Add("motes", resources["motes"]);
            resources.Remove("shards");
            resources.Remove("motes");
            resources.Remove("fragments");

            foreach (var keyElement in remainingKeyElements.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{keyElement.Key}: {keyElement.Value}");
            }

            foreach (var resource in resources.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{resource.Key}: {resource.Value}");
            }
        }
    }
}
