using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.A_Miner_s_Task
{
    public class AMinersTask
    {
        public static void Main()
        {
            var input = Console.ReadLine(); 
            var summary = new Dictionary<string, long>();

            while (input != "stop")
            {
                var resource = input;
                var quantity = long.Parse(Console.ReadLine());

                if (!summary.ContainsKey(resource))
                {
                    summary.Add(resource, quantity);
                }
                else
                {
                    summary[resource] += quantity;
                }

                input = Console.ReadLine();
            }

            foreach (var kvp in summary.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
