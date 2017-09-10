using System;
using System.Linq;

namespace _03.Count_Uppercase_Words
{
    public class CountUppercaseWords
    {
        public static void Main()
        {
            Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Where(n => n == n.Substring(0,1).ToUpper() + n.Substring(1))
                .ToList()
                .ForEach(n => Console.WriteLine(n));
        }
    }
}
