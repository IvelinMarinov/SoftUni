using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.Google
{
    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var persons = new List<Person>();

            while (input != "End")
            {
                var inputArgs = input.Split();
                var personName = inputArgs[0];
                Person person;

                if (!persons.Any(p => p.Name == personName))
                {
                    person = new Person(personName);
                    persons.Add(person);
                }
                else
                {
                    person = persons
                        .Where(p => p.Name == personName)
                        .FirstOrDefault();
                }

                switch (inputArgs[1].ToLower())
                {
                    case "company":
                        var companyName = inputArgs[2];
                        var department = inputArgs[3];
                        var salary = double.Parse(inputArgs[4]);
                        person.Company = new Company(companyName, department, salary);
                        break;

                    case "pokemon":
                        var pokemonName = inputArgs[2];
                        var pokemonType = inputArgs[3];
                        if (person.Pokemons.Count == 0 || !person.Pokemons.Any(p => p.Name == pokemonName))
                        {
                            person.Pokemons.Add(new Pokemon(pokemonName, pokemonType));
                        }
                        break;

                    case "parents":
                        var parentName = inputArgs[2];
                        var parentBday = inputArgs[3];
                        if (person.Parents.Count == 0 || !person.Parents.Any(p => p.Name == parentName))
                        {
                            person.Parents.Add(new Parent(parentName, parentBday));
                        }
                        break;

                    case "children":
                        var childName = inputArgs[2];
                        var childBday = inputArgs[3];
                        if (person.Children.Count == 0 || !person.Children.Any(p => p.Name == childName))
                        {
                            person.Children.Add(new Child(childName, childBday));
                        }
                        break;

                    case "car":
                        var carModel = inputArgs[2];
                        var carSpeed = double.Parse(inputArgs[3]);
                        person.Car = new Car(carModel, carSpeed);
                        break;

                    default:
                        break;
                }

                input = Console.ReadLine();
            }

            var personNameToPrint = Console.ReadLine();

            var personToPrint = persons
                .Where(p => p.Name == personNameToPrint)
                .FirstOrDefault();

            Console.WriteLine(personToPrint.ToString());
        }
    }
}
