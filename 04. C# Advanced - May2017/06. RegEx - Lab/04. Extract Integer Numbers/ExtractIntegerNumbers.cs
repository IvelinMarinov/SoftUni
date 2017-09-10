using System;
using System.Text.RegularExpressions;

namespace _04.Extract_Integer_Numbers
{
    public class ExtractIntegerNumbers
    {
        public static void Main()
        {
            var pattern = "\\d+";
            var text = Console.ReadLine();

            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(text);

            foreach (var match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }
}
