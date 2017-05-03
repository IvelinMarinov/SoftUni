using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _03.Valid_Usernames
{
    public class ValidUsernames
    {
        public static void Main()
        {
            var usernames = Console.ReadLine()
                .Split(new[] { ' ', '/', '\\', '(', ')'}, StringSplitOptions.RemoveEmptyEntries);

            var pattern = @"\b[A-Za-z][A-Za-z0-9_]{2,24}\b";

            Regex regex = new Regex(pattern);

            var validUsernames = new List<string>();

            foreach (var username in usernames)
            {
                var isMatch = regex.IsMatch(username);
                if (isMatch)
                {
                    validUsernames.Add(username);
                }
            }

            var firstUsername = string.Empty;
            var secondUsername = string.Empty;
            var currSum = 0;
            var maxSum = 0;
            
            for (int i = 0; i < validUsernames.Count - 1; i++)
            {
                                currSum = validUsernames[i].Length + validUsernames[i + 1].Length;

                if (currSum > maxSum)
                {
                    maxSum = currSum;
                    firstUsername = validUsernames[i];
                    secondUsername = validUsernames[i + 1];
                }
            }

            Console.WriteLine(firstUsername);
            Console.WriteLine(secondUsername);
        }
    }
}
