using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;

namespace _02.Extract_Sentences_By_Keyword
{
    public class ExtractSentencesByKeyword
    {
        public static void Main()
        {
            var keyword = Console.ReadLine();
            var text = Console.ReadLine().Split(new[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

            var pattern = $"\\b{keyword}\\b";
            Regex regex = new Regex(pattern);

            foreach (var sentence in text)
            {
                var isMatch = regex.IsMatch(sentence);

                if (isMatch)
                {
                    Console.WriteLine(sentence.Trim());
                }
            }
        }
    }
}
