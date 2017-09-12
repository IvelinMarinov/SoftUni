using System;

namespace _00.Generic_Box
{
    public class StartUp
    {
        public static void Main()
        {
            var first = 123123;
            var intBox = new Box<int>();
            intBox.Data.Add(first);
            Console.WriteLine(intBox.ToString());

            var second = "life in a box";
            var stringBox = new Box<string>();
            stringBox.Data.Add(second);
            Console.WriteLine(stringBox.ToString());
        }
    }
}
