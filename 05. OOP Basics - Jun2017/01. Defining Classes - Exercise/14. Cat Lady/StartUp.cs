using System;
using System.Collections.Generic;
using System.Linq;

namespace _14.Cat_Lady
{
    public class StartUp
    {
        public static void Main()
        {
            var cats = new List<Cat>();

            var input = Console.ReadLine();

            while (input != "End")
            {
                var inputArgs = input.Split();
                var breed = inputArgs[0];
                var name = inputArgs[1];
                var attribute = double.Parse(inputArgs[2]);

                switch (breed)
                {
                    case "Siamese":
                        if (cats.Count == 0 || !cats.Any(c => c.Name == name))
                        {
                            cats.Add(new Siamese(name, attribute));
                        }
                        break;

                    case "Cymric":
                        if (cats.Count == 0 || !cats.Any(c => c.Name == name))
                        {
                            cats.Add(new Cymric(name, attribute));
                        }
                        break;

                    case "StreetExtraordinaire":
                        if (cats.Count == 0 || !cats.Any(c => c.Name == name))
                        {
                            cats.Add(new StreetExtraordinaire(name, attribute));
                        }
                        break;

                    default:
                        break;
                }
                input = Console.ReadLine();
            }
            var catNameToPrint = Console.ReadLine();
            var catToPrint = cats.FirstOrDefault(c => c.Name == catNameToPrint);
            Console.WriteLine(catToPrint.ToString());
        }
    }
}
