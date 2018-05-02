using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.User_Logs
{
    public class UserLogs
    {
        public static void Main()
        {
            var separators = new char[] { '=', ' ' };
            var log = Console.ReadLine()
                .Split(separators)
                .ToArray();

            var summary = new SortedDictionary<string, Dictionary<string, int>>();

            while (log[0] != "end")
            {
                var user = log[log.Length - 1];
                var IP = log[1];

                if (!summary.ContainsKey(user))
                {
                    summary[user] = new Dictionary<string, int>();

                    if (!summary[user].ContainsKey(IP))
                    {
                        summary[user][IP] = 0;
                    }
                    else
                    {
                        summary[user][IP]++;
                    }
                }

                if (!summary[user].ContainsKey(IP))
                {
                    summary[user][IP] = 1;
                }
                else
                {
                    summary[user][IP]++;
                }

                log = Console.ReadLine().Split(separators).ToArray();
            }

            foreach (var items in summary)
            {
                Console.WriteLine($"{items.Key}: ");
                var result = new List<string>();

                foreach (var item in items.Value)
                {
                    result.Add(item.Key + " => " + item.Value);                    
                }
                Console.WriteLine(string.Join(", ", result) + ".");
            }
        }
    }
}
