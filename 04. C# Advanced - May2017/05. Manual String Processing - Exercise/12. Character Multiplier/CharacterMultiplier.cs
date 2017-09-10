using System;

namespace _12.Character_Multiplier
{
    public class CharacterMultiplier
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var result = MultiplyCharCodes(input);

            Console.WriteLine(result);
        }

        public static int MultiplyCharCodes(string input)
        {
            var inputStrings = input.Split();
            var firstString = inputStrings[0].ToCharArray();
            var secondString = inputStrings[1].ToCharArray();

            var firstStringInts = new int[firstString.Length];
            var secondStringInts = new int[secondString.Length];

            for (int i = 0; i < firstString.Length; i++)
            {
                firstStringInts[i] = firstString[i] + 0;
            }

            for (int i = 0; i < secondString.Length; i++)
            {
                secondStringInts[i] = secondString[i] + 0;
            }

            var sum = 0;
            var shorterString = Math.Min(firstString.Length, secondString.Length);

            for (int i = 0; i < shorterString; i++)
            {
                sum += firstStringInts[i] * secondStringInts[i];
            }

            if (firstString.Length > secondString.Length)
            {
                for (int i = secondString.Length; i < firstString.Length; i++)
                {
                    sum += firstStringInts[i];
                }
            }

            else if (firstString.Length < secondString.Length)
            {
                for (int i = firstString.Length; i < secondString.Length; i++)
                {
                    sum += secondStringInts[i];
                }
            }

            return sum;
        }
    }
}
