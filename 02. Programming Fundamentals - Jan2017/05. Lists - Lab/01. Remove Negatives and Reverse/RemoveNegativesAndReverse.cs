using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Remove_Negatives_and_Reverse
{
    public class RemoveNegativesAndReverse
    {
        public static void Main()
        {
            List<string> input = Console.ReadLine().Split('|').ToList();
            List<string> result = new List<string>();

            foreach (var item in input)
            {
                result.Add(item);
            }

            result.Reverse();

            if (result.Count != 0)
            {
                var finalResult = string.Join(" ", result).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                Console.WriteLine(string.Join(" ", finalResult));
            }
            else
            {
                Console.WriteLine("empty");
            }
        }
    }
}
