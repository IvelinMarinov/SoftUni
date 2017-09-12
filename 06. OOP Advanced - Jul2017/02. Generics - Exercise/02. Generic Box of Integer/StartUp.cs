using System;

namespace _02.Generic_Box_of_Integer
{
    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            int inputInteger;
            Box<int> stringBox = new Box<int>();

            for (int i = 0; i < n; i++)
            {
                inputInteger = int.Parse(Console.ReadLine());
                stringBox.Data.Add(inputInteger);
            }

            Console.WriteLine(stringBox.ToString());
        }
    }
}
