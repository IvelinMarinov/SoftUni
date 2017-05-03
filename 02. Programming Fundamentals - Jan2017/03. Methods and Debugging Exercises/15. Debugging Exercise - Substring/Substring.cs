using System;

public class Substring_broken
{
    public static void Main()
    {
        string text = Console.ReadLine();
        int jump = int.Parse(Console.ReadLine());

        const char Search = 'p';
        bool hasMatch = false;

        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] == Search)
            {
                hasMatch = true;

                var endIndex = i + jump;
                var matchedStringLenght = jump + 1;

                if (endIndex > text.Length - 1)
                {
                    matchedStringLenght = text.Length - i;
                }

                var matchedString = text.Substring(i, matchedStringLenght);
                Console.WriteLine(matchedString);
                i += jump;   
            }
        }

        if (!hasMatch)
        {
            Console.WriteLine("no");
        }
    }
}
