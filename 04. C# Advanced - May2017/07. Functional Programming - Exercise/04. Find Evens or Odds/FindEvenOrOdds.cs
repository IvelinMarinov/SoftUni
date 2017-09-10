using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Find_Evens_or_Odds
{
    public class FindEvenOrOdds
    {
        public static void Main()
        {
            var range = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var min = range[0];
            var max = range[1];

            var command = Console.ReadLine();

            var numbers = new List<int>();

            for (int i = min; i <= max; i++)
            {
                numbers.Add(i);
            }

            Predicate<int> oddsFinder = (int n) => { return Math.Abs(n) % 2 == 1; };
            Predicate<int> evensFinder = (int n) => { return Math.Abs(n) % 2 == 0; };

            switch (command)
            {
                case "odd":
                    foreach (var number in numbers)
                    {
                        if (oddsFinder(number))
                        {
                            Console.Write($"{number} ");
                        }
                    }
                    break;

                case "even":
                    foreach (var number in numbers)
                    {
                        if (evensFinder(number))
                        {
                            Console.Write($"{number} ");
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
