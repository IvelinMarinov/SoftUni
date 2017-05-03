using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Short_Words_Sorted
{
    class ShortWordsSorted
    {
        static void Main()
        {
            char[] separators = { '.', ',', ':', ';', '(', ')', '[', ']', '"', '\'', '\\', '/', '!', '?', ' ' };

            var text = Console.ReadLine()
                .ToLower()
                .Split(separators, StringSplitOptions.RemoveEmptyEntries)
                .Distinct()
                .ToList();

            var result = text.Where(x => x.Length < 5)
                .OrderBy(x => x);

            Console.WriteLine(string.Join(", ", result));
        }
    }
}
