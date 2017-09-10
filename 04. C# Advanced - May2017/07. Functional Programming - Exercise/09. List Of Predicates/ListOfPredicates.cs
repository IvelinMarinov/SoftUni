using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.List_Of_Predicates
{
    public class ListOfPredicates
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var dividers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Distinct()
                .OrderByDescending(d => d)
                .ToList();

            var numbers = new List<int>();

            for (int i = 0; i < dividers.Count - 1; i++)
            {
                if (dividers[i] % dividers[i + 1] == 0)
                {
                    dividers.Remove(dividers[i + 1]);
                    i--;
                }
            }

            for (int i = 1; i <= n; i++)
            {
                numbers.Add(i);
            }

            bool isDivisible;
            for (int i = 0; i < numbers.Count; i++)
            {
                for (int j = 0; j < dividers.Count; j++)
                {
                    if (numbers[i] % dividers[j] == 0)
                    {
                        Console.Write($"{numbers[i]} ");
                    }
                }
            }
        }
    }
}
