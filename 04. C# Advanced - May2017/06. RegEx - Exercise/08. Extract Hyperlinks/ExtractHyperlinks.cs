using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _08.Extract_Hyperlinks
{
    public class ExtractHyperlinks
    {
        public static void Main()
        {
            var pattern = "<a(.+?)\\s?href\\s*=\\s*(\"|\')(.+?)\\2";
            var input = Console.ReadLine();

            var sb = new StringBuilder();

            while (input != "END")
            {
                sb.Append(input);
                input = Console.ReadLine();
            }

            var text = sb.ToString();

            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(text);

            foreach (Match match in matches)
            {
                Console.WriteLine(match.Groups[3].Value);
            }
        }
    }
}
