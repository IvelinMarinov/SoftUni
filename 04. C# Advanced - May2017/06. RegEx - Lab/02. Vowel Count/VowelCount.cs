using System;
using System.Text.RegularExpressions;

namespace _02.Vowel_Count
{
    public class VowelCount
    {
        public static void Main()
        {
            var pattern = "[aAeEiIoOuUyY]";
            var text = Console.ReadLine();

            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(text);

            Console.WriteLine($"Vowels: {matches.Count}");
        }
    }
}
