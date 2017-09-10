using System;
using System.Linq;

namespace _09.Text_Filter
{
    public class TextFilter
    {
        public static void Main()
        {
            var bannedWords = Console.ReadLine()
            .Split(new[] { ',', ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries)
            .ToArray();

            var text = Console.ReadLine();

            foreach (var bannedWord in bannedWords)
            {
                var replacementWord = new string('*', bannedWord.Length);
                text = text.Replace(bannedWord, replacementWord);
            }
            
            Console.WriteLine(text);
        }
    }
}
