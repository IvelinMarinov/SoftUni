using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Append_Lists
{
    public class AppendLists
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split('|').ToArray();
            List<string> result = new List<string>();

            Array.Reverse(input);

            foreach (var token in input)
            {
                string[] numbers = token.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var number in numbers)
                {
                    result.Add(number);
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
