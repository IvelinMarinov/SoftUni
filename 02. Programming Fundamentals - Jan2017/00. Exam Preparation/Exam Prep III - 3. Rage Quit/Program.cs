using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Exam_Preparation_III___3.Rage_Quit
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var pattern = @"([a-zA-Z_\W]+)(\d+)";

            Regex regex = new Regex(pattern);

            var output = new StringBuilder();
            var statistics = new List<char>();

            var matches = regex.Matches(input);

            foreach (Match match in matches)
            {
                var capitals = new StringBuilder();

                foreach (var symbol in match.Groups[1].ToString())
                {
                    if (symbol >= 97 && symbol <= 122)
                    {
                        capitals.Append((char)(symbol - 32));                        
                    }
                    else
                    {
                        capitals.Append(symbol);
                    }
                }

                var multiplicator = int.Parse(match.Groups[2].ToString());
                var multiplied = new StringBuilder();

                for (int i = 0; i < multiplicator; i++)
                {
                    multiplied.Append(capitals);
                }

                output.Append(multiplied);
            }

            var outputString = output.ToString();

            foreach (var symbol in outputString)
            {
                if (!statistics.Contains(symbol))
                {
                    statistics.Add(symbol);
                }
            }

            Console.WriteLine($"Unique symbols used: {statistics.Count}");
            Console.WriteLine(outputString);
        }
    }
}
