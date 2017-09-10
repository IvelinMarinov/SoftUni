using System;

namespace _06.Count_Substring_Occurrences
{
    public class CounSubstringOccurrences
    {
        public static void Main()
        {
            var text = Console.ReadLine().ToLower();
            var searchString = Console.ReadLine().ToLower();
            bool isMatch;
            var matchesCount = 0;

            for (int i = 0; i < text.Length; i++)
            {
                isMatch = false;
                if (text[i] == searchString[0])
                {
                    for (int j = 0; j < searchString.Length; j++)
                    {
                        if (i + j > text.Length - 1)
                        {
                            break;
                        }

                        if (text[i + j] == searchString[j])
                        {
                            isMatch = true;
                        }
                        else
                        {
                            isMatch = false;
                            break;
                        }
                    }

                    if (isMatch)
                    {
                        matchesCount++;
                    }
                }
            }

            Console.WriteLine(matchesCount);
        }
    }
}
