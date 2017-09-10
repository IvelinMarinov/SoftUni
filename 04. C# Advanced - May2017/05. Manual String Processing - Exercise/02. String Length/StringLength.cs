using System;

namespace _02.String_Length
{
    public class StringLength
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var result = string.Empty;

            if (input.Length >= 20)
            {
                result = input.Substring(0, 20);
            }
            else
            {
                result = input.PadRight(20, '*');
            }

            Console.WriteLine(result);
        }
    }
}
