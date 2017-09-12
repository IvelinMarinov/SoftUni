using System;

namespace _01.Generic_Box_of_String
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

            Console.WriteLine(stringBox.ToString());
        }
    }
}
