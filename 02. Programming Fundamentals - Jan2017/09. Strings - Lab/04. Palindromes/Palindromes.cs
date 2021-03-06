﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Palindromes
{
    public class Palindromes
    {
        public static void Main()
        {
            var text = Console.ReadLine()
                .Split(new[] { ' ', ',', '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries);

            var palindromesList = new List<string>();

            foreach (var word in text)
            {
                if (word.Length == 1)
                {
                    palindromesList.Add(word);
                }

                bool isPalindrome = false;

                for (int i = 0; i < word.Length/2; i++)
                {
                    if (word[i] == word[word.Length - 1 - i])
                    {
                        isPalindrome = true;
                    }
                    else
                    {
                        isPalindrome = false;
                        break;
                    }
                }

                if (isPalindrome)
                {
                    palindromesList.Add(word);
                }
            }

            Console.WriteLine(string
                .Join(", ", palindromesList
                .Distinct()
                .OrderBy(x => x)));
        }
    }
}
