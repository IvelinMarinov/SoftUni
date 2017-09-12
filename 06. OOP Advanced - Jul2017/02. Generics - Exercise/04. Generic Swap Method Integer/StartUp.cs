using System;
using System.Linq;

namespace _04.Generic_Swap_Method_Integer
{
    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            int inputInteger;
            Box<int> integerBox = new Box<int>();

            for (int i = 0; i < n; i++)
            {
                inputInteger = int.Parse(Console.ReadLine());
                integerBox.Data.Add(inputInteger);
            }

            var swapCommand = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            integerBox.Swap(swapCommand[0], swapCommand[1]);

            Console.WriteLine(integerBox.ToString());
        }
    }
}
