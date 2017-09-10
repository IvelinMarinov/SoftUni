using System;
using System.Text;

namespace _05.Concatenate_Strings
{
    public class ConcatenateStrings
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var sb = new StringBuilder();
            
            for (int i = 0; i < n; i++)
            {
                var word = Console.ReadLine();
                sb.Append(word).Append(" ");
            }

            var result = sb.ToString();

            Console.WriteLine(result);
        }
    }
}
