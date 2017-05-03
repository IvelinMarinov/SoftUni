using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Logs_Aggregator
{
    public class LogsAggregator
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var summary = new SortedDictionary<string, SortedDictionary<string, int>>();

            var user = string.Empty;
            var IP = string.Empty;
            var duration = 0;

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                    .Split()
                    .ToList();

                user = input[1];
                IP = input[0];
                duration = int.Parse(input[2]);

                if (!summary.ContainsKey(user))
                {
                    summary[user] = new SortedDictionary<string, int>();

                    summary[user][IP] = duration;
                }

                else
                {
                    if (!summary[user].ContainsKey(IP))
                    {
                        summary[user][IP] = duration;
                    }
                    else
                    {
                        summary[user][IP] += duration;
                    }
                }
            }

            foreach (KeyValuePair<string, SortedDictionary<string, int>> userLogs in summary)
            {
                Console.Write($"{userLogs.Key}: ");
                var totalDuration = 0;
                var allIPs = new List<string>();

                foreach (KeyValuePair<string, int> sessions in userLogs.Value)
                {
                    totalDuration += sessions.Value;
                    allIPs.Add(sessions.Key);                    
                }

                var uniqueIPs = allIPs
                    .Distinct()
                    .ToList();
                Console.WriteLine($"{totalDuration} [{string.Join(", ", allIPs)}]");
            }

        }
    }
}
