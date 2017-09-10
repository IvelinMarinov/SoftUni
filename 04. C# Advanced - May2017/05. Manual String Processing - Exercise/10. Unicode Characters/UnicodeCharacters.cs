using System;
using System.Text;

namespace _10.Unicode_Characters
{
    public class UnicodeCharacters
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var sb = new StringBuilder();

            foreach (var symbol in input)
            {
                sb.Append($"\\u{(int)symbol:x4}");
            }

            var result = sb.ToString();

            Console.WriteLine(result);
        }
    }
}
