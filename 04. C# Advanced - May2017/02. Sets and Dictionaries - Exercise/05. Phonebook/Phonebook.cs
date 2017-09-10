using System;
using System.Collections.Generic;

namespace _05.Phonebook
{
    public class Phonebook
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var phonebook = new Dictionary<string, string>();

            while (input != "search")
            {
                var inputArgs = input.Split('-');
                var name = inputArgs[0];
                var number = inputArgs[1];

                if (!phonebook.ContainsKey(name))
                {
                    phonebook.Add(name, number);
                }
                else
                {
                    phonebook[name] = number;
                }

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "stop")
            {
                if (phonebook.ContainsKey(input))
                {
                    Console.WriteLine($"{input} -> {phonebook[input]}");
                }
                else
                {
                    Console.WriteLine($"Contact {input} does not exist.");
                }
                
                input = Console.ReadLine();
            }
        }
    }
}
