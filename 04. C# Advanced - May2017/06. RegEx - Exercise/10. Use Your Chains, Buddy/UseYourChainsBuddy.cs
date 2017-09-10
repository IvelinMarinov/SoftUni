using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace _10.Use_Your_Chains__Buddy
{
    public class UseYourChainsBuddy
    {
        public static void Main(string[] args)
        {
            Console.SetIn(new StreamReader(Console.OpenStandardInput(8192)));

            var text = Console.ReadLine();

            var pattern = @"<p>(.*?)<\/p>";

            Regex regex = new Regex(pattern);

            var matches = regex.Matches(text);

            var sb = new StringBuilder();

            foreach (Match match in matches)
            {
                sb.Append($"{match.Groups[1]}");
            }

            var matchesString = sb.ToString();

            var decodedSB = new StringBuilder();

            foreach (var character in matchesString)
            {
                if ((int)character >= 48 && (int)character <= 57)
                {
                    decodedSB.Append(character);
                }
                else if ((int)character >= 97 && (int)character < 110)
                {
                    decodedSB.Append((char)((int)character + 13));
                }
                else if ((int)character >= 110 && (int)character <= 122)
                {
                    decodedSB.Append((char)((int)character - 13));
                }
                else
                {
                    decodedSB.Append(' ');
                }
            }
            var decodedText = decodedSB.ToString();

            var replacementPattern = @"[ ]{2,}";
            Regex replaceMultipleSpaces = new Regex(replacementPattern);

            decodedText = replaceMultipleSpaces.Replace(decodedText, " ");

            Console.WriteLine(decodedText);
        }
    }
}