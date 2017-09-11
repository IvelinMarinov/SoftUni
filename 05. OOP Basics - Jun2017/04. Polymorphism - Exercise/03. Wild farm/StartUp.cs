using System;

namespace _03.Wild_farm
{
    public class StartUp
    {
        public static void Main()
        {
            string animalName;
            string animalType;
            double animalWeight;
            string animalLivingRegion;
            string catBreed;
            string foodType;
            int foodQuantiy;

            var command = Console.ReadLine();

            while (command != "End")
            {
                var animalInfo = command.Split();
                animalType = animalInfo[0];
                animalName = animalInfo[1];
                animalWeight = double.Parse(animalInfo[2]);
                animalLivingRegion = animalLivingRegion = animalInfo[3];
                Animal currentAnimal;
                
                switch (animalType.ToLower())
                {
                    case "cat":
                        catBreed = animalInfo[4];
                        currentAnimal = new Cat(animalName, animalType, animalWeight, animalLivingRegion, catBreed);
                        break;
                    case "mouse":
                        currentAnimal = new Mouse(animalName, animalType, animalWeight, animalLivingRegion);
                        break;
                    case "tiger":
                        currentAnimal = new Tiger(animalName, animalType, animalWeight,animalLivingRegion);
                        break;
                    case "zebra":
                        currentAnimal = new Zebra(animalName, animalType, animalWeight, animalLivingRegion);
                        break;
                    default:
                        currentAnimal = new Tiger("","",1,"");
                        break;
                }
                currentAnimal.MakeSound();

                var foodInfo = Console.ReadLine().Split();
                foodType = foodInfo[0];
                foodQuantiy = int.Parse(foodInfo[1]);

                Food currentFood;
                switch (foodType.ToLower())
                {
                    case "vegetable":
                        currentFood = new Vegetable(foodQuantiy);
                        break;
                    case "meat":
                        currentFood = new Meat(foodQuantiy);
                        break;
                    default:
                        currentFood = new Vegetable(0);
                        break;
                }
                currentAnimal.Eat(currentFood);
                Console.WriteLine(currentAnimal.ToString());

                command = Console.ReadLine();
            }
        }
    }
}
