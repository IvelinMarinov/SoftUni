using System;
using System.Text.RegularExpressions;

namespace _07.Replace_A_tag
{
    public class Program
    {
        public static void Main()
        {
            var text = Console.ReadLine();

            while (text != "end")
            {
                var pattern = @"<a.*?href.*?=(.*)>(.*?)<\/a>";
                Regex regex = new Regex(pattern);

                var matches = regex.Matches(text);

                var replacement = @"[URL href=$1]$2[/URL]";
                var result = regex.Replace(text, replacement);

                Console.WriteLine(result);

                text = Console.ReadLine();
            }
        }
    }
}
