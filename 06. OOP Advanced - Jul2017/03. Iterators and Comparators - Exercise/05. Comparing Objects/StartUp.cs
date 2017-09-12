using System;
using System.Collections.Generic;

namespace _05.Comparing_Objects
{
    public class StartUp
    {
        public static void Main()
        {
            List<Person> people = new List<Person>();

            string[] input = Console.ReadLine().Split();

            while (input[0] != "END")
            {
                people.Add(new Person(input[0], int.Parse(input[1]), input[2]));

                input = Console.ReadLine().Split();
            }

            int n = int.Parse(Console.ReadLine());
            n--;
            int equalsCount = 0;
            int differentCount = 0;

            foreach (var person in people)
            {
                var comparison = person.CompareTo(people[n]) == 0 ? equalsCount++ : differentCount++;
            }

            if (equalsCount == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{equalsCount} {differentCount} {people.Count}");
            }
        }
    }
}
