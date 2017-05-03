using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03.Word_Count
{
    public class WordCount
    {
        public static void Main()
        {
            var words = File.ReadAllText("words.txt")
                .Split(new char[] { ' ', '\r', '\n' })
                .Select(w => w.ToLower())
                .Distinct()
                .ToArray();

            var textWords = File.ReadAllText("text.txt")
                .Split(new char[] { ' ', '\r', '\n', '.', '?', '!', '-', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(w => w.ToLower())
                .ToArray();

            var result = new Dictionary<string, int>();

            for (int i = 0; i < words.Length; i++)
            {
                var currWord = words[i];
                var currWordCount = 0;

                for (int j = 0; j < textWords.Length; j++)
                {
                    if (currWord == textWords[j])
                    {
                        currWordCount++;
                    }
                }

                result[currWord] = currWordCount;
            }

            var sortedResult = result
                .OrderByDescending(kvp => kvp.Value)
                .Select(kvp => $"{kvp.Key} - {kvp.Value}")
                .ToArray();

            File.WriteAllLines("result.txt", sortedResult);
        }
    }
}
