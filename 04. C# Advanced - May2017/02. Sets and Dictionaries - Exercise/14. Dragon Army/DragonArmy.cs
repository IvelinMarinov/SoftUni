using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.Dragon_Army
{
    public class DragonArmy
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var summary = new Dictionary<string, SortedDictionary<string, int[]>>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                    .Split()
                    .ToArray();

                var type = input[0];
                var name = input[1];
                var damage = 0;

                if (input[2] != "null")
                {
                    damage = int.Parse(input[2]);
                }
                else
                {
                    damage = 45;
                }

                var health = 0;

                if (input[3] != "null")
                {
                    health = int.Parse(input[3]);
                }
                else
                {
                    health = 250;
                }

                var armor = 0;

                if (input[4] != "null")
                {
                    armor = int.Parse(input[4]);
                }
                else
                {
                    armor = 10;
                }

                if (!summary.ContainsKey(type))
                {
                    summary[type] = new SortedDictionary<string, int[]>();
                }

                summary[type][name] = new int[] { damage, health, armor };
            }
            foreach (KeyValuePair<string, SortedDictionary<string, int[]>> type in summary)
            {
                var typeName = type.Key;
                var dragonsByType = type.Value;

                var averageDamage = dragonsByType.Values.Average(a => a[0]);
                var averageHealth = dragonsByType.Values.Average(a => a[1]);
                var averageArmor = dragonsByType.Values.Average(a => a[2]);

                Console.WriteLine($"{typeName}::({averageDamage:f2}/{averageHealth:f2}/{averageArmor:f2})");

                foreach (var dragon in dragonsByType)
                {
                    Console.WriteLine($"-{dragon.Key} -> damage: {dragon.Value[0]}, health: {dragon.Value[1]}, armor: {dragon.Value[2]}");
                }
            }
        }
    }
}
