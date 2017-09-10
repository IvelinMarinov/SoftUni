using System;
using System.Text.RegularExpressions;

namespace _01.Match_Full_Name
{
    public class MatchFullName
    {
        public static void Main()
        {
            var pattern = "^[A-Z][a-z]+\\s[A-Z][a-z]+$";
            var input = Console.ReadLine();

            Regex regex = new Regex(pattern);

            while (input != "end")
            {
                if (regex.IsMatch(input))
                {
                    Match match = regex.Match(input);
                    Console.WriteLine(match);
                }

                input = Console.ReadLine();
            }
        }
    }
}
