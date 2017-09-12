
using System;

namespace _03.Dependency_Inversion
{
    public class StartUp
    {
        public static void Main()
        {
            PrimitiveCalculator calculator = new PrimitiveCalculator();
            string[] input = Console.ReadLine().Split();

            while (input[0] != "End")
            {
                if (input[0] == "mode")
                {
                    calculator.changeStrategy(char.Parse(input[1]));
                }
                else
                {
                    int firstOperand = int.Parse(input[0]);
                    int secondOperand = int.Parse(input[1]);
                    Console.WriteLine(calculator.performCalculation(firstOperand,secondOperand ));
                }

                input = Console.ReadLine().Split();
            }
        }
    }
}
