using System;
using System.Collections.Generic;

namespace _01.Unique_Usernames
{
    public class UniqueUsernames
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var set = new HashSet<string>();
            string username;

            for (int i = 0; i < n; i++)
            {
                username = Console.ReadLine();
                set.Add(username);
            }

            foreach (var user in set)
            {
                Console.WriteLine(user);
            }
        }
    }
}
