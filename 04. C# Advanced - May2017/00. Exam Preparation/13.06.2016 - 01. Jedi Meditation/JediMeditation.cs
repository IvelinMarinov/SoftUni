using System;
using System.Collections.Generic;
using System.Linq;

namespace _13._06._2016___01.Jedi_Meditation
{
    public class JediMeditation
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var isYodaHere = false;
            var masters = new List<string>();
            var knights = new List<string>();
            var padawans = new List<string>();
            var toshkoAndSlav = new List<string>();
            var result = new List<string>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                var inputArgs = input
                    .Split(new[] {' ', '\t', '\n'}, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                foreach (var jedi in inputArgs)
                {
                    var jediType = jedi[0];

                    switch (jediType.ToString().ToLower())
                    {
                        case "k":
                            knights.Add(jedi);
                            break;;
                        case "m":
                            masters.Add(jedi);
                            break;
                        case "p":
                            padawans.Add(jedi);
                            break;;
                        case "t":
                            toshkoAndSlav.Add(jedi);
                            break;
                        case "s":
                            toshkoAndSlav.Add(jedi);
                            break;
                        case "y":
                            isYodaHere = true;
                            break;
                        default:
                            break;
                    }
                }
            }
            if (isYodaHere)
            {
                result.AddRange(masters);
                result.AddRange(knights);
                result.AddRange(toshkoAndSlav);
                result.AddRange(padawans);
            }
            else
            {
                result.AddRange(toshkoAndSlav);
                result.AddRange(masters);
                result.AddRange(knights);
                result.AddRange(padawans);
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
