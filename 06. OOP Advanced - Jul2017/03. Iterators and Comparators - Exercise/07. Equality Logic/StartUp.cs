using System;
using System.Collections.Generic;

namespace _07.Equality_Logic
{
    public class StartUp
    {
        public static void Main()
        {
            var personsHashSet = new HashSet<Person>();
            var personsSortedSet = new SortedSet<Person>();

            var personsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < personsCount; i++)
            {
                var input = Console.ReadLine().Split();
                var person = new Person(input[0], int.Parse(input[1]));

                personsHashSet.Add(person);
                personsSortedSet.Add(person);
            }

            Console.WriteLine(personsHashSet.Count);
            Console.WriteLine(personsSortedSet.Count);
        }
    }
}
