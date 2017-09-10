using System;
using System.Linq;

namespace _06.Find_and_Sum_Integers
{
    public class FindAndSumInts
    {
        public static void Main()
        {
            var sum = Console.ReadLine()
                .Split()
                .Select(w =>
                {
                    long value;
                    bool success = long.TryParse(w, out value);
                    return new {value, success};
                })
                .Where(s => s.success)
                .Select(n => n.value)
                .ToList()
                .Sum();
            
            if (sum != 0)
            {
                Console.WriteLine(sum);
            }
            else
            {
                Console.WriteLine("No match");
            }
        }
    }
}
