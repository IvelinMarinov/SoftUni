using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.A_Miner_Task
{
    public class AMinerTask
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var resources = new List<string>();

            while (input != "stop")
            {
                resources.Add(input);
                input = Console.ReadLine();
            }

            var result = new Dictionary<string, int>();

            for (int i = 0; i < resources.Count - 1; i = i + 2)
            {
                if (!result.ContainsKey(resources[i]))
                {
                    result[resources[i]] = int.Parse(resources[i + 1]);
                }
                else
                {
                    result[resources[i]] += int.Parse(resources[i + 1]);
                }
            }

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}