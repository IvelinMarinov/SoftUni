using System;

namespace _03.Parse_Tags
{
    public class ParseTags
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var openTag = "<upcase>";
            var openTagIndex = input.IndexOf(openTag);
            var closeTag = "</upcase>";
            

            while (openTagIndex != -1)
            {
                var closeTagIndex = input.IndexOf(closeTag);
                if (closeTagIndex == -1)
                {
                    break;
                }

                var textToBeReplaced = input.Substring(openTagIndex, closeTagIndex - openTagIndex + openTag.Length + 1);
                var replacementText = textToBeReplaced
                    .Replace(openTag, string.Empty)
                    .Replace(closeTag, string.Empty)
                    .ToUpper();

                input = input.Replace(textToBeReplaced, replacementText);

                openTagIndex = input.IndexOf(openTag);
            }

            Console.WriteLine(input);
        }
    }
}
