using System;
using System.Linq;

namespace _03.Hornet_Assault
{
    public class HornetAssault
    {
       public static void Main()
        {
            var separators = new char[] { ' ', '\t', '\n' };

            var beeHives = Console.ReadLine()
                .Split(separators, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToList();

            var hornets = Console.ReadLine()
                .Split(separators, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToList();

            for (int i = 0; i < beeHives.Count; i++)
            {
                var combinedDamage = 0l;

                if (hornets.Count != 0)
                {
                    combinedDamage = hornets.Sum();
                }

                var currentBeehive = beeHives[i];

                if (combinedDamage > currentBeehive)
                {
                    beeHives[i] = 0;
                }
                else
                {
                    beeHives[i] -= combinedDamage;
                    hornets.RemoveAt(0);
                }

                if (hornets.Count == 0)
                {
                    break;
                }
            }

            var aliveBees = beeHives.Where(x => x != 0).ToList();

            if (aliveBees.Count == 0)
            {
                Console.WriteLine(string.Join(" ", hornets));
            }

            else
            {
                Console.WriteLine(string.Join(" ", aliveBees));
            }
        }
    }
}
