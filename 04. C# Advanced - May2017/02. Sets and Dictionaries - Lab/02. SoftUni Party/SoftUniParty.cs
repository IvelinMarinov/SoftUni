using System;
using System.Collections.Generic;

namespace _02.SoftUni_Party
{
    public class SoftUniParty
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var set = new SortedSet<string>();

            while (input != "PARTY")
            {
                set.Add(input);

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "END")
            {
                if (set.Contains(input))
                {
                    set.Remove(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(set.Count);

            if (set.Count != 0)
            {
                foreach (var guest in set)
                {
                    Console.WriteLine(guest);
                }
            }
        }
    }
}
