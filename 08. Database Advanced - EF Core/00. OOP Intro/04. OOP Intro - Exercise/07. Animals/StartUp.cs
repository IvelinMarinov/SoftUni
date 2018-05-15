using System;
using System.Collections.Generic;

namespace _07.Animals
{
    public class StartUp
    {
        public static void Main()
        {
            var animals = new List<Animal>();

            string typeOfAnimal = Console.ReadLine();
            while (typeOfAnimal != "Beast!")
            {
                var animalTokens = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    switch (typeOfAnimal.ToLower())
                    {
                        case "cat":
                            Animal cat = new Cat(animalTokens[0], int.Parse(animalTokens[1]), animalTokens[2]);
                            animals.Add(cat);
                            break;
                        case "dog":
                            Animal dog = new Dog(animalTokens[0], int.Parse(animalTokens[1]), animalTokens[2]);
                            animals.Add(dog);
                            break;

                        case "frog":
                            Animal frog = new Frog(animalTokens[0], int.Parse(animalTokens[1]), animalTokens[2]);
                            animals.Add(frog);
                            break;

                        case "kitten":
                            Animal kitten = new Kitten(animalTokens[0], int.Parse(animalTokens[1]), animalTokens[2]);
                            animals.Add(kitten);
                            break;

                        case "tomcat":
                            Animal tomcat = new Tomcat(animalTokens[0], int.Parse(animalTokens[1]), animalTokens[2]);
                            animals.Add(tomcat);
                            break;

                        default:
                            Console.WriteLine("Invalid input!");
                            break;
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message); ;
                }

                typeOfAnimal = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.IntroduceAnimal());
                Console.WriteLine(animal.ProduceSound());
            }
        }
    }
}
