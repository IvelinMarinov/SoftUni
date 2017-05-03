using System;
using System.Linq;

namespace ConsoleApplication1
{
    public class ReverseString
    {
        public static void Main()
        {
            var text = Console.ReadLine().ToCharArray();

            var reversedText = text.Reverse();

            Console.WriteLine(string.Join("", reversedText));
        }
    }
}
