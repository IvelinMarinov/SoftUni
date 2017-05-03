using System;

namespace _02.Count_Substring_Occurrences
{
    public class CountSubstringOccurences
    {
        public static void Main()
        {
            var text = Console.ReadLine().ToLower();
            var pattern = Console.ReadLine().ToLower();

            var count = 0;
            var index = 0;

            while (index != -1)
            {
                index = text.IndexOf(pattern, index);

                if (index >= 0)
                {
                    count++;
                    index++;
                }
            }

            Console.WriteLine(count);
        }
    }
}
