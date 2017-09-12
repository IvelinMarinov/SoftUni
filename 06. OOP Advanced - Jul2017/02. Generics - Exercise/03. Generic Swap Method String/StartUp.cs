using System;
using System.Linq;

namespace _03.Generic_Swap_Method_String
{
    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            string inputSting;
            Box<string> stringBox = new Box<string>();

            for (int i = 0; i < n; i++)
            {
                inputSting = Console.ReadLine();
                stringBox.Data.Add(inputSting);
            }

            var swapCommand = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            stringBox.Swap(swapCommand[0], swapCommand[1]);
            
            Console.WriteLine(stringBox.ToString());
        }
    }
}
