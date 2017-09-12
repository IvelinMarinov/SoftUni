using System;

namespace _05.Generic_Count_Method_String
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

            var comparisonString = Console.ReadLine();
            
            Console.WriteLine(stringBox.GreaterThanCount(comparisonString));
        }
    }
}
