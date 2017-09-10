using System;
using System.Linq;

namespace _10.Predicate_Party_
{
    public class PredicateParty
    {
        public static void Main()
        {
            var names = Console.ReadLine()
                .Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var command = Console.ReadLine()
                .Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Predicate<string> startsWith = s => { return s.StartsWith(command[2]); };
            Predicate<string> endsWith = s => { return s.EndsWith(command[2]); };
            Predicate<string> length = s => { return s.Length == (int.Parse(command[2])); };

            while (command[0] != "Party!")
            {
                var action = command[0];
                var condition = command[1];
                var substring = command[2];

                for (var i = 0; i < names.Count; i++)
                {
                    switch (action)
                    {
                        case "Remove":
                            if (condition == "StartsWith" && startsWith(names[i]))
                            {
                                names.Remove(names[i]);
                                i--;
                            }
                            else if (condition == "EndsWith" && endsWith(names[i]))
                            {
                                names.Remove(names[i]);
                                i--;
                            }
                            else if (condition == "Length" && length(names[i]))
                            {
                                names.Remove(names[i]);
                                i--;
                            }

                            break;
                        case "Double":
                            if (condition == "StartsWith" && startsWith(names[i]))
                            {
                                names.Insert(i + 1, names[i]);
                                i++;
                            }
                            else if (condition == "EndsWith" && endsWith(names[i]))
                            {
                                names.Insert(i + 1, names[i]);
                                i++;
                            }
                            else if (condition == "Length" && length(names[i]))
                            {
                                names.Insert(i + 1, names[i]);
                                i++;
                            }
                            break;
                        default:
                            break; ;
                    }
                }

                command = Console.ReadLine()
                    .Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();
            }
            
            if (names.Count != 0)
            {
                Console.WriteLine($"{string.Join(", ", names)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
    }
}
