using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Count_Same_Values_In_Array
{
    public class CountSameValuesInArray
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new char[] { ' ', '\t', '\n'}, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            var results = new SortedDictionary<double, int>();

            foreach (var number in numbers)
            {
                if (!results.ContainsKey(number))
                {
                    results.Add(number, 1);
                }
                else
                {
                    results[number]++;
                }
            }

            if (results.Count != 0)
            {
                foreach (var kvp in results)
                {
                    Console.WriteLine($"{kvp.Key} - {kvp.Value} times");
                }
            }            
        }
    }
}
