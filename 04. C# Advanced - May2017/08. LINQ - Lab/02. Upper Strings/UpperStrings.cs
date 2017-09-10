using System;
using System.Linq;

namespace _02.Upper_Strings
{
    public class UpperStrings
    {
        public static void Main()
        {
            Console.ReadLine()
                .Split()
                .Select(n => n.ToUpper())
                .ToList()
                .ForEach(n => Console.Write($"{n} "));
        }
    }
}
