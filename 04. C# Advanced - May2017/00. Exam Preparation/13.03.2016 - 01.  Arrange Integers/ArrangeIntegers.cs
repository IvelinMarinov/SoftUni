using System;
using System.Collections.Generic;
using System.Linq;

namespace _13._03._2016___01.Arrange_Integers
{
    public class ArrangeIntegers
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var numberStrings = new Dictionary<char, string>()
            {
                { '1', "one" },
                { '2', "two"},
                { '3', "three" },
                { '4', "four"},
                { '5', "five"},
                { '6', "six"},
                { '7', "seven"},
                { '8', "eight"},
                { '9', "nine"},
                { '0', "zero"},
            };

            var resultStrings = new List<string>();

            foreach (var number in input)
            {
                var currNumber = new List<string>();

                foreach (var digit in number)
                {
                    if (numberStrings.ContainsKey(digit))
                    {
                        currNumber.Add(numberStrings[digit]);
                    }
                }

                if (currNumber.Count > 0)
                {
                    resultStrings.Add(string.Join("-", currNumber));
                }
            }

            resultStrings = resultStrings.OrderBy(x => x).ToList();

            var temp = string.Join(", ", resultStrings);

            temp = temp.Replace("zero", "0")
               .Replace("one", "1")
               .Replace("two", "2")
               .Replace("three", "3")
               .Replace("four", "4")
               .Replace("five", "5")
               .Replace("six", "6")
               .Replace("seven", "7")
               .Replace("eight", "8")
               .Replace("nine", "9")
               .Replace("-", "");

            Console.WriteLine(temp);
        }
    }
}
