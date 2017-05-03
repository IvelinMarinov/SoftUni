using System;

namespace _02.Randomize_Words
{
    public class RandomizeWords
    {
        public static void Main()
        {
            var words = Console.ReadLine().Split();

            var rnd = new Random();

            for (int i = 0; i < words.Length - 1; i++)
            {
                var randomIndex = rnd.Next(0, words.Length);
                var currentWord = words[i];
                var nextWord = words[randomIndex];

                words[i] = nextWord;
                words[randomIndex] = currentWord;
            }

            foreach (var word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}
