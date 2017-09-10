using System;
using System.Text.RegularExpressions;

namespace _01.Students_Results
{
    public class StudentsResults
    {
        public static void Main()
        {
            var pattern = Console.ReadLine();
            var text = Console.ReadLine();

            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(text);

            Console.WriteLine(matches.Count);
        }
    }
}
