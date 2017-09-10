using System;
using System.Text.RegularExpressions;

namespace _02.Match_Phone_Number
{
    public class MatchPhoneNumber
    {
        public static void Main()
        {
            var pattern = "^\\+359(-|\\s)2\\1[0-9]{3}\\1[0-9]{4}$";
            var input = Console.ReadLine();

            Regex regex = new Regex(pattern);

            while (input != "end")
            {
                if (regex.IsMatch(input))
                {
                    var match = regex.Match(input);
                    Console.WriteLine(match);
                }

                input = Console.ReadLine();
            }
        }
    }
}
