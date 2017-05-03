using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Split_by_Word_Casing
{
    public class SplitByWordCasing
    {
        public static void Main()
        {
            char[] separators = { ',', ';', ':', '.', '!', '(', ')', '"', '[', ']', ',', '/', '\\', '\'', ' ' };

            List<string> inputText = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries).ToList();

            List<string> lowercaseWords = new List<string>();
            List<string> uppercaseWords = new List<string>();
            List<string> mixedcaseWords = new List<string>();

            foreach (var word in inputText)
            {
                bool isLowercase = true;
                bool isUppercase = true;

                foreach (var letter in word)
                {
                    if (char.IsLower(letter))
                    {
                        isUppercase = false;
                    }
                    else if (char.IsUpper(letter))
                    {
                        isLowercase = false;
                    }
                    else
                    {
                        isUppercase = false;
                        isLowercase = false;
                    }              
                }

                if (isUppercase)
                {
                    uppercaseWords.Add(word);
                }
                else if (isLowercase)
                {
                    lowercaseWords.Add(word);
                }
                else
                {
                    mixedcaseWords.Add(word);
                }
            }

            Console.WriteLine($"Lower-case: {string.Join(", ", lowercaseWords)}");
            Console.WriteLine($"Mixed-case: {string.Join(", ", mixedcaseWords)}");
            Console.WriteLine($"Upper-case: {string.Join(", ", uppercaseWords)}");
        }
    }
}
