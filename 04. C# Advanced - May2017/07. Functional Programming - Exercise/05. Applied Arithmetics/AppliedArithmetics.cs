using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Applied_Arithmetics
{
    public class AppliedArithmetics
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            Func<int, int> add = x => x + 1;
            Func<int, int> multiply = x => x * 2;
            Func<int, int> substract = x => x - 1;
            Action<List<int>> print = x => Console.WriteLine(string.Join(" ", x));

            var command = Console.ReadLine();

            while (command != "end")
            {
                switch (command)
                {
                    case "add":
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            numbers[i] = add(numbers[i]);
                        }
                        break;

                    case "multiply":
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            numbers[i] = multiply(numbers[i]);
                        }
                        break;

                    case "subtract":
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            numbers[i] = substract(numbers[i]);
                        }
                        break;

                    case "print":
                        print(numbers);
                        break;
                }

                command = Console.ReadLine();
            }
        }
    }
}
