using System;
using System.Linq;

namespace _03.Text_Filter
{
    public class TextFilter
    {
        public static void Main()
        {
            var bannedWords = Console.ReadLine()
                .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var text = Console.ReadLine();
            
            for (int i = 0; i < bannedWords.Length; i++)
            {
                text = text.Replace(bannedWords[i], new string('*', bannedWords[i].Length));
            }

            Console.WriteLine(text);
        }
    }
}
