using System;
using System.Collections.Generic;

namespace _06.Strategy_Pattern
{
    public class StartUp
    {
        public static void Main()
        {
            SortedSet<Person> peopleSortedByName = new SortedSet<Person>(new NameComparator());
            SortedSet<Person> peopleSortedByAge = new SortedSet<Person>(new AgeComparator());

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();
                Person person = new Person(input[0], int.Parse(input[1]));
                peopleSortedByName.Add(person);
                peopleSortedByAge.Add(person);
            }

            foreach (var person in peopleSortedByName)
            {
                Console.WriteLine(person);
            }

            foreach (var person in peopleSortedByAge)
            {
                Console.WriteLine(person);
            }
        }
    }
}
