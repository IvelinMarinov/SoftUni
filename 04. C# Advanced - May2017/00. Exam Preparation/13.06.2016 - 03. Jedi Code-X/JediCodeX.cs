using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _13._06._2016___03.Jedi_Code_X
{
    public class JediCodeX
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var sb = new StringBuilder();
            string command;

            for (int i = 0; i < n; i++)
            {
                command = Console.ReadLine();
                sb.Append(command);
                sb.Append(" ");
            }

            var input = sb.ToString();

            var namePattern = Console.ReadLine();
            var messagePattern = Console.ReadLine();

            var nameRegexPattern = $"{namePattern}([a-zA-Z]{{{namePattern.Length}}})";
            var messageRegexPattern = $"{messagePattern}([a-zA-Z0-9]{{{messagePattern.Length}}})";

            Regex nameRegex = new Regex(nameRegexPattern);
            Regex messageRegex = new Regex(messageRegexPattern);

            MatchCollection nameMatches = nameRegex.Matches(input);
            MatchCollection messageMatches = messageRegex.Matches(input);

            var names = new List<string>();
            var messages = new List<string>();
            
            foreach (Match name in nameMatches)
            {
                names.Add(name.Groups[1].Value);
            }
            names = names.Distinct().ToList();

            foreach (Match message in messageMatches)
            {
                messages.Add(message.Groups[1].Value);
            }

            var indexes = Console.ReadLine()
                .Split(new[] {' ', '\t', '\n'}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var results = new Dictionary<string,string>();
            var namesCounter = 0;

            for (int i = 0; i < indexes.Count; i++)
            {
                if (0 < indexes[i] && indexes[i] <= messages.Count)
                {
                    results.Add(names[namesCounter], messages[indexes[i] - 1]);
                    namesCounter++;
                }
                if (namesCounter > names.Count - 1)
                {
                    break;
                }
            }

            foreach (var kvp in results)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value}");
            }
        }
    }
}
