using System;
using System.Collections.Generic;

namespace _02.Advertisement_Message
{
    class Program
    {
        static void Main(string[] args)
        {
            var phrases = new string[]
                {
                    "Excellent product.",
                    "Such a great product.",
                    "I always use that product.",
                    "Best product of its category.",
                    "Exceptional product.",
                    "I can’t live without this product."
                };

            var events = new string[]
                {
                    "Now I feel good.",
                    "I have succeeded with this product.",
                    "Makes miracles. I am happy of the results!",
                    "I cannot believe but now I feel awesome.",
                    "Try it yourself, I am very satisfied.",
                    "I feel great!"
                };

            var author = new string[]
                {
                    "Diana",
                    "Petya",
                    "Stella",
                    "Elena",
                    "Katya",
                    "Iva",
                    "Annie",
                    "Eva"
                };

            var Cities = new string[]
                {
                    "Sofia",
                    "Plovdiv",
                    "Varna",
                    "Burgas",
                    "Ruse"
                };

            var rnd = new Random();
            var randomPhrase = phrases[rnd.Next(0, phrases.Length)];
            var randomEvent = events[rnd.Next(0, events.Length)];
            var randomAuthor = author[rnd.Next(0, author.Length)];
            var randomCity = Cities[rnd.Next(0, Cities.Length)];

            Console.WriteLine($"{randomPhrase} {randomEvent} {randomAuthor} - {randomCity}");
        }
    }
}
