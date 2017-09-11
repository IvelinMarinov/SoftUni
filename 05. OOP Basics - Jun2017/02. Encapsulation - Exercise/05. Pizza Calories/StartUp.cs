using System;

namespace _05.Pizza_Calories
{
    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            try
            {
                while (input != "END")
                {
                    var tokens = input.Split();

                    switch (tokens[0].ToLower())
                    {
                        case "dough":
                            var flourType = tokens[1];
                            var bakingTechnique = tokens[2];
                            var doughWeight = double.Parse(tokens[3]);
                            var dough = new Dough(flourType, bakingTechnique, doughWeight);
                            Console.WriteLine($"{dough.CalculateCalories():f2}");
                            break;

                        case "topping":
                            var toppingType = tokens[1];
                            var toppingWeight = double.Parse(tokens[2]);
                            var topping = new Topping(toppingType, toppingWeight);
                            Console.WriteLine($"{topping.CalculateCalories():f2}");
                            break;

                        case "pizza":
                            MakePizza(tokens);
                            break;
                    }
                    input = Console.ReadLine();
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void MakePizza(string[] tokens)
        {
            var pizzaName = tokens[1];
            var numberOfToppings = int.Parse(tokens[2]);
            var pizza = new Pizza(pizzaName, numberOfToppings);
            var doughInput = Console.ReadLine().Split();
            var dough = new Dough(doughInput[1], doughInput[2], double.Parse(doughInput[3]));
            pizza.Dough = dough;

            for (int i = 0; i < numberOfToppings; i++)
            {
                var toppingInput = Console.ReadLine().Split();
                var toppingType = toppingInput[1];
                var toppingWeight = double.Parse(toppingInput[2]);
                var topping = new Topping(toppingType, toppingWeight);
                pizza.AddTopping(topping);
            }

            Console.WriteLine($"{pizza.Name} - {pizza.CalculateCalories():f2} Calories.");
        }
    }
}
