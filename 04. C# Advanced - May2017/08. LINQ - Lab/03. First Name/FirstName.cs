using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.First_Name
{
    public class FirstName
    {
        public static void Main()
        {
            var names = Console.ReadLine().Split();
            var letters = Console.ReadLine().Split().OrderBy(l => l);
            
            foreach (var letter in letters)
            {
                var result = names
                    .Where(n => n.ToLower()
                    .Substring(0, 1) == letter.ToLower())
                    .FirstOrDefault();

                if (result != null)
                {
                    Console.WriteLine(result);
                    return;
                }
            }

            Console.WriteLine("No match");
        }
    }
}
