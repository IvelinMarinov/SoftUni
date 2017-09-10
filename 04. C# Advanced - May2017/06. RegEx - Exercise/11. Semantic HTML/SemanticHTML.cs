using System;
using System.Text.RegularExpressions;

namespace _11.Semantic_HTML
{
    public class SemanticHTML
    {
        public static void Main()
        {
            var patternOpeningTag =
                "<div.*((id|class)\\s*=\\s*(\"|\')(main|header|nav|article|section|aside|footer)\\3)";
            var patternClosingTag = "<\\/div>\\s*<!--\\s*(.*)\\s*-->";

            Regex regexOpen = new Regex(patternOpeningTag);
            Regex regexClose = new Regex(patternClosingTag);

            var input = Console.ReadLine();

            while (input != "END")
            {
                if (regexOpen.IsMatch(input))
                {
                    Match match = regexOpen.Match(input);
                    input = input
                        .Replace($" {match.Groups[1].Value}", "")
                        .Replace("div", match.Groups[4].Value);

                    input = Regex.Replace(input, @"\s+", " ");

                    Console.WriteLine(input);
                }

                else if (regexClose.IsMatch(input))
                {
                    Match match = regexClose.Match(input);
                    input = "</" + match.Groups[1].Value.Trim() + ">";
                    Console.WriteLine(input);
                }

                else
                {
                    Console.WriteLine(input);
                }

                input = Console.ReadLine();
            }
        }
    }
}
