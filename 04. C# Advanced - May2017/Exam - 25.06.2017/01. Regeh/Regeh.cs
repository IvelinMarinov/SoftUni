using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _01.Regeh
{
    public class Regeh
    {
        public static void Main()
        {
            var pattern = @"\[\S.*?<([0-9].*?)REGEH([0-9].*?)>\S.*?]";

            var regex = new Regex(pattern);

            var input = Console.ReadLine();
            var sb = new StringBuilder();
            var stringIndex = 0;
            
            MatchCollection matches = regex.Matches(input);

            foreach (Match match in matches)
            {
                var leftNum = int.Parse(match.Groups[1].Value);
                var rightNum = int.Parse(match.Groups[2].Value);

                stringIndex += leftNum;

                if (stringIndex >= input.Length)
                {
                    stringIndex = (stringIndex % input.Length - 1);
                }

                sb.Append(input[stringIndex]);

                stringIndex += rightNum;

                if (stringIndex >= input.Length)
                {
                    stringIndex = (stringIndex % input.Length - 1);
                }

                sb.Append(input[stringIndex]);
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
