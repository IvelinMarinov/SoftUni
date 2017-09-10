using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Special_Words
{
    public class SpecialWords
    {
        public static void Main()
        {
            var separators = new char[] {'(', ')', '[', ']', '<', '>', ',', '-', '!', '?', ' '};

            var specialWords = Console.ReadLine()
                .Split(separators, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var text = Console.ReadLine()
                .Split(separators, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var results = new Dictionary<string,int>();

            for (int i = 0; i < specialWords.Length; i++)
            {
                if (!results.ContainsKey(specialWords[i]))
                {
                    results.Add(specialWords[i], 0);
                }
            }

            for (int i = 0; i < text.Length; i++)
            {
                if (results.ContainsKey(text[i]))
                {
                    results[text[i]]++;
                }
            }

            foreach (var entry in results)
            {
                Console.WriteLine($"{entry.Key} - {entry.Value}");
            }
        }
    }
}
