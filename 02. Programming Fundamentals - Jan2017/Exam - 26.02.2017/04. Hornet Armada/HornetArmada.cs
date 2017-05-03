using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Hornet_Armada
{
    public class HornetArmada
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var separators = new char[] { '=', '-', '>', ':', ' ', '\t', '\n' };

            var legionsSummary = new Dictionary<string, Legion>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                    .Split(separators, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                var currLastActivity = int.Parse(input[0]);
                var currLegionName = input[1];
                var currSoldierType = input[2];
                var currSoldierCount = long.Parse(input[3]);

                if (!legionsSummary.ContainsKey(currLegionName))
                {
                    var currentLegion = new Legion()
                    {
                        LastActivity = currLastActivity,
                        Name = currLegionName,
                        Soldiers = new Dictionary<string, long>()
                    };

                    currentLegion.Soldiers.Add(currSoldierType, currSoldierCount);

                    legionsSummary.Add(currLegionName, currentLegion);
                }

                else
                {
                    if (currLastActivity > legionsSummary[currLegionName].LastActivity)
                    {
                        legionsSummary[currLegionName].LastActivity = currLastActivity;
                    }

                    if (legionsSummary[currLegionName].Soldiers.ContainsKey(currSoldierType))
                    {
                        legionsSummary[currLegionName].Soldiers[currSoldierType] += currSoldierCount;

                    }
                    else
                    {
                        legionsSummary[currLegionName].Soldiers.Add(currSoldierType, currSoldierCount);

                    }
                }
            }

            var printCommand = Console.ReadLine().Split('\\').ToList();

            if (printCommand.Count == 2)
            {
                var lastActivity = int.Parse(printCommand[0]);
                var soldierType = printCommand[1];

                var legionsToPrint = new Dictionary<string, long>();

                foreach (var legion in legionsSummary.Values)
                {
                    if (legion.LastActivity < lastActivity && legion.Soldiers.ContainsKey(soldierType))
                    {
                        legionsToPrint.Add(legion.Name, legion.Soldiers[soldierType]);
                    }
                }

                foreach (var kvp in legionsToPrint.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
                }
            }

            else if (printCommand.Count == 1)
            {
                var soldierType = printCommand[0];

                foreach (var legion in legionsSummary.Values.OrderByDescending(x => x.LastActivity))
                {
                    if (legion.Soldiers.ContainsKey(soldierType))
                    {
                        Console.WriteLine($"{legion.LastActivity} : {legion.Name}");
                    }
                }
            }
        }
    }
}
