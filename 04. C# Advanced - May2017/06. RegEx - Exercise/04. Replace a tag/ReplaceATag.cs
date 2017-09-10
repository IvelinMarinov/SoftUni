using System;
using System.Text.RegularExpressions;

namespace _04.Replace_a_tag
{
    public class ReplaceATag
    {
        public static void Main()
        {
            var pattern = "<a(.*)>(.*)<\\/a>";
            var input = Console.ReadLine();

            Regex regex = new Regex(pattern);

            while (input != "end")
            {
                if (regex.IsMatch(input))
                {
                    var match = regex.Match(input);
                    var matchHyperlink = match.Groups[1].Value;
                    var matchText = match.Groups[2].Value;

                    var matchAsString = match.ToString();
                    var replacementString = $"[URL{matchHyperlink}]{matchText}[/URL]";

                    input = input.Replace(matchAsString, replacementString);

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
