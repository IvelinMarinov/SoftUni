using System;
using System.Collections.Generic;
using System.Linq;

namespace _13.Magic_exchangeable_words
{
    public class MagicExchangeableWords
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split();
            var shorterString = string.Empty;
            var longerString = string.Empty;

            if (input[0].Length > input[1].Length)
            {
                longerString = input[0];
                shorterString = input[1];
            }

            else
            {
                longerString = input[1];
                shorterString = input[0];
            }

            var mappings = new Dictionary<char, char>();
            var isExchangeable = true;

            for (int i = 0; i < shorterString.Length; i++)
            {
                if (!mappings.ContainsKey(shorterString[i]))
                {
                    mappings.Add(shorterString[i], longerString[i]);
                }
                else if (mappings.ContainsKey(shorterString[i]) && mappings[shorterString[i]] == longerString[i])
                {
                    isExchangeable = true;
                }
                else
                {
                    isExchangeable = false;
                }
            }

            for (int i = shorterString.Length; i < longerString.Length; i++)
            {
                if (!mappings.ContainsValue(longerString[i]))
                {
                    isExchangeable = false;
                }
            }

            var NumOfCharsInLongerString = longerString.Distinct().ToArray().Length;
            var NumOfCharsInShorterString = shorterString.Distinct().ToArray().Length;

            if (NumOfCharsInLongerString != NumOfCharsInShorterString)
            {
                isExchangeable = false;
            }

            var result = isExchangeable.ToString().ToLower();

            Console.WriteLine(result);
        }
    }
}
