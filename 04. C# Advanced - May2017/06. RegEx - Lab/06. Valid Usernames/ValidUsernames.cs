using System;
using System.Text.RegularExpressions;

namespace _06.Valid_Usernames
{
    public class ValidUsernames
    {
        public static void Main()
        {
            var pattern = "^[\\w-]{3,16}$";
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
