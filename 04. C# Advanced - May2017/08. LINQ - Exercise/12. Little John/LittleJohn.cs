using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _12.Little_John
{
    public class LittleJohn
    {
        public static void Main()
        {
            string smallArrowPattern = @"(?<!>)(>----->)(?!>)";
            string medArrowPattern = @"(?<!>)(>>----->)(?!>)";
            string largeArrowPattern = $"(?<!>)(>>>----->>)(?!>)";

            Regex smArrRegex = new Regex(smallArrowPattern);
            Regex medArrRegex = new Regex(medArrowPattern);
            Regex lgArrRegex = new Regex(largeArrowPattern);

            int smallArrows = 0;
            int mediumArrows = 0;
            int largeArrows = 0;

            for (int i = 0; i < 4; i++)
            {
                var input = Console.ReadLine();
                
                if (smArrRegex.IsMatch(input))
                {
                    smallArrows += smArrRegex.Matches(input).Count;
                }

                if (medArrRegex.IsMatch(input))
                {
                    mediumArrows += medArrRegex.Matches(input).Count;
                }

                if (lgArrRegex.IsMatch(input))
                {
                    largeArrows += lgArrRegex.Matches(input).Count;
                }
            }

            var outputString = string.Concat(smallArrows, mediumArrows, largeArrows);
            var outputBinary = Convert.ToString(int.Parse(outputString), 2);
            var outputReversedBinaryArr = outputBinary.ToCharArray().Reverse().ToArray();
            var outputReversedBinary = string.Join("", outputReversedBinaryArr);
            var outputBinaryCombined = string.Concat(outputBinary, outputReversedBinary);
            var outputFinal = Convert.ToInt32(outputBinaryCombined, 2);

            Console.WriteLine(outputFinal);
        }
    }
}
