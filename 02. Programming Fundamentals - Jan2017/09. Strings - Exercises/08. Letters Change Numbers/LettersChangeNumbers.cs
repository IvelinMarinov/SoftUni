using System;
using System.Linq;

namespace _08.Letters_Change_Numbers
{
    public class LettersChangeNumbers
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(new[] {' ', '\t'}, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
                        
            var sum = 0.0;

            foreach (var word in input)
            {
                var currNumber = double.Parse(word.Substring(1, word.Length - 2));
                var currSum = 0.0;
                var firstLetterCode = word[0] + 0;
                var secondLetterCode = word[word.Length - 1] + 0;

                if (firstLetterCode >= 97 && firstLetterCode <= 122)
                {
                    currSum += currNumber * (firstLetterCode - 96);
                }
                else
                {
                    currSum += currNumber / (firstLetterCode - 64);
                }

                if (secondLetterCode >= 97 && secondLetterCode <= 122)
                {
                    currSum += secondLetterCode - 96;
                }
                else
                {
                    currSum -= secondLetterCode - 64;
                }

                sum += currSum;
            }

            Console.WriteLine($"{sum:f2}");
            
        }

    }
}
