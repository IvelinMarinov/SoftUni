using System;
using System.Text.RegularExpressions;

namespace _03.Series_Of_Letters
{
    public class SeriesOfLetters
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var pattern = "([a-zA-Z])\\1+";

            Console.WriteLine(Regex.Replace(input, pattern, "$1"));
        }
    }
}
