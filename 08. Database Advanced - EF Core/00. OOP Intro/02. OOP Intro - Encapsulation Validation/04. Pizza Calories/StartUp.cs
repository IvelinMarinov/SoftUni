using System;

namespace _04.Pizza_Calories
{
    public class StartUp
    {
        public static void Main()
        {
            try
            {
                var pizzaName = Console.ReadLine().Substring(6);
                var pizza = new Pizza(pizzaName);

                var doughArgs = Console.ReadLine().Split();
                pizza.Dough = new Dough(doughArgs[1], doughArgs[2], double.Parse(doughArgs[3]));

                var toppingArgs = Console.ReadLine().Split();

                while (toppingArgs[0] != "END")
                {
                    pizza.AddTopping(new Topping(toppingArgs[1], double.Parse(toppingArgs[2])));

                    toppingArgs = Console.ReadLine().Split();
                }

                Console.WriteLine(pizza);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
