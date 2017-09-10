using System;
using System.Text.RegularExpressions;

namespace _07.Valid_Time
{
    public class ValidTime
    {
        public static void Main()
        {
            var pattern = @"^([0][0-9]|[1][0:1]):[0-5][0-9]:[0-5][0-9]\s[AP]M$";
            var input = Console.ReadLine();

            Regex regex = new Regex(pattern);

            while (input != "END")
            {
                if (regex.IsMatch(input))
                {
                    Console.WriteLine("valid");
                }
                else
                {
                    Console.WriteLine("invalid");
                }

                input = Console.ReadLine();
            }
        }
    }
}
