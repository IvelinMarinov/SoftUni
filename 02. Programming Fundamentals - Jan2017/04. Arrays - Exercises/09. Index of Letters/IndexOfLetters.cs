using System;
using System.Linq;

namespace _09.Index_of_Letters
{
    class IndexOfLetters
    {
        static void Main()
        {
            char[] input = Console.ReadLine().ToLower().ToCharArray();

            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            for (int j = 0; j < input.Length; j++)
            {
                for (int i = 0; i < alphabet.Length; i++)
                {
                    if (input[j] == alphabet[i])
                    {
                        Console.WriteLine($"{input[j]} -> {i}");
                    }
                }
            }
        }
    }
}
