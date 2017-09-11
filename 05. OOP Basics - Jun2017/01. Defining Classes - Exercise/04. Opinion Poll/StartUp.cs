using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Opinion_Poll
{
    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();
                var name = input[0];
                var age = int.Parse(input[1]);

                var person = new Person(name, age);
                people.Add(person);
            }

            foreach (var person in people.Where(p => p.age > 30).OrderBy(p => p.name))
            {
                Console.WriteLine($"{person.name} - {person.age}");
            }
        }
    }
}
