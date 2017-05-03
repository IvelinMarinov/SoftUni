using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Phonebook_Upgrade
{
    public class PhonebookUpgrade
    {
        public static void Main()
        {
            var command = Console.ReadLine()
                .Split()
                .ToList();

            var phonebook = new SortedDictionary<string, string>();

            while (command[0] != "END")
            {
                switch (command[0])
                {
                    case "A":
                        phonebook[command[1]] = command[2];
                        break;

                    case "S":
                        var entryValue = string.Empty;
                        phonebook.TryGetValue(command[1], out entryValue);

                        if (entryValue != null)
                        {
                            Console.WriteLine($"{command[1]} -> {entryValue}");
                        }
                        else
                        {
                            Console.WriteLine($"Contact {command[1]} does not exist.");
                        }
                        break;

                    case "ListAll":
                        foreach (var item in phonebook)
                        {
                            Console.WriteLine($"{item.Key} -> {item.Value}");
                        }
                        break;

                    default:
                        break;
                }

                command = Console.ReadLine()
                .Split()
                .ToList();
            }
        }
    }
}
