using System;
using System.Linq;

namespace _07.Predicate_For_Names
{
    public class PredicateForNames
    {
        public static void Main()
        {
            var length = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split().ToList();

            Predicate<string> lenghtDeterminer = s => { return s.Length <= length; };
            Action<string> printer = n => Console.WriteLine(n);

            foreach (var name in names)
            {
                if (lenghtDeterminer(name))
                {
                    Console.WriteLine(name);
                }
            }
        }
    }
}



