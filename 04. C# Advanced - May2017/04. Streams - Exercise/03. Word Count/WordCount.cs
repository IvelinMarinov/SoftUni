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
            using (StreamReader readerText = new StreamReader("../../text.txt"))
            using (StreamReader readerWords = new StreamReader("../../words.txt"))
            {
                using (StreamWriter writer = new StreamWriter("../../results.txt"))
                {
                    var separators = new char[] {' ', '\n', '\t', '\r', '.', ',', '!', '?'};
                    var text = readerText.ReadToEnd().ToLower()
                        .ToLower()
                        .Split(separators, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    var words = readerWords.ReadToEnd()
                        .ToLower()
                        .Split(separators, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    var results = new Dictionary<string, int>();

                    for (int i = 0; i < text.Length; i++)
                    {
                        for (int j = 0; j < words.Length; j++)
                        {
                            if (text[i] == words[j])
                            {
                                if (!results.ContainsKey(text[i]))
                                {
                                    results.Add(text[i], 1);
                                }
                                else
                                {
                                    results[text[i]]++;
                                }
                            }
                        }
                    }

                    foreach (var kvp in results)
                    {
                        writer.WriteLine($"{kvp.Key} - {kvp.Value}");
                    }
                }
            }
        }
    }
}
