using System;
using System.Text.RegularExpressions;

namespace _06.Sentence_Extractor
{
    public class SentenceExtractor
    {
        public static void Main()
        {
            var keyword = Console.ReadLine();
            var text = Console.ReadLine();

            var pattern = $@"[^.?!]*(?<=[.?\s!]){keyword}(?=[\s.?!])[^.?!]*[.?!]";

            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(text);

            foreach (var match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }
}
