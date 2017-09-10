using System;
using System.Text.RegularExpressions;

namespace _03.Non_Digit_Count
{
    public class NonDigitCount
    {
        public static void Main()
        {
            var pattern = "\\D";
            var text = Console.ReadLine();

            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(text);

            Console.WriteLine($"Non-digits: {matches.Count}");
        }
    }
}
