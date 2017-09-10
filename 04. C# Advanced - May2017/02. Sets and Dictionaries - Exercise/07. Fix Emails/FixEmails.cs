using System;
using System.Collections.Generic;

namespace _07.Fix_Emails
{
    public class FixEmails
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var book = new Dictionary<string, string>();

            while (input != "stop")
            {
                var name = input;
                var email = Console.ReadLine();

                if (!book.ContainsKey(name))
                {
                    book.Add(name, email);
                }
                else
                {
                    book[name] += email;
                }

                input = Console.ReadLine();
            }
            
            foreach (var kvp in book)
            {
                if (!kvp.Value.ToLower().EndsWith("uk") && !kvp.Value.ToLower().EndsWith("us"))
                {
                    Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
                }
            }
        }
    }
}
